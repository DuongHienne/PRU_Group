using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer mask;
    private float speed = 7;

    private Collider2D collider2D;
    private float wallJumpCooldown;
    public GameObject prefabToInstantiate;
    private Animator anim;

    private enum MovemenState { idle, running, jumping, hurt, attack1, attack2, attack3}; 
    private MovemenState state = MovemenState.idle;
    void Start()
    {
        
    }
    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        mask = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float direcX = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(direcX * 7f, body.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            body.velocity = new Vector2(body.velocity.x, 7f);
        }
        
        UpdateAnimationStatde();

    }
    public void UpdateAnimationStatde() 
    {
        MovemenState state;
        if (body.velocity.x > 0f)
        {
            state = MovemenState.running;
            mask.flipX = false;
        }
        else if (body.velocity.x < 0f)
        {
            state = MovemenState.running;
            mask.flipX = true;
        }
        else
        {
            state = MovemenState.idle;
        }

        if (body.velocity.y > .1f)
        {
            state = MovemenState.jumping;
        }
        //else if ()
        //{
        //    state = MovemenState.hurt;
        //}
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            state |= MovemenState.attack1;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            state |= MovemenState.attack2;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            state |= MovemenState.attack3;
        }
        anim.SetInteger("state", (int)state);
    }
}