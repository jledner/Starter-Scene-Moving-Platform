using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehavior : MonoBehaviour
{
    public Transform target;
    public float step;
    public float proximityDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= proximityDistance)
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
