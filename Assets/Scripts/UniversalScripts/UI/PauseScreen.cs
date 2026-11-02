using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseScreen : MonoBehaviour
{
   [SerializeField] private Canvas pauseCanvas;
   [SerializeField] private Button continueButton;
   [SerializeField] private Button quitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetUIReferencesAndListeners();
        pauseCanvas.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Pause();
        }
    }

    private void GetUIReferencesAndListeners()
    {
        GameObject pauseScreen = GameObject.Find("PauseScreen");
        if (pauseScreen != null)
        {
            pauseCanvas = pauseScreen.GetComponent<Canvas>();   
        }
        GameObject resume = GameObject.Find("PSContinueButton"); // PS = Pause Screen; just differentiates it from the Game Over Screen's buttons that do the same things really
        if(resume != null)
        {
            continueButton = resume.GetComponent<Button>();
        }

        GameObject quit = GameObject.Find("PSQuitButton");
        if(quit != null)
        {
            quitButton = quit.GetComponent<Button>();
        }

        continueButton.onClick.AddListener(Continue);
        quitButton.onClick.AddListener(QuitToMenu);

    }

    private void Pause()
    {
        Time.timeScale = 0;
        pauseCanvas.enabled = true;
    }

    private void Continue()
    {
        Time.timeScale = 1;
        pauseCanvas.enabled = false;
    }

    private void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Change the name to whatever we call the main menu later in development.
    }
}
