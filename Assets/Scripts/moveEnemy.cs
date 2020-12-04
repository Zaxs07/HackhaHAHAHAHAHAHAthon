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
    public bool infMove;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i] = GameObject.Find("checkpoint (" + i + ")").transform;
        }
        speedRotation = 4f;
        speedMov = 100f;
        infMove = true;
        _rb = GetComponent<Rigidbody>();
        _rb.drag = 3f;
        _rb.angularDrag = 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (next)
        {
            Vector3 Rotation = checkpoints[child].position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Rotation), speedRotation * Time.deltaTime);
            //_rb.AddRelativeTorque(rotate.eulerAngles * speedRotation);
            _rb.AddRelativeForce(Vector3.forward * speedMov);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("checkpoint"))
        {
            child++;
            if (child == checkpoints.Length - 1)
            {
                if (infMove)
                {
                    child = 0;
                }
                else
                {
                    next = false;
                }
            }

        };
    }
}
