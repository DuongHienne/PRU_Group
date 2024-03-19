using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 30;

    //This func is called (it runs) whenever something enters the enemy's collider"
    void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.CompareTag("Ethan"))
        {
            Debug.Log("Enemy hit:" + trig.gameObject.name);
            PlayerHealthInteraction targetHealth = trig.GetComponent<PlayerHealthInteraction>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
            }
        }

    }


}
