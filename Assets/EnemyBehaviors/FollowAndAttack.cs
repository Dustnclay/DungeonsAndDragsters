using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndAttack : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent Enemy;
    public Transform Player;
    public float targetScale = 0.1f;
 public float shrinkSpeed = 30f;
    public float minimumDistance;

    public bool isDead = false;
    
    void Start(){
        // animator = GetComponent<Animator>();
    }

    void Update()
    {
        if( !isDead && Vector3.Distance(transform.position, Player.position) < minimumDistance && Vector3.Distance(transform.position, Player.position) > 5){
            Enemy.SetDestination(Player.position);
        }
        else if(!isDead &&  Vector3.Distance(transform.position, Player.position) < 5){
            Enemy.SetDestination(Player.position);
        }
        if(isDead){
            Enemy.transform.localScale -= Vector3.one*Time.deltaTime*shrinkSpeed;
            Enemy.velocity = Vector3.zero;
        }

    }

    public void takeDamage(){
        isDead = true;
        Destroy(gameObject, 3);
    }


}
