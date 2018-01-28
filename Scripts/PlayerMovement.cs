using UnityEngine;

using System.Collections;



public class PlayerMovement : MonoBehaviour {

	

    public float speed = 6f; 

    Vector3 movement;
    Vector3 rotate;
    Animator anim;
    Rigidbody playerRigidbody;
    public GameObject player;
    int floorMask;
    float camRayLength = 100f; 

   
    void Awake ()
    {
        floorMask = LayerMask.GetMask ("Floor");
        anim = GetComponent <Animator> ();
        playerRigidbody = GetComponent <Rigidbody> ();
    }

    public void Move(float h, float v,float turn) {
         anim.SetBool ("IsRunning", true);
         movement.Set (h, 0f, v);
         movement = movement.normalized * speed * Time.deltaTime;
         playerRigidbody.MovePosition (transform.position + movement);
    }
     
    public void Turning (float turn)
    {
        float tspeed = 7f;
        Quaternion target = Quaternion.Euler(0f, turn, 0f);
        player.transform.rotation =  Quaternion.Slerp(transform.rotation, target, Time.deltaTime*tspeed);
    }

    public void Animating (bool runs)
    {
        anim.SetBool ("IsRunning", runs);
    }

}