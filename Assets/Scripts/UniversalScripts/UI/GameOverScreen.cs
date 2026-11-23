using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] public Canvas gameOverCanvas;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private AudioSource backgroundMusic;
    public AudioSource gameOverSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetUIReferencesAndListeners();
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverCanvas.enabled)
        {
            backgroundMusic.Pause(); 
        }
    }
    private void GetUIReferencesAndListeners()
    {
        GameObject gameOverScreen = GameObject.Find("GameOverScreen");
        if (gameOverScreen != null)
        {
            gameOverCanvas = gameOverScreen.GetComponent<Canvas>();
        }
        GameObject continu = GameObject.Find("GOSContinueButton"); // GOS = Game Over Screen (For differentiating the buttons between the pause screen tbh)
        if (continu != null)
        {
            restartButton = continu.GetComponent<Button>();
        }

        GameObject quit = GameObject.Find("GOSQuitButton");
        if (quit != null)
        {
            quitButton = quit.GetComponent<Button>();
        }

        backgroundMusic = GameObject.Find("Background Music").GetComponent<AudioSource>();
        gameOverSFX = GameObject.Find("GameOverSFX").GetComponent<AudioSource>();

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
