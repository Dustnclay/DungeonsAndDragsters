using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class acidProjectile: MonoBehaviour{
 private Vector3 refPos;
   private GameObject target;
   private bool sticked = false;
   void OnCollisionEnter(Collision collision)
         {
            Debug.Log("acid Collision", collision.collider);
             ContactPoint contact = collision.contacts[0];
            target = collision.gameObject;
             Vector3 refPos = contact.point - target.transform.position;
             sticked = true;
             //.....Other stuff you wana do when collided
           
         }
 
     void Update(){
 
     //... Other Update Stuff
 
     if(sticked)
          transform.position = target.transform.position + refPos;
 
 
 }}