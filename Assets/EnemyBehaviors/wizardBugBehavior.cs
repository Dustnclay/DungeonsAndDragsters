using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardBugBehavior : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent Enemy;
    private Transform Player;
    // private GameObject Player;
    private Animator anim;

    public float targetScale = 0.1f;
    public float shrinkSpeed = 30f;
    public float minimumDistance = 65;
    public float attackDistance = 5;


    public bool isDead = false;
    
    void Start(){
        anim = GetComponent<Animator>();
        Enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // if(isDead){
            anim.SetBool("isDead", true);
        //     Enemy.transform.localScale -= Vector3.one*Time.deltaTime*shrinkSpeed;
        //     Enemy.velocity = Vector3.zero;
        // }
        
        if( !isDead && Vector3.Distance(transform.position, Player.position) < minimumDistance && Vector3.Distance(transform.position, Player.position) > attackDistance){
            // anim.SetBool("isCasting", true);
            // animator.SetBool("isAttacking", false);
            // anim.Play("RunForward");

            // Enemy.SetDestination(Player.position);
        }else{
            anim.SetBool("isCasting", false);

        }
        // else if(!isDead && Vector3.Distance(transform.position, Player.position) < attackDistance){
        //     // Debug.Log("attack");
        //     // anim.Play("MeleeAttack_TwoHanded");

        //     // anim.SetBool("isAttacking", true);   
        //     anim.SetBool("isSprinting", false);
        //     Enemy.SetDestination(Player.position);
        // }
    }

    // public void takeDamage(){
    //     // Debug.Log("takeDamage");
    //     isDead = true;
    //     Destroy(gameObject, 5);
    // }
}
