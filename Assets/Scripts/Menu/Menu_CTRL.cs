using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_CTRL : MonoBehaviour
{

    [SerializeField] GameObject Start_Menu_Canvas;
    [SerializeField] GameObject Categorys_Canvas;
    [SerializeField] GameObject Mode_Canvas;
    [SerializeField] GameObject Loading_Canvas;

    string Last_Page;

    // -------------------------------------------------------------------------------

    public void Start(){
        Open_Page("Start");

    }   


    public void Update(){
        
    }  







    // -------------------------------------------------------------------------------
    

    void OpenScene(string Name){
        // Application.
        Debug.Log(Name + " Clicked !");

    }

    // -------------------------------------------------------------------------------

    [SerializeField] AudioSource buttonClickAudioSource;
    [SerializeField] AudioClip buttonClickClip;

    public void OnButtonClick()
    {
        buttonClickAudioSource.PlayOneShot(buttonClickClip);
    }

    public void Back_Button_Clicked()
    {
        if (!string.IsNullOrEmpty(Last_Page))
        {
            Change_Page(Last_Page, "Start"); // Go back to the previous page or some default one
        }
    }

    // -------------------------------------------------------------------------------

    public void Change_Page(string _CurrentPage, string _NextPage)
    {
        Open_Page("Loading");

        // Store the last page
        Last_Page = _CurrentPage; // Fix the comparison to assignment

        Open_Page(_NextPage);
        Close_Page(_CurrentPage);

        Close_Page("Loading");
    }

    void Open_Page(string name)
    {
        SetPageActive(name, true);
    }

    void Close_Page(string name)
    {
        SetPageActive(name, false);
    }

    // Helper function to set pages active or inactive
    void SetPageActive(string name, bool isActive)
    {
        switch (name)
        {
            case "Start":
                Start_Menu_Canvas.SetActive(isActive);
                break;
            case "Category":
                Categorys_Canvas.SetActive(isActive);
                break;
            case "Mode":
                Mode_Canvas.SetActive(isActive);
                break;
            case "Loading":
                Loading_Canvas.SetActive(isActive);
                break;
        }
    }

    // -------------------------------------------------------------------------------

    //  void InstantiateArrayInScrollView()
    // {
    //     // Loop through the array and instantiate buttons
    //     foreach (string item in items)
    //     {
    //         GameObject button = Instantiate(buttonPrefab, contentPanel);
    //         button.GetComponentInChildren<Text>().text = item;  // Set the text of the button to the item name

    //         // You can add listeners to buttons here if needed
    //         button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));
    //     }
    // }

    // -------------------------------------------------------------------------------
    
    public void Dena_Button_Cliked(){
        OpenScene("DenaScene");
    }




    


}
