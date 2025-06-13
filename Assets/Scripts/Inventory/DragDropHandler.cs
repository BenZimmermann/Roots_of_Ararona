using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragDropHandler : MonoBehaviour
{
    private Image childImage;
    private TMP_Text childText;

    public ChestController chestController;
    public InventoryManager inventoryManager; // Referenz zum InventoryManager, falls benötigt
    public Sprite newSprite;

    void Start()
    {
        // Finde das Child-Image und Child-Text Komponenten
        childImage = GetComponentInChildren<Image>();
        childText = GetComponentInChildren<TMP_Text>();
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (chestController == null)
        {
            chestController = FindObjectOfType<ChestController>();
        }
    }

    public void ClickFunction()
    {
        if (chestController == null)
        {
            Debug.LogWarning("ChestController nicht gefunden!");
            return;
        }

        if (!chestController.IsOpen())
        {
            Debug.Log("Chest ist geschlossen - Aktion wird nicht ausgeführt");
            inventoryManager.RefreshUI();
            return;
        }
        Debug.Log("Button wurde gedrückt");

        // Setze Image Sprite auf neues Sprite
        if (childImage != null && newSprite != null)
        {
            childImage.sprite = newSprite;
            childImage.enabled = false;
        }

        // Setze Text auf null/leer
        if (childText != null)
        {
            childText = null;
        }
    }
}