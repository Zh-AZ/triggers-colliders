using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class Superman : MonoBehaviour
{
    [SerializeField] private Transform[] badMinions;
    [SerializeField] private Transform superminion;
    [SerializeField] private float speed;

    private void Start()
    {
        superminion.position = Vector3.MoveTowards(superminion.position, badMinions[0].position, Time.deltaTime * speed);
    }

    private void Update()
    {

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
