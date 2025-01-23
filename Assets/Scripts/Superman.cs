using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class Superman : MonoBehaviour
{
    [SerializeField] private List<GameObject> badMinions;
    [SerializeField] private Transform superminion;
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private Rigidbody[] badMinionsBody;
    private GameObject targetBadMinion;

    [SerializeField] private Transform target;
    private int indexCount;

    private void Start()
    {
        target.position = badMinions[0].transform.position;

        //targetBadMinion = FindBadMinion();
    }

    private void Update()
    {
        //if (targetBadMinion == null)
        //{
        //    targetBadMinion = FindBadMinion();
        //}

        if (indexCount <= 3)
        {
            superminion.position = Vector3.MoveTowards(superminion.position, badMinionsBody[indexCount].position, Time.deltaTime * speed);
            superminion.LookAt(badMinionsBody[indexCount].position);
        }

        //if (superminion.position == badMinionsBody[indexCount].position && indexCount <= 3)
        //{
        //    indexCount++;

        //    //if (superminion.position != badMinionsBody[badMinionsBody.Length - 1].position)
        //    //{
        //    //    target.position = badMinions[indexCount].transform.position;
        //    //}
        //}
    }

    private void OnCollisionEnter (Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("BadMinion"))
        {
            BadMinion minion = collidedObject.GetComponent<BadMinion>();

            if (minion != null && !minion.IsDone)
            {
                indexCount++;

                minion.IsDone = true;
   
                collision.rigidbody.AddForce(10, 10, 0, ForceMode.Impulse);
            }
        }

        //if (collision.gameObject.GetComponent<Rigidbody>() != null)
        //{
        //    if (indexCount <= 3)
        //    {
        //        indexCount++;
        //        Debug.Log("Touch");
        //    }
        //}
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<Rigidbody>() != null)
    //    {
    //        collision.rigidbody.AddForce(10, 10, 0);

    //    }
    //}

    private GameObject FindBadMinion()
    {
        GameObject nearMinion = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject minion in badMinions)
        {
            if (minion == null)
            {
                badMinions.Remove(minion);
                continue;
            }

            float distance = Vector3.Distance(transform.position, minion.transform.position);
            
            if (distance < minDistance)
            {
                minDistance = distance;
                nearMinion = minion;
            }
        }
        return nearMinion;
    }









    //[SerializeField] private Transform[] points;
    //[SerializeField] private Transform[] minions;
    //[SerializeField] private float speed;
    //[SerializeField] private float jumpForce;

    //private Vector3[] targets = new Vector3[10];
    //private Rigidbody rb;
    //private bool isGrounded;
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

    //// Update is called once per frame
    //void Update()
    //{
    //    if (isGrounded)
    //    {
    //        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //        isGrounded = false;
    //    }

    //    StartCoroutine(MinionGo());
    //}

    ////private void OnCollisionEnter(Collision collision)
    ////{
    ////    if (collision.gameObject.CompareTag("Ground"))
    ////    {
    ////        isGrounded = true;
    ////    }
    ////}

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //    }
    //}

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
