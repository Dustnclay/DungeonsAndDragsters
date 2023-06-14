// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class acidSpawn : MonoBehaviour
// {

//     public UnityEngine.AI.NavMeshAgent Enemy;
//     public Transform Player;
//     public float minimumDistance;
//     private bool isDead = false;

//     public GameObject projectile;
//     public float missleLifetime = 10f;
//     public float range = 20f;

//     float timer;
//     int waitingTime = 2;


//     void Update()
//     {
//         if( !isDead && Vector3.Distance(transform.position, Player.position) < minimumDistance && Vector3.Distance(transform.position, Player.position) > 5){
//             timer += Time.deltaTime;
//             anim.Play("run");
//             Enemy.SetDestination(Player.position);
//             if(timer > waitingTime){
//                 waitingTime = Random.Range(1, 3);
//                 int zdistance = (int)Vector3.Distance(transform.position, Player.position)*Random.Range(138, 142);
//                 int xVelocity = Random.Range(-100, 100);
//                 int yVelocity = Random.Range(50, 75);


//                 GameObject launchedProjectile = Instantiate(projectile, transform.position, transform.rotation);
//                 launchedProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (xVelocity, yVelocity , zdistance));
//                 launchedProjectile.transform.rotation = Enemy.transform.rotation;
//                 Destroy(launchedProjectile,missleLifetime);
//                 timer = 0;
//             }
//         }
//     }
// }
