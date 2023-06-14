using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderFollowAndAttack : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent Enemy;
    public Transform Player;
    public float targetScale = 0.1f;
    public float shrinkSpeed = 30f;
    private Animation anim;
    public float minimumDistance;
    private bool isDead = false;

    public GameObject projectile;
    public float missleLifetime = 10f;
    public float range = 20f;

    float timer;
    int waitingTime = 2;

    
    void Start(){
        // animator = GetComponent<Animator>();
        anim = gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        if( !isDead && Vector3.Distance(transform.position, Player.position) < minimumDistance && Vector3.Distance(transform.position, Player.position) > 5){
            timer += Time.deltaTime;
            anim.Play("run");
            Enemy.SetDestination(Player.position);
            if(timer > waitingTime){
                waitingTime = Random.Range(1, 3);
                int zdistance = (int)Vector3.Distance(transform.position, Player.position)*Random.Range(138, 142);
                int xVelocity = Random.Range(-100, 100);
                int yVelocity = Random.Range(50, 75);

                Vector3 temp = transform.position;
                temp.x = 10.0f;
                transform.position = temp;

                GameObject launchedProjectile = Instantiate(projectile, transform.position, transform.rotation);
                launchedProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (xVelocity, yVelocity , zdistance));
                launchedProjectile.transform.rotation = Enemy.transform.rotation;
                Destroy(launchedProjectile,missleLifetime);
                timer = 0;
            }
        }
        else if(!isDead &&  Vector3.Distance(transform.position, Player.position) < 5){
            anim.Play("attack1");
            Enemy.SetDestination(Player.position);
        }
        if(isDead){
            Enemy.transform.localScale -= Vector3.one*Time.deltaTime*shrinkSpeed;
            Enemy.velocity = Vector3.zero;
        }

    }

    public void takeDamage(){
        isDead = true;
        anim.Play("death1");
        Destroy(gameObject, 3);
    }


}
