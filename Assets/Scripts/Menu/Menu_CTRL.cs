using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_CTRL : MonoBehaviour
{

    [SerializeField] GameObject Start_Menu_Canvas;
    

    void OpenScene(string Name){
        // Application.Load
        Debug.Log(Name + " Clicked !");

    }

    // -------------------------------------------------------------------------------
    
    public void Dena_Button_Cliked(){
        OpenScene("DenaScene");
    }



}
