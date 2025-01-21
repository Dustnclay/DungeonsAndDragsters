using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonFollowAndAttack : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent Enemy;
    public Transform Player;
    private Animator anim;

    public float targetScale = 0.1f;
    public float shrinkSpeed = 30f;
    public float minimumDistance = 65;
    public float attackDistance = 5;
    public bool isDead = false;
    
    void Start(){
        anim = GetComponent<Animator>();
        Enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        
        if(isDead){
            anim.SetBool("isDead", true);
            Enemy.transform.localScale -= Vector3.one*Time.deltaTime*shrinkSpeed;
            Enemy.velocity = Vector3.zero;
        }
        
        if( !isDead && Vector3.Distance(transform.position, Player.position) < minimumDistance && Vector3.Distance(transform.position, Player.position) > attackDistance){
            anim.SetBool("isSprinting", true);
            // animator.SetBool("isAttacking", false);
            // anim.Play("RunForward");

            Enemy.SetDestination(Player.position);
        }
        else if(!isDead && Vector3.Distance(transform.position, Player.position) < attackDistance){
            // Debug.Log("attack");
            // anim.Play("MeleeAttack_TwoHanded");

            // anim.SetBool("isAttacking", true);   
            anim.SetBool("isSprinting", false);
            Enemy.SetDestination(Player.position);
        }
    }

    public void takeDamage(){
        // Debug.Log("takeDamage");
        isDead = true;
        Destroy(gameObject, 5);
    }
}
