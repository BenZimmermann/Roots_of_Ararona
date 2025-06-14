using UnityEngine;

public class PauseMenueManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private AudioClip InvOpen;
    private BaseCharacterController baseCC;
    private AudioSource audioSource;


    private void Start()
    {
        baseCC = FindObjectOfType<BaseCharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TogglePauseMenu()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        // Play the inventory open sound when the pause menu is toggled
        audioSource.clip = InvOpen;
        audioSource.Play();
        baseCC.PausePlayer(pauseMenuUI.activeSelf);
    }
}
