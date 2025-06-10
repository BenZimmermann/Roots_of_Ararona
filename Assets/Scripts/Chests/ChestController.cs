using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private PlayerControls playerControls;
    private bool isOpen = false;
    private bool isNear = false;
    //-----------------------------------
    [SerializeField] private GameObject chestCanvas;
    [SerializeField] private GameObject PlayerCanvas;

    private InventoryManager inventory;
    public ItemClass AddItem1;

    //sprite for the chest when open and closed
    public Sprite openSprite;
    public Sprite closedSprite;

    private SpriteRenderer spriteRenderer;
    //-----------------------------------
    private void Start()
    {
        spriteRenderer = gameObject.transform.parent.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite;
    }
    private void Awake()
    {
        // Initialize player controls
        playerControls = new PlayerControls();
        playerControls.Player.ChestOpen.performed += ctx => OpenChest();
    }
    private void OpenChest()
    {
        if (!isNear) return;
        // Logic to open the chest
        ToggleCanvas();
        Debug.Log("Chest opened!");
        isOpen = !isOpen;
        spriteRenderer.sprite = openSprite;
        // Add the item to the inventory if it is not null

        }
    private void OnEnable()
    {
        // Enable player controls when the script is enabled
        playerControls.Player.Enable();
    }
    private void OnDisable()
    {
        // Disable player controls when the script is disabled
        playerControls.Player.Disable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.CompareTag("Player"))
        {
            // Open the chest
            isNear = true;
            Debug.Log("Chest opened by player: " + collision.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isNear = false;
        Debug.Log("Player left chest area: " + collision.name);
    }
    public void ToggleCanvas()
    {
        chestCanvas.SetActive(!chestCanvas.activeSelf);
        PlayerCanvas.SetActive(!PlayerCanvas.activeSelf);
       //baseCC.PausePlayer(chestCanvas.activeSelf);
    }
}
