using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WinScreen : MonoBehaviour
{
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button quitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetUIReferencesAndListeners();
        winCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetUIReferencesAndListeners()
    {
        GameObject winScreen = GameObject.Find("WinScreen");
        if (winScreen != null)
        {
            winCanvas = winScreen.GetComponent<Canvas>();
        }
        GameObject resume = GameObject.Find("WINContinueButton");
        if (resume != null)
        {
            continueButton = resume.GetComponent<Button>();
        }

        GameObject quit = GameObject.Find("WINQuitButton");
        if (quit != null)
        {
            quitButton = quit.GetComponent<Button>();
        }

        continueButton.onClick.AddListener(Continue);
        quitButton.onClick.AddListener(QuitToMenu);
    }

    private void Continue()
    {
        // Proceed to the checklist scene

        //SceneManager.LoadScene("ChecklistScene");
    }

    private void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Change the name to whatever we call the main menu later in development.
    }
}
