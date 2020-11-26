using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    public Transform[] checkpoints;
    int child = 0;
    public float speedRotation;
    public float speedMov;
    private bool next = true;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i] = GameObject.Find("checkpoint (" + i + ")").transform;
        }
        speedRotation = 1f;
        speedMov = 0.35f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (next)
        {
            Vector3 Rotation = checkpoints[child].position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Rotation), speedRotation);
            transform.position += transform.forward * speedMov;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("checkpoint"))
        {
            child++;
            if (child == 130)
            {
                next = false;
            }
        };
    }
}
