using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator PlayerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Space))
        {
            PlayerAnimation.Play("Slow Run");
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            PlayerAnimation.Play("Fast Run");
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
        {
            PlayerAnimation.Play("Jump");
        }
        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.W))
        {
            PlayerAnimation.Play("Standing Jump");
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            PlayerAnimation.Play("Idle");
        }



    }
}
