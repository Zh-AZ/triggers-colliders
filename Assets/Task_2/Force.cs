using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    [SerializeField] private Rigidbody redBall;
    [SerializeField] private float force;


    // Start is called before the first frame update
    void Start()
    {
        Push();
    }
    public void Push()
    {
        redBall.AddForce(Vector3.back * force, ForceMode.Impulse);
    }
}
