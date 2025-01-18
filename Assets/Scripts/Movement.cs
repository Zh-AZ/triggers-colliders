using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class Movement : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Transform[] minions;
    [SerializeField] private float speed;

    private Vector3[] targets = new Vector3[10];
    private Random randomTarget = new Random();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = points[randomTarget.Next(10)].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MinionGo());
    }

    private IEnumerator MinionGo()
    {
        for (int i = 0; i < minions.Length; i++)
        {
            minions[i].position = Vector3.MoveTowards(minions[i].position, targets[i], Time.deltaTime * speed);
            minions[i].LookAt(targets[i]);

            if (minions[i].position == targets[i])
            {
                targets[i] = points[randomTarget.Next(10)].position;
            }

            yield return null;
        }
    }
}
