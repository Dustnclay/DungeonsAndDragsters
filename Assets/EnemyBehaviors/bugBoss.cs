using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugBoss : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent Enemy;
    public Transform Player;
    private Animator anim;

    public float targetScale = 0.1f;
    public float shrinkSpeed = .3f;
    public float health = 300f;
    public float minimumDistance = 65;
    public float attackDistance = 5;
    public float damageToPlayer = 20;
    private bool canAttack = true;

    public Transform spawnPoint;
    public AudioSource hitSound;

    public GameObject wizard;

    public bool isDead = false;
    public float time = 0;
    
    void Start(){
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // if(time >= 5){
        //     Instantiate(wizard,spawnPoint.transform.position, Quaternion.identity);
        //     time = 0;
        // }
        if(isDead){
            anim.SetBool("Walk Forward", false);
            anim.SetBool("Stab Attack", false);
            Enemy.transform.localScale -= Vector3.one*Time.deltaTime*shrinkSpeed;
            Enemy.velocity = Vector3.zero;
        }
        
        if( !isDead && Vector3.Distance(transform.position, Player.position) < minimumDistance && Vector3.Distance(transform.position, Player.position) > attackDistance){
            anim.SetBool("Walk Forward", true);
            anim.SetBool("Stab Attack", false);
            Enemy.SetDestination(Player.position);
        }
        else if(!isDead && Vector3.Distance(transform.position, Player.position) < attackDistance){
            anim.SetBool("Walk Forward", false);
            anim.SetBool("Stab Attack", true);
            Enemy.SetDestination(Player.position);
            if(canAttack){
                Player.gameObject.SendMessage("takeDamage", damageToPlayer, SendMessageOptions.DontRequireReceiver);
                StartCoroutine(AttackCooldown());
            }
        }
    }

         IEnumerator ExecuteAfterTime()
            {
                Debug.Log("start wizad");
                yield return new WaitForSeconds(2f);
                Instantiate(wizard,transform.position, Quaternion.identity);
            }

        IEnumerator AttackCooldown()
            {
                canAttack = false;
                yield return new WaitForSeconds(2f); // 2 seconds cooldown
                canAttack = true;
            }

    public void takeDamage(float damage){
        if (hitSound != null)
        {
            // hitSound.Play();
        }
        if(isDead == false){
            health -= damage;
            Debug.Log(health);
            if(health <= 0)
            {
                StartCoroutine(ExecuteAfterTime());
                anim.SetTrigger("Die");
                isDead = true;
                Destroy(gameObject, 5);
            }
        }
    }

        void SpawnWizard(){

        }
}
