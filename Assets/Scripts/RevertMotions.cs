using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevertMotions : MonoBehaviour
{
    public moveChairsTrue MCT;
    public float normHor;
    public float normVer;
    private float time;
    public bool On;

    void Start()
    {
        MCT = GameObject.FindWithTag("Player").GetComponent<moveChairsTrue>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (On == true)
        {
            MCT.Lock = true;
            if (time <= 5f)
            {
                time += Time.deltaTime;
                MCT.moveHorizontal = Input.GetAxis("Vertical");
                MCT.moveVertical = Input.GetAxis("Horizontal");
            }
            else
            {
                MCT.moveHorizontal = Input.GetAxis("Horizontal");
                MCT.moveVertical = Input.GetAxis("Vertical");
                On = false;
                MCT.Lock = false;
                time = 0f;
            }
        }
    }
}
