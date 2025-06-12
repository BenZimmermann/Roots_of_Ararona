
//veraltet und nicht mehr in Benutzung
//--------------------------------------
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.UI;

//public class ChestManager : MonoBehaviour

//{
//    //  [SerializeField] private GameObject chestCanvas;
//    //  [SerializeField] private GameObject PlayerCanvas;
//    //  private BaseCharacterController baseCC;
//    //Distance to player to interact with the chest
//    [SerializeField] private float interactionDistance = 2f;
//    //public float interactionDistance = 0.5f;
//    private Transform player;
//    // Reference to the InventoryManager
//    private InventoryManager inventory;
//    public ItemClass AddItem1;
//    //sprite for the chest when open and closed
//    public Sprite openSprite;
//    public Sprite closedSprite;

//    private SpriteRenderer spriteRenderer;
//    // Flag to check if the chest is open
//    private bool isOpen = false;
//    void Start()
//    {
//        //baseCC = FindObjectOfType<BaseCharacterController>();
//        // Get the SpriteRenderer component and set the initial sprite
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        spriteRenderer.sprite = closedSprite;
//        // Find the player object by tag
//        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
//        // Check if the player object was found and assign its transform
//        if (playerObj != null)
//            player = playerObj.transform;
//        else
//            Debug.LogWarning("Spieler mit Tag 'Player' nicht gefunden.");
//        // Find the InventoryManager in the scene
//        inventory = FindObjectOfType<InventoryManager>();
//        if (inventory == null)
//            Debug.LogWarning("InventoryManager nicht gefunden!");

//    }


//    public void Update()
//    {
//        //if (player == null || Mouse.current == null) return;
//        // Check if the right mouse button was pressed
//        if (Mouse.current.rightButton.wasPressedThisFrame)
//        {
//            //read the mouse position in world coordinates
//            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
//            Collider2D hit = Physics2D.OverlapPoint(mousePos);
//            // Check if the hit object is the chest and if the player is within interaction distance
//            if (hit != null && hit.gameObject == gameObject)
//            {
//                float distance = Vector2.Distance(transform.position, player.position);
//                Debug.Log("Distanz zum Spieler: " + distance);
//                //if the distance is less than or equal to the interaction distance, open the chest
//                if (distance <= interactionDistance - 1.5f)
//                {
//                    Debug.Log("Chest geöffnet!");
//                    // Toggle the chest state
//                    //ToggleCanvas();
//                    isOpen = true;
//                    spriteRenderer.sprite = openSprite;
//                    // Add the item to the inventory if it is not null
//                    if (inventory != null && AddItem1 != null)
//                    {
//                        // Check if the item can be added to the inventory
//                        bool success = inventory.Add(AddItem1);
//                        // Log the result of adding the item
//                        if (success)
//                            Debug.Log("Item hinzugefügt: " + AddItem1.itemName);
//                        else
//                        {
//                            Debug.Log("Inventar voll oder Item nicht stapelbar: " + AddItem1.itemName);
//                        }
//                    }

//                }
//            }
//            else
//            {
//                Debug.Log("Zu weit weg von der Chest." + mousePos);
//            }
//        }
//    }
//    //public void ToggleCanvas()
//    //{
//    //   chestCanvas.SetActive(!chestCanvas.activeSelf);
//    //   PlayerCanvas.SetActive(!PlayerCanvas.activeSelf);
//    //   baseCC.PausePlayer(chestCanvas.activeSelf);
//    //}
//}



