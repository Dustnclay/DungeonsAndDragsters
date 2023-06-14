using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float yVelocity = 300f;
    public float zVelocity = 1500f;
    public float missleLifetime = 2f;
    public float range = 20f;

    public GameObject kartCam;
    Animator anim;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Mouse0)){
            Shoot();
       }
    }
    void Shoot(){
        RaycastHit hit;

        if(Physics.Raycast(kartCam.transform.position, kartCam.transform.forward, out hit, range)){
            if(hit.transform.tag == "Enemy")
                // Debug.Log("hit");
                hit.transform.gameObject.SendMessageUpwards("takeDamage", SendMessageOptions.DontRequireReceiver);
                // Destroy(hit.transform.gameObject , 3);   
        }
        //using bullet
        // GameObject launchedProjectile = Instantiate(projectile, transform.position, transform.rotation);
        
        // launchedProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, yVelocity , zVelocity));
        // launchedProjectile.transform.rotation = kartCam.transform.rotation;

        // Destroy(launchedProjectile,missleLifetime);
    }

}
