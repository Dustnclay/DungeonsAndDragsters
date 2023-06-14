// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SkeletonCollision : MonoBehaviour{

//     [SerializeField] private float knockbackForce;
//     private void OnCollisionEnter(Collision collision){
//             Debug.Log("Skeleton Collision", collision.collider);

//         Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
//         if(rb != null){
//                 Debug.Log("notNull", collision.collider);

//             Vector3 direction = collision.transform.position - transform.position;
//             direction.y = 0;
//             rb.AddForce(direction.normalized * knockbackForce, ForceMode.Impulse);
//         }
//     }
// }