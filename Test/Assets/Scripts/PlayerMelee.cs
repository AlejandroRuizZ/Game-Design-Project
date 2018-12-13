using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    bool attacking = false;
    float attackTimer = 0;
    float AttackCoolDown = 0.3f;
    public Collider2D attackTrigger;
    public int e;
    Animator anim;
    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update() 
    {
		if (Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackTimer = AttackCoolDown;

            attackTrigger.enabled = true;
            e++;
        }

        if(attacking)
        {
           if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
           else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
            
        }
        
	}

}
