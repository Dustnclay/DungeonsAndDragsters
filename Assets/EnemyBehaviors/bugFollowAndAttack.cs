using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugFollowAndAttack : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent Enemy;
    public Transform Player;
    private Animator anim;

    public float targetScale = 0.1f;
    public float shrinkSpeed = .3f;
    public float minimumDistance = 65;
    public float attackDistance = 5;


    public bool isDead = false;
    
    void Start(){
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if(isDead){
            anim.SetBool("Walk Forward", false);
            anim.SetBool("Stab Attack", false);
            Enemy.transform.localScale -= Vector3.one*Time.deltaTime*shrinkSpeed;
            Enemy.velocity = Vector3.zero;
        }
        
        if( !isDead && Vector3.Distance(transform.position, Player.position) < minimumDistance && Vector3.Distance(transform.position, Player.position) > attackDistance){
            anim.SetBool("Walk Forward", true);
            anim.SetBool("Stab Attack", false);
            Enemy.SetDestination(Player.position);
        }
        else if(!isDead && Vector3.Distance(transform.position, Player.position) < attackDistance){
            anim.SetBool("Walk Forward", false);
            anim.SetBool("Stab Attack", true);
            Enemy.SetDestination(Player.position);
        }
    }

    public void takeDamage(){
        anim.SetTrigger("Die");

        isDead = true;
        Destroy(gameObject, 5);
    }
}
