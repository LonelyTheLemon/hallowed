using UnityEngine;
using UnityEngine.SceneManagement;
using Grimoire;

public class PauseMenu : MonoBehaviour
{
    public GameObject mouseLookScriptObject;
    public GameObject toolTipPrompt; // Reference to the ToolTipPrompt object
    
    [SerializeField] CanvasGroup menu;
    [SerializeField] CanvasGroup[] settingsMenu;

    enum MenuLevel {
        None,
        Main,
        Settings,
        Credits,
    }

    MenuLevel currentMenu = MenuLevel.None;
    [SerializeField] bool isGame = false;

    KeyCode pauseKey = KeyCode.None;

    void Start() {
        if(isGame) {
            menu.gameObject.SetActive(true);
            menu.Hide();
            currentMenu = MenuLevel.None;
        }
        else {
            currentMenu = MenuLevel.Main;
        }

        foreach(CanvasGroup group in settingsMenu) {
            group.gameObject.SetActive(true);
            group.Hide();
        }

        #if UNITY_EDITOR
        pauseKey = KeyCode.BackQuote;
        #else
        pauseKey = KeyCode.Escape;
        #endif
    }

    void Update() {
        if (Input.GetKeyDown(pauseKey)) {
            SwitchMenu();
        }
    }

    public void SwitchMenu() {
        switch (currentMenu) {
            case MenuLevel.None:
                menu.Show();
                DisableMouseLookScript();
                currentMenu++;
                ToggleToolTipPrompt(false); // Disable tooltip when menu is shown
                break;
            case MenuLevel.Main:
                if(isGame) {
                    menu.Hide();
                    EnableMouseLookScript();
                    currentMenu--;
                    ToggleToolTipPrompt(true); // Enable tooltip when menu is hidden
                }
                break;
            case MenuLevel.Settings:
                settingsMenu[0].Hide();
                menu.Show();
                currentMenu--;
                break;
            case MenuLevel.Credits:
                settingsMenu[1].Hide();
                settingsMenu[0].Show();
                currentMenu--;
                break;
        }
    }

    public void ShowMenuSettings() {
        currentMenu = MenuLevel.Settings;
        menu.Hide();
        settingsMenu[0].Show();
        ToggleToolTipPrompt(false); // Disable tooltip when in settings
    }

    public void ShowMenuCredits() {
        currentMenu = MenuLevel.Credits;
        settingsMenu[0].Hide();
        settingsMenu[1].Show();
        ToggleToolTipPrompt(false); // Disable tooltip when in credits
    }

    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Player has Quit the game");
    }

    void EnableMouseLookScript() {
        MouseLook mouseLookScript = mouseLookScriptObject.GetComponent<MouseLook>();
        if (mouseLookScript != null) {
            mouseLookScript.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void DisableMouseLookScript() {
        MouseLook mouseLookScript = mouseLookScriptObject.GetComponent<MouseLook>();
        if (mouseLookScript != null) {
            mouseLookScript.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Method to toggle the ToolTipPrompt
    void ToggleToolTipPrompt(bool isActive) {
        if (toolTipPrompt != null) {
            toolTipPrompt.SetActive(isActive);
        }
    }
}
