using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekBadMinions : MonoBehaviour
{
    private BadMinion badMinion;

    private void Start()
    {
        badMinion = GetComponent<BadMinion>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            badMinion.IsDone = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            badMinion.IsDone = true;
        }
    }
}
