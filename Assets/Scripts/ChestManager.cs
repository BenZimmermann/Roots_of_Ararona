using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour

{
    [SerializeField] private float interactionDistance = 2f;
    //public float interactionDistance = 0.5f;
    private Transform player;

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
    }

    void Update()
    {
        //if (player == null || Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
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
                }
                else
                {
                    Debug.Log("Zu weit weg von der Chest.");
                }
            }
        }
    }
}
