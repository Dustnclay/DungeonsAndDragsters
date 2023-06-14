using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartCollision : MonoBehaviour{

    [SerializeField] private float knockbackForce;


    private void OnCollisionEnter(Collision collision){
        // if(collision.collider.transform.tag == "Enemy"){
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            if(rb != null){

                Vector3 direction = collision.transform.position - transform.position;

                direction.y = 0;
                rb.AddForce(direction.normalized * knockbackForce, ForceMode.Impulse);
            }
        // }

    }
    // void onTriggerEnter(Collider other){
    //     Debug.Log("CollisionEnter with rb", other);
    //     if(other.gameObject.tag == "Enemy"){
    //         Debug.Log("hit enemy");
            // other.gameObject.SendMessageUpwards("takeDamage", SendMessageOptions.DontRequireReceiver);
        // }
    // }
    // void onTriggerStay(Collider other){
    //     Debug.Log("CollisionStay with rb", other);
    // }
    // void onTriggerExit(Collider other){
    //     Debug.Log("Collisionexit with rb", other);
    // }
}