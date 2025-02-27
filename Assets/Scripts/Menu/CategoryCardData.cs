using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryCardData : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;    // The prefab for each card
    [SerializeField] Transform contentPanel;   // The content panel inside the ScrollView

    // Example list of cards (could also come from a JSON file)
    public List<Card> cardList = new List<Card>();

    void Start()
    {
        // Example cards, you can load this from a JSON file
        cardList.Add(new Card { name = "Card 1", description = "Description 1", price = 10 });
        cardList.Add(new Card { name = "Card 2", description = "Description 2", price = 20 });
        cardList.Add(new Card { name = "Card 3", description = "Description 3", price = 30 });

        // Populate the ScrollView with card data
        PopulateScrollView();
    }

    void PopulateScrollView()
    {
        // Clear old items in the content panel
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject); // Optionally deactivate for pooling
        }

        // Instantiate new cards from the card list
        foreach (Card card in cardList)
        {
            GameObject newCard = Instantiate(cardPrefab, contentPanel);
            newCard.GetComponentInChildren<Text>().text = card.name;
            newCard.transform.Find("DescriptionText").GetComponent<Text>().text = card.description;
            newCard.transform.Find("PriceText").GetComponent<Text>().text = "$" + card.price.ToString();

            // Assuming you have an Image component for the card's image
            newCard.transform.Find("CardImage").GetComponent<Image>().sprite = card.image;

            // Optionally, you can add more functionality like button click listeners here
            Button cardButton = newCard.GetComponent<Button>();
            cardButton.onClick.AddListener(() => OnCardClicked(card));
        }
    }

    // Handle card click event
    void OnCardClicked(Card card)
    {
        Debug.Log("Card Clicked: " + card.name);
        // Handle the logic when a card is clicked
    }
}
