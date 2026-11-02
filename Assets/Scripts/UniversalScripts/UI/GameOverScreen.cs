using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] public Canvas gameOverCanvas;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetUIReferencesAndListeners();
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GetUIReferencesAndListeners()
    {
        GameObject gameOverScreen = GameObject.Find("GameOverScreen");
        if (gameOverScreen != null)
        {
            gameOverCanvas = gameOverScreen.GetComponent<Canvas>();
        }
        GameObject restart = GameObject.Find("GOSRestartButton"); // GOS = Game Over Screen (For differentiating the buttons between the pause screen tbh)
        if (restart != null)
        {
            restartButton = restart.GetComponent<Button>();
        }

        GameObject quit = GameObject.Find("GOSQuitButton");
        if (quit != null)
        {
            quitButton = quit.GetComponent<Button>();
        }

        restartButton.onClick.AddListener(Restart);
        quitButton.onClick.AddListener(QuitToMenu);

    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Change the name to whatever we call the main menu later in development.
    }
}
