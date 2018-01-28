using UnityEngine;

using System.Collections;



public class Firing : MonoBehaviour {

	

    private PlayerShooting player;
    AudioSource audio;

    bool shoots;
    bool plays;

    void Start() {

      audio = GetComponent<AudioSource> ();

      GameObject barrel = GameObject.FindWithTag("Barrel");
      player = barrel.GetComponent<PlayerShooting>();
      if (player == null)
      {
            Debug.Log ("Cannot find 'Barrel' script");
      }
      shoots = false;
      plays = false;
    }

    void FixedUpdate() {
       if(shoots == true){
          player.Shoot();
          player.Fires(true);
       }
       else {
          player.Fires(false);
       }
       if(plays == true) {
          audio.Play();
          plays = false;
       }
    }
   
   public void shooting() {
      shoots = true;
      plays = true;
   }
   public void stops() {
      shoots = false;
      audio.Stop();
   }

}