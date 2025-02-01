using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class Superman : MonoBehaviour
{
    [SerializeField] private BadMinion[] badMinions;
    [SerializeField] private Transform superminion;
    [SerializeField] private Rigidbody[] badMinionsBody;
    [SerializeField] private Transform target;
    [SerializeField] private new Transform camera;
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private int power;
    [SerializeField] private float jumpForce;
    
    private GameObject targetBadMinion;
    private Rigidbody rb;
    
    private int indexCount;
    private int remainingBadMinionCount;
    private bool isAllBadMinionEjected;
    private bool isGrounded;

    private void Start()
    {
        badMinions = FindObjectsOfType<BadMinion>();
        rb = GetComponent<Rigidbody>();
    }
        
    private void Update()
    {
        if (indexCount > 3)
        {
            indexCount = 0;
        }

        if (!badMinions[indexCount].IsDone)
        {
            superminion.position = Vector3.MoveTowards(superminion.position, badMinions[indexCount].transform.position, Time.deltaTime * speed);
            superminion.LookAt(badMinions[indexCount].transform.position);
        }
        else
        {
            foreach (BadMinion badMinion in badMinions)
            {
                if (!badMinion.IsDone)
                {
                    ++remainingBadMinionCount;
                }
            }

            if (remainingBadMinionCount >= 1) 
            {
                isAllBadMinionEjected = false;     
                remainingBadMinionCount = 0;
                indexCount++;
            }
            else
            {
                isAllBadMinionEjected = true;
            }
        }

        Jump();
    }

    private void Jump()
    {
        if (isAllBadMinionEjected)
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("BadMinion"))
        {
            BadMinion minion = collidedObject.GetComponent<BadMinion>();

            if (!minion.IsDone)
            {
                indexCount++;
                minion.IsDone = true;
                Push(collision);
            }
        }
    }

    private void Push(Collision minion)
    {
        Vector3 direction = minion.transform.position - superminion.position;
        minion.rigidbody.AddForce(direction.normalized * power, ForceMode.Impulse);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    //[SerializeField] private Transform[] points;
    //[SerializeField] private Transform[] minions;
    //[SerializeField] private float speed;

    //private Random randomTarget = new Random();

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();

    //    for (int i = 0; i < targets.Length; i++)
    //    {
    //        targets[i] = points[randomTarget.Next(10)].position;
    //    }
    //}

    ////private void OnCollisionEnter(Collision collision)
    ////{
    ////    if (collision.gameObject.CompareTag("Ground"))
    ////    {
    ////        isGrounded = true;
    ////    }
    ////}



    //private IEnumerator MinionGo()
    //{
    //    for (int i = 0; i < minions.Length;i++)
    //    {
    //        minions[i].position = Vector3.MoveTowards(minions[i].position, targets[i], Time.deltaTime * speed);
    //        minions[i].LookAt(targets[i]);

    //        if (minions[i].position == targets[i])
    //        {
    //            targets[i] = points[randomTarget.Next(10)].position;
    //        }

    //        yield return null;
    //    }
    //}
}
