using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     public int startingHealth = 100;   
     public int currentHealth;                  
     public float sinkSpeed = 2.5f;             
     public int scoreValue = 10;   
     public AudioSource dead;      

     Animator anim;                               
     CapsuleCollider capsuleCollider;            
     bool isDead;                            
     bool isSinking;    

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        currentHealth = startingHealth;
     }
   
    void Update ()
    {
        if(isSinking)
        {
     //       transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage (int amount)
    {
        if(isDead) {
            return; }

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Death ();
        }
    }

    void Death ()
    {
        dead.Play();
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger ("Dead");
    }

    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;

        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 7f);
    }

}