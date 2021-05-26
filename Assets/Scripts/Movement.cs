using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool left = true;
    float speed = 1;
    float limit = 1.5f;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        if (left && this.transform.position.x >= -limit)
        {
            animator.SetFloat("Horizontal", -speed);
            Vector3 horizontal = new Vector3(-speed, 0.0f, 0.0f);
            transform.position = transform.position + horizontal * Time.deltaTime;
        }else if (this.transform.position.x < -limit)
        {
            left = false;
        }

        if (!left && this.transform.position.x <= limit)
        {
            animator.SetFloat("Horizontal", speed);
            Vector3 horizontal = new Vector3(speed, 0.0f, 0.0f);
            transform.position = transform.position + horizontal * Time.deltaTime;
        }
        else if (this.transform.position.x > limit)
        {
            left = true;
        }


    }
}
