using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderBoss : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent Enemy;
    public Transform Player;
    public float targetScale = 0.1f;
    public float shrinkSpeed = 30f;
    private Animation anim;
    public float minimumDistance;
    private bool isDead = false;

    public GameObject projectile;
    public Transform spawnPoint;
    public GameObject littleSpiders;
    public float yVelocity = 300f;
    public float zVelocity = 1500f;
    public float missleLifetime = 2f;
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

                GameObject launchedProjectile = Instantiate(projectile, transform.position, transform.rotation);
                launchedProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, yVelocity , zVelocity));
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

     IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
    
            SpawnSpiders();    
        }

    public void takeDamage(){
        StartCoroutine(ExecuteAfterTime(4));
        isDead = true;
        anim.Play("death2");
        Destroy(gameObject, 5);
    }

        void SpawnSpiders(){
        for (int i = 0; i < 30; i++){
        Instantiate(littleSpiders,spawnPoint.transform.position, Quaternion.identity);

}
        }


}
