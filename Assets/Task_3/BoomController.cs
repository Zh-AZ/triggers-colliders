using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    [SerializeField] private float timeToExplosion;
    [SerializeField] private float power;
    [SerializeField] private float radius;
    private Rigidbody[] blocks;

    void Update()
    {
        timeToExplosion -= Time.deltaTime;

        if (timeToExplosion <= 0 )
        {
            Boom();
        }
    }

    private void Boom()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody b in blocks )
        {
            float distance = Vector3.Distance(transform.position, b.transform.position);

            if (distance < radius)
            {
                Vector3 direction = b.transform.position - transform.position;
                b.AddForce(direction.normalized * power * (radius - distance), ForceMode.Impulse);
            }
        }

        timeToExplosion = 3;
    }
}
