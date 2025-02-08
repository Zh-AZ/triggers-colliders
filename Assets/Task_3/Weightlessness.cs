using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weightlessness : MonoBehaviour
{
    private Rigidbody thisObject;

    private void Start()
    {
        thisObject = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        thisObject.useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        thisObject.useGravity = true;
    }
}
