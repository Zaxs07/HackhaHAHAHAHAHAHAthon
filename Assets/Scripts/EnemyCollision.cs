using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    private moveEnemy buba;// Start is called before the first frame update
    public float Slow;
    public float Duration;
    private float MaxSpeed;
    private float timer;
    void Start()
    {
        buba = gameObject.GetComponent<moveEnemy>();
        
        Slow = 0.6f;
        Duration = 3f;
        timer = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (buba.speedMov < MaxSpeed)
        {
            if (Duration > timer)
            {
                timer += 0.02f;
            }
            else
            {
                buba.speedMov = MaxSpeed;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {
            
            Destroy(collision.gameObject);
            MaxSpeed = buba.speedMov;
            buba.speedMov = MaxSpeed * Slow;
            timer = 0;
        }
    }
}
