using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{ 
    public Animation anim;


    void Start()
    {
        anim = gameObject.GetComponent<Animation>();

    }
    public void TakeDamage(){
        anim.Play("death1");
    }
}
