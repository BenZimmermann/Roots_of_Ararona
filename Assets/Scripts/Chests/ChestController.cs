using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private PlayerControls playerControls;
    private bool isOpen = false;
    private bool isNear = false;
    //-----------------------------------
    private BaseCharacterController baseCC;
    [SerializeField] private GameObject chestCanvas;
   /* [SerializeField]*/ private GameObject PlayerCanvas;

    [SerializeField] private AudioClip ChestOpen;
    private AudioSource audioSource;

    private InventoryManager inventory;
    public ItemClass AddItem1;

    //sprite for the chest when open and closed
    public Sprite openSprite;
    public Sprite closedSprite;

    private SpriteRenderer spriteRenderer;

    //-----------------------------------

    public bool IsOpen()
    {
        return isOpen;
    }
    private void Start()
    {
        baseCC = FindObjectOfType<BaseCharacterController>();
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
            Debug.LogError("InventoryPanel konnte nicht gefunden werden. Stelle sicher, dass der Name exakt stimmt und das Objekt nicht komplett entladen ist.");

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
        audioSource.clip = ChestOpen;
        audioSource.Play();
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

    /// <summary>
    /// 
    
    public void ToggleCanvas()
    {
        chestCanvas.SetActive(!chestCanvas.activeSelf);
        PlayerCanvas.SetActive(!PlayerCanvas.activeSelf);
        baseCC.PausePlayer(chestCanvas.activeSelf);
    }
}
