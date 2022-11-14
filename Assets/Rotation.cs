using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    Vector3 Direction;

    void Update () {
         transform.Rotate(Direction);
    }
}