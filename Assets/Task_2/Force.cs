using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    [SerializeField] private Rigidbody redBall;
    [SerializeField] private float force;

    public void Push()
    {
        redBall.AddForce(Vector3.back * force, ForceMode.Impulse);
    }
}
