using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_CTRL : MonoBehaviour
{

    // Static instance of Menu_CTRL
    public static Menu_CTRL instance { get; private set; }

    [SerializeField] GameObject Start_Menu_Canvas;
    [SerializeField] GameObject Categorys_Canvas;
    [SerializeField] GameObject Mode_Canvas;
    [SerializeField] GameObject Loading_Canvas;


    

    // -------------------------------------------------------------------------------

    #region // ------------------------------------------------------------------------------- Initialize
    
    string Last_Page;


    
    public void Start(){
        // Ensure the instance is set
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // Destroy duplicate if exists
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep the instance alive across scene changes
        }

        // Open_Page("Start");
        Back_Button_Clicked();

    }   


    public void Update(){
        
    }  

    #endregion

    #region // ------------------------------------------------------------------------------- Button Sound Effect

    [SerializeField] AudioSource buttonClickAudioSource;
    [SerializeField] AudioClip buttonClickClip;

    public void OnButtonClick()
    {
        buttonClickAudioSource.PlayOneShot(buttonClickClip);
    }

    #endregion

    #region // ------------------------------------------------------------------------------- Page Management


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

    public void Change_Page(string _CurrentPage, string _NextPage, string type = null)
    {
        Open_Page("Loading");

        // Store the last page
        Last_Page = _NextPage; // Fix the comparison to assignment

        Open_Page(_NextPage);
        Close_Page(_CurrentPage);

        Close_Page("Loading");
    }

    public void Back_Button_Clicked()
    {
        if (!string.IsNullOrEmpty(Last_Page))
        {
            Change_Page(Last_Page, "Start"); // Go back to the previous page or some default one
            Debug.Log("back    "+ Last_Page);
        }
        else{
            Open_Page("Start");
        }
    }
    #endregion

    #region // ------------------------------------------------------------------------------- Buttons
    
    public void Boat_Button_Cliked(){
        Change_Page(Last_Page, "Catrgory");
        Debug.Log("klickedddddd");
    }


    #endregion

    // -------------------------------------------------------------------------------
    
    void OpenScene(string Name){
        // Application.
        Debug.Log(Name + " Scene is Openingh ... ");

        // Use SceneManager to load the scene by its name
        SceneManager.LoadScene(Name);  // Loads the scene based on the passed string

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


}
