using UnityEngine;

public class PauseMenueManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
   // [SerializeField] private GameObject closeChest;
    private BaseCharacterController baseCC;

    private void Start()
    {
        baseCC = FindObjectOfType<BaseCharacterController>();
    }

    public void TogglePauseMenu()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        //closeChest.SetActive(!pauseMenuUI.activeSelf);
        baseCC.PausePlayer(pauseMenuUI.activeSelf);
    }
}
