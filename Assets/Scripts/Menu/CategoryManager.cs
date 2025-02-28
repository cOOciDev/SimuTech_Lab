using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CategoryManager : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;    // The prefab for each card
    [SerializeField] private Transform contentPanel;   // The content panel inside the ScrollView

    [SerializeField] private List<Sprite> cardImages;  // Serialized list of images for the cards

    // Example list of category cards (can be loaded from a JSON file or other data sources)
    public List<CategoryCard> categoryCardList = new List<CategoryCard>();



    private void Awake() {
        
    }

    void Start()
    {
        // Example category cards, you can load this from a JSON file or another source
        categoryCardList.Add(new CategoryCard { name = "Boats", description = "Dena Ship and something else" });
        categoryCardList.Add(new CategoryCard { name = "Chemical", description = "Coming Soon ..."  });
        categoryCardList.Add(new CategoryCard { name = "Weapons", description = "Coming Soon ..."  });
        categoryCardList.Add(new CategoryCard { name = "Electricity", description = "Coming Soon ..."  });
        categoryCardList.Add(new CategoryCard { name = "Mechanic", description = "Coming Soon ..."  });
        categoryCardList.Add(new CategoryCard { name = "Tools", description = "Coming Soon ..."  });

        // Populate the ScrollView with category card data
        PopulateScrollView();
    }

    void PopulateScrollView()
    {
        // Clear old items in the content panel, keeping the first item
        foreach (Transform child in contentPanel)
        {
            // Skip the first child (the one to keep)
            if (child == contentPanel.GetChild(0))
            {
                continue;  // Don't destroy the first child
            }

            // Check for "guid Text" and destroy other items if they don't have it
            if (child.Find("guid Text") != null)
            {
                Debug.Log("Found guid Text, not destroying this item");
            }
            else
            {
                Destroy(child.gameObject); // Optionally deactivate for pooling
            }
        }

        // Instantiate new category cards from the list
        for (int i = 0; i < categoryCardList.Count; i++)
        {
            CategoryCard categoryCard = categoryCardList[i];

            // Instantiate the category card prefab
            GameObject newCard = Instantiate(cardPrefab, contentPanel);

            // Set the name and description text
            Transform nameLabelBGTransform = newCard.transform.Find("Name Label BG");
            Transform CardNameTransform = nameLabelBGTransform.Find("Name Text");
            // Check if the components are found and assign the text
            if (nameLabelBGTransform != null)
            {

                if (CardNameTransform != null)
                {
                    CardNameTransform.GetComponent<TextMeshProUGUI>().text = categoryCard.name;
                }
                else
                {
                    Debug.LogError("Name Text not found in prefab (under 'Name Text')");
                }

            }
            else
            {
                Debug.LogError("Name Text not found in prefab (under 'Name Label BG')");
            }


            newCard.transform.Find("Description Text").GetComponent<TextMeshProUGUI>().text = categoryCard.description;


            // Assign the image if available (using the index to map the correct image from the list)
            Image cardImage = newCard.transform.Find("Card Image").GetComponent<Image>();
            if (i < cardImages.Count)
            {
                cardImage.sprite = cardImages[i]; // Use the image from the serialized list
            }

     

            // Add a button click listener for the card
            Button cardButton = newCard.GetComponent<Button>();
            cardButton.onClick.AddListener(() => OnCategoryCardClicked(categoryCard));
        }
    }

    // Handle category card click event
    void OnCategoryCardClicked(CategoryCard categoryCard)
    {
        Debug.Log("Category Card Clicked: " + categoryCard.name);
        // Implement additional functionality, such as displaying more information or opening a new scene
        Menu_CTRL.instance.Change_Page("Start", "Category", categoryCard.name);
    }
}

[System.Serializable]
public class CategoryCard
{
    public string name;
    public string description;
    public Sprite image;
}

[System.Serializable]
public class CategoryCardListWrapper
{
    public List<CategoryCard> categoryCards;
}
