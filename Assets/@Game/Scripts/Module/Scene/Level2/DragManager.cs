using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DragManager : MonoBehaviour
{
    public Transform itemsParent; // Parent containing draggable items
    public TMP_Text orderText; // UI text to display the current order
    public TMP_Text swapCountText; // UI text to display the swap count
    public TMP_Text gameWinText;
    public TMP_Text progressText;
    public Slider progressSlider; // Slider to display progress
    public UnityEvent onGameWin;

    private List<DraggableItem> draggableItems = new List<DraggableItem>();

    // Define the correct order of item names (this can be item IDs, names, or any unique identifier)
    public List<string> correctOrder = new List<string> { "Item1", "Item2", "Item3", "Item4", "Item5", "Item6" };

    private int swapCount = 0; // Tracks the number of swaps made

    private void Start()
    {
        // Initialize the draggable items list with the current children of the parent
        foreach (Transform child in itemsParent)
        {
            DraggableItem draggable = child.GetComponent<DraggableItem>();
            if (draggable != null)
            {
                draggableItems.Add(draggable);
                draggable.SetManager(this); // Let each draggable item reference the manager
            }
        }

        UpdateOrderDisplay(); // Display the initial order
        UpdateSwapCount(); // Initialize swap count display
        UpdateProgress(); // Initialize the progress bar
    }

    // Update the current order after swapping
    public void UpdateOrder()
    {
        draggableItems.Clear(); // Clear the list and re-populate it
        foreach (Transform child in itemsParent)
        {
            DraggableItem draggable = child.GetComponent<DraggableItem>();
            if (draggable != null)
            {
                draggableItems.Add(draggable); // Add the item back to the list
            }
        }

        UpdateOrderDisplay(); // Update the order display
        IncrementSwapCount(); // Increment the swap count after every swap
        UpdateProgress(); // Update progress bar based on the new order
        CheckForWinCondition(); // Check if the current order matches the correct order
    }

    // Display the current order in the UI
    private void UpdateOrderDisplay()
    {
        orderText.text = "(Debug Mode) Order: ";
        for (int i = 0; i < draggableItems.Count; i++)
        {
            orderText.text += draggableItems[i].name + " "; // Display each item's name
        }
    }

    // Increment the swap count and update the UI
    private void IncrementSwapCount()
    {
        swapCount++; // Increment the swap count
        UpdateSwapCount(); // Update the swap count text in the UI
    }

    // Update the swap count text in the UI
    private void UpdateSwapCount()
    {
        swapCountText?.SetText($"{swapCount}↕");
    }

    // Update the progress bar based on the number of correctly ordered items
    private void UpdateProgress()
    {
        int correctCount = 0;
        for (int i = 0; i < draggableItems.Count; i++)
        {
            // Compare the item names with the correct order
            if (draggableItems[i].name == correctOrder[i])
            {
                correctCount++;
            }
        }

        // Update the slider value (percentage of correct items)
        progressSlider.value = (float)correctCount / draggableItems.Count;
        progressText?.SetText($"{progressSlider.value * 100:F2}%");
    }

    // Check if the current order matches the correct order
    private void CheckForWinCondition()
    {
        for (int i = 0; i < draggableItems.Count; i++)
        {
            // Compare the item names with the correct order
            if (draggableItems[i].name != correctOrder[i])
            {
                return; // If any item doesn't match, exit the function
            }
        }

        // If all items match the correct order, trigger the win condition
        TriggerWin();
    }

    // Trigger the win condition
    private void TriggerWin()
    {
        gameWinText?.SetText($"{swapCount}↕");
        onGameWin?.Invoke();
    }
}
