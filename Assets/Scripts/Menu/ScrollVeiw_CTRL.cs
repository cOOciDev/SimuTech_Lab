using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollVeiw_CTRL : MonoBehaviour
{
[SerializeField] GameObject buttonPrefab;  // Button prefab
    [SerializeField] Transform contentPanel;  // Scroll View content panel (parent)
    [SerializeField] int arraySize = 10;      // Array size for testing
    string[] items = new string[10];          // Array of strings to populate buttons

    void Start()
    {
        // Simulate an array of items (replace with real data in production)
        for (int i = 0; i < arraySize; i++)
        {
            items[i] = "Item " + (i + 1);
        }

        InstantiateArrayInScrollView();
    }

    void InstantiateArrayInScrollView()
    {
        // Loop through the array and instantiate buttons
        foreach (string item in items)
        {
            GameObject button = Instantiate(buttonPrefab, contentPanel);
            button.GetComponentInChildren<Text>().text = item;  // Set the text of the button to the item name

            // You can add listeners to buttons here if needed
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));
        }
    }

    void OnButtonClick(string item)
    {
        Debug.Log("Button clicked: " + item);
    }
}

[System.Serializable]
public class Card
{
    public string name;
    public string description;
    public Sprite image;
    public int price;
}
