using UnityEngine;

public class ExampleReflect : MonoBehaviour
{
    // Calculate the reflection of a "laser beam" off a clicked object.

    // The object from which the beam is fired. The incoming beam will
    // not be visible if the camera is used for this!
    private Shooter _shooter;


    private float shotTime = 0f;

    [SerializeField]
    float MaxDistance = 20f;

    [SerializeField]
    float CoolTime = 5f;
    void Start()
    {
        _shooter = GetComponent<Shooter>();

    }


    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, MaxDistance))
        {
            // Find the line from the gun to the point that was clicked.
            Vector3 incomingVec = hit.point - transform.position;

            // Use the point's normal to calculate the reflection vector.
            Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);

            // Draw lines to show the incoming "beam" and the reflection.
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.DrawRay(hit.point, reflectVec, Color.green);


            Debug.Log($"ray-{hit.transform.gameObject.tag}");
            // 反射先
            Ray ray2 = new Ray(reflectVec, transform.forward);
            if (Physics.Raycast(ray2, out hit, MaxDistance))
            {
                Debug.Log($"ray2-{hit.transform.gameObject.tag}");
                if (hit.transform.gameObject.tag.Equals("Player"))
                {
                    // 撃った時間がクールタイム以降なら撃てる
                    if (Time.time - shotTime > CoolTime)
                    {
                        shotTime = Time.time;
                        Debug.Log("撃つべし！");
                        _shooter.Shot();
                    }
                }
            }




        }
    }
}