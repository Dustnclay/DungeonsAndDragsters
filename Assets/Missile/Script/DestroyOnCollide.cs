using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
   public GameObject Enemy;

   private void OnTriggerEnter()
   {      
      Destroy(gameObject);
   }
   // private void OnCollisionEnter(Collision collision)
   //   {
   //       if (collision.transform.tag == "Enemy")
   //       {
   //           // do damage here, for example:
   //           collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
   //       }
   //   }

}


