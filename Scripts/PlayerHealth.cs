using UnityEngine;

using UnityEngine.UI;
using System.Collections;



public class PlayerHealth : MonoBehaviour {

	

   public int startingHealth = 100;
   public int currentHealth;  
   public Slider healthSlider; 
   public Image damageImage;
   public float flashSpeed = 5f; 
   public Color flashColour = new Color(1f, 0f, 0f, 0.1f); 
   public GameObject player;
   public Canvas canvas;

   Animator anim;
   PlayerMovement playerMovement;    
   PlayerShooting playerShooting; 
   bool isDead;
   bool damaged;   
   int counter;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        counter = 0;
    }

    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
        if(isDead == true)  {
            ++counter;
            if(counter < 200){
               Quaternion target = Quaternion.Euler(82f,player.transform.eulerAngles.y,0f);
               player.transform.rotation = Quaternion.Slerp(transform.rotation,target,Time.deltaTime*2f);
            }
            else if(counter == 200){
               StartCoroutine (restart()); }
       }
    }

    IEnumerator restart() {
         yield return new WaitForSeconds(7);
         Application.LoadLevel (Application.loadedLevel);
    }
     

    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

    //    anim.SetTrigger ("Die");

        playerMovement.enabled = false;
        canvas.enabled = false;
        
        playerShooting.enabled = false;
    }       

}