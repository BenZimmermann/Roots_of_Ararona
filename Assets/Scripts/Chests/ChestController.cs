using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    // This script controls the chest functionality, including opening and closing the chest, and managing the inventory.
    private PlayerControls playerControls;
    private bool isOpen = false;
    private bool isNear = false;

    private BaseCharacterController baseCC;
    [SerializeField] private GameObject chestCanvas;
    //the PlayerCanvas should nor be a serialized field, because we need to find it through all scenes
    private GameObject PlayerCanvas;
    //audio
    [SerializeField] private AudioClip ChestOpen;
    private AudioSource audioSource;
    //references to the InventoryManager
    private InventoryManager inventory;
    //public ItemClass AddItem1;

    //sprite for the chest when open and closed
    public Sprite openSprite;
    public Sprite closedSprite;
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// method to check if the chest is open or closed.
    /// </summary>

    public bool IsOpen()
    {
        return isOpen;
    }

    private void Start()
    {
        //find the CharacterController in the scene
        baseCC = FindObjectOfType<BaseCharacterController>();
        //find the InventoryManager in the scene
        PlayerCanvas = GameObject.Find("InventoryPanel");
        spriteRenderer = gameObject.transform.parent.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer.sprite = closedSprite;
        var allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (var obj in allObjects)
        {
            if (obj.name == "InventoryPanel")
            {
                PlayerCanvas = obj;
                break;
            }
        }

        if (PlayerCanvas == null)
            Debug.Log("InventoryPanel nicht da.");

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
        // Play the chest open sound
        audioSource.clip = ChestOpen;
        audioSource.Play();
        // Toggle the chest state
        isOpen = !isOpen;
        spriteRenderer.sprite = openSprite;
        }
    //KI begin
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
    //KI end
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
        // Check if the colliding object is the player
        isNear = false;
        Debug.Log("Player left chest area: " + collision.name);
    }

    /// <summary>
    /// toggle the canvas for the chest and the player inventory.
    /// <summary>
    public void ToggleCanvas()
    {
        chestCanvas.SetActive(!chestCanvas.activeSelf);
        PlayerCanvas.SetActive(!PlayerCanvas.activeSelf);
        baseCC.PausePlayer(chestCanvas.activeSelf);
    }
}
