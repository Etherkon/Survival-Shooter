using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class MainMenu : MonoBehaviour {



    private bool isStart = false;
    private bool isQuit = false;

    public Canvas myCG;

    public GUIText text;


    void Start() {
         text.text = "";  }

    public void QuitActive(){
         isQuit = true;
    }
    public void StartActive(){
         
         text.text = "Loading";
       
         isStart = true;
    }  
    
    void Update()
    {
        if(isQuit == true){
            Application.Quit();
          
        }
        if(isStart == true) {
           myCG.gameObject.SetActive(false);
           Application.LoadLevel(1);

        }
         
    }

}