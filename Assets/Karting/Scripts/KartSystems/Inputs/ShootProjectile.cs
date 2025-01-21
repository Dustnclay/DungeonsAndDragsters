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
    public float damageAmount = 25f;

    public GameObject kartCam;
    public AudioSource shootSound;
    Animator anim;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
       }
    }
    void Shoot(){
        if (shootSound != null)
        {
            shootSound.Play();
        }
        RaycastHit hit;

        if(Physics.Raycast(kartCam.transform.position, kartCam.transform.forward, out hit, range)){
            if(hit.transform.tag == "Enemy")

                hit.transform.gameObject.SendMessageUpwards("takeDamage",damageAmount, SendMessageOptions.DontRequireReceiver);
        }
        //using bullet
        // GameObject launchedProjectile = Instantiate(projectile, transform.position, transform.rotation);
        
        // launchedProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, yVelocity , zVelocity));
        // launchedProjectile.transform.rotation = kartCam.transform.rotation;

        // Destroy(launchedProjectile,missleLifetime);
    }

}
