using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CategoryObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;  // The prefab for each object in the category
    [SerializeField] private Transform objectContentPanel;  // The content panel inside the category ScrollView
    [SerializeField] private List<CategoryObject> categoryObjects;  // List of objects for this category

    [SerializeField] private Sprite Dena_Picture;

    // Start is called before the first frame update
    void Start()
    {
        // Example data, this could be dynamically loaded or passed in from another class
        categoryObjects.Add(new CategoryObject { name = "Dena Ship", description = "Iranian Marines Militury Ship", image = Dena_Picture });
        categoryObjects.Add(new CategoryObject { name = "Boat Engine", description = "High-power engine for boats", image = null });
        categoryObjects.Add(new CategoryObject { name = "Handgun", description = "Compact handgun", image = null });

        PopulateObjectsInCategory();
    }

    // Populate objects in the category scroll view
    void PopulateObjectsInCategory()
    {
        // Clear old items in the object content panel
        foreach (Transform child in objectContentPanel)
        {
            Destroy(child.gameObject);  // Destroy all child objects (for refreshing)
        }

        // Instantiate new objects from the list
        for (int i = 0; i < categoryObjects.Count; i++)
        {
            CategoryObject categoryObject = categoryObjects[i];

            // Instantiate the object prefab
            GameObject newObject = Instantiate(objectPrefab, objectContentPanel);

            // // Set the object name and description text
            // Transform nameTransform = newObject.transform.Find("Name Text");
            // if (nameTransform != null)
            // {
            //     nameTransform.GetComponent<TextMeshProUGUI>().text = categoryObject.name;
            // }
            // else
            // {
            //     Debug.LogError("Name Text not found in prefab (under 'Name Text')");
            // }

            // newObject.transform.Find("Description Text").GetComponent<TextMeshProUGUI>().text = categoryObject.description;

            // Optionally assign an image if provided
            if (categoryObject.image != null)
            {
                Image objectImage = newObject.transform.Find("Object Image").GetComponent<Image>();
                objectImage.sprite = categoryObject.image;
            }

            // Add a button click listener for the object
            Button objectButton = newObject.GetComponent<Button>();
            objectButton.onClick.AddListener(() => OnObjectClicked(categoryObject));
        }
    }

    // Handle object click event
    void OnObjectClicked(CategoryObject categoryObject)
    {
        Debug.Log("Object Clicked: " + categoryObject.name);
        // Implement additional functionality, such as showing detailed information about the object
    }
}

[System.Serializable]
public class CategoryObject
{
    public string name;
    public string description;
    public Sprite image;
}
