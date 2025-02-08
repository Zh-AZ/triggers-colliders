using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWeightlessness : MonoBehaviour
{
    [SerializeField] private Transform point_1;
    [SerializeField] private Transform point_2;
    private Vector3 target;
    [SerializeField] private float speed;
    [SerializeField] private bool go;

    // Start is called before the first frame update
    void Start()
    {
        target = point_1.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
            transform.position = Vector3.MoveTowards(transform.position, target, speed);

        if (transform.position == target)
        {
            if (target == point_1.position)
                target = point_2.position;
            else if (target == point_2.position)
                target = point_1.position;
        }
    }
}
