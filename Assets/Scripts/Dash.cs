using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float DashForce = 300f;
    public float Speed = 10f;

    private Rigidbody enemy;
    private float time;
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        CharacterMotions();
    }
    void CharacterMotions()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        enemy.AddForce(movement * Speed);

        GoDash(movement);
        
    }

    void GoDash(Vector3 movement)
    {

        if (Input.GetAxis("Jump") > 0 && time >= 10f)
        {
            enemy.AddForce(movement * DashForce);
            time = 0f;
        }
    }
}
