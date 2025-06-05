
using UnityEngine;
using UnityEngine.InputSystem;

public class ChestManager : MonoBehaviour

{
    [SerializeField] private float interactionDistance = 2f;
    //public float interactionDistance = 0.5f;
    private Transform player;
    private InventoryManager inventory;
    public ItemClass AddItem1;

    public Sprite openSprite;
    public Sprite closedSprite;

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;
        else
            Debug.LogWarning("Spieler mit Tag 'Player' nicht gefunden.");
        inventory = FindObjectOfType<InventoryManager>();
        if (inventory == null)
            Debug.LogWarning("InventoryManager nicht gefunden!");

    }

    public void Update()
    {
        //if (player == null || Mouse.current == null) return;

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject == gameObject)
            {
                float distance = Vector2.Distance(transform.position, player.position);
                Debug.Log("Distanz zum Spieler: " + distance);

                if (distance <= interactionDistance - 1.5f)
                {
                    Debug.Log("Chest geöffnet!");
                    isOpen = true;
                    spriteRenderer.sprite = openSprite;
                    if (inventory != null && AddItem1 != null)
                    {
                        bool success = inventory.Add(AddItem1);
                        if (success)
                            Debug.Log("Item hinzugefügt: " + AddItem1.itemName);
                        else
                        {
                            Debug.Log("Inventar voll oder Item nicht stapelbar: " + AddItem1.itemName);
                        }
                    }

                }
            }
            else
            {
                Debug.Log("Zu weit weg von der Chest.");
            }
        }
    }
}

