using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBehavior : MonoBehaviour
{
    #region Public Viarables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; // Minimum distance for attacking
    public float movespeed;
    public float timer; // Timer for cooldown between attack


    #endregion
    private RaycastHit2D hit;
    private GameObject target;
    private Animator animator;
    private float distance; // Store distance b/w enemy and player
    private bool attackMode;
    private bool inRage; // check if player is in range
    private bool cooling; // check if enemy is cooling after attack
    private float intTimer;
    #region Private variables




    #endregion

     void Awake()
    {
        intTimer = timer;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (inRage)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, raycastMask);
            RaycastDebugger();
        }
        //When Player is detected
        if (hit.collider != null)
        {
            EnemyLogic();
        } else if (hit.collider == null)
        {
            inRage  = false;
        } if (inRage == false)
        {
            animator.SetBool("Walk", false);
            StopAttack();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);


        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldown();
            animator.SetBool("Attack", false);
        }


    }


    void Move()
    {
        animator.SetBool("Walk", true);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movespeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; // Reset Timer when Player enter Attack Range
        attackMode = true; // To check if Enemy can still attack or not


        animator.SetBool("Walk", false);
        animator.SetBool("Attack", true);
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }


     void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRage =  true;
        }
    }
    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }


    public void TriggerCooling()
    {
        cooling = true;

    }



}