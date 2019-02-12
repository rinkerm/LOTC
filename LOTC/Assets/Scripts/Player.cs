using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 facing;
    private Animator animator;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        facing = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed Left Click");
            animator.SetBool("attack", true);
        }
        GetDir();
        
    }

    public void Move()
    {
        transform.Translate(facing*speed*Time.deltaTime);
        AnimateMovement(facing);
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

    private void GetDir()
    {

        if (Input.GetKey(KeyCode.W))
        {
            facing = Vector2.up;
            Move();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            facing = Vector2.left;
            Move();
        }

        else if (Input.GetKey(KeyCode.S))
        {
            facing = Vector2.down;
            Move();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            facing = Vector2.right;
            Move();
        }
        else
        {
            animator.SetFloat("x", 0);
            animator.SetFloat("y", 0);
        }
        if(i == 35)
        {
            animator.SetBool("attack", false);
            i = 0;
        }
            
        i = i + 1;
    }


}
