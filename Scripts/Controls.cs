using UnityEngine;

using System.Collections;



public class Controls : MonoBehaviour {

	

    private PlayerMovement player;

    public float h;
    public float v;
    public float turn;

    private bool moves;
    private bool animation;

    void Start(){
  
       GameObject playerObject = GameObject.FindWithTag("Player");
       player = playerObject.GetComponent<PlayerMovement>();
       if (player == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
       moves = false;
       animation = true;
    }
    
    void FixedUpdate(){
        if(moves == true) {
           player.Turning(turn);
           player.Move(h,v,turn);
           
        }
    }
  
    public void move() {
        if(animation == true){
           player.Animating(true); 
           animation = false;}
        moves = true;
    }
    public void stops() {
        moves = false;
        player.Animating(false);
        animation = true;
    }
}
