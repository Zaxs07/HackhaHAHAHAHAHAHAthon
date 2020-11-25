using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movechair : MonoBehaviour
{
    public float speed ;
    public float rotate ;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementLogic();
    }
    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        if (moveHorizontal != 0)
        {
            transform.Rotate(Vector3.down, moveHorizontal * rotate);

        }
        transform.Translate(movement * speed);
    }
}
