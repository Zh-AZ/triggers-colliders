using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] private Transform[] balls;
    [SerializeField] private Vector3[] ballsPosition;
    [SerializeField] private Force hit;

    // Start is called before the first frame update
    void Start()
    {
            
    }
    public void Reboot()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].localPosition = ballsPosition[i];
        }

        hit.Push();
    }
}
