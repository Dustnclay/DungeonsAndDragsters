using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public bool isDead = false;
    public GameObject Player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(float damage){

    if(isDead == false){
        health -= damage;
        Debug.Log(health);
        if(health <= 0)
        {
            // StartCoroutine(ExecuteAfterTime(1));
            // anim.SetTrigger("Die");
            isDead = true;
            Destroy(Player, 1);
        }
    }
    }
}
