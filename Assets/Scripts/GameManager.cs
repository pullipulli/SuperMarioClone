using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int lives = 3;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ShowLives()
    {
        Debug.Log("Player lives: " + lives);
    }

    private void Start()
    {
       ShowLives();
    }

    public void IncrementLives()
    {
        lives++;
        ShowLives();
    }

    public void OnPlayerDeath()
    {
        lives--;

        ShowLives();

        if (lives == 0)
        {
            Debug.Log("Dead player");
            Destroy(gameObject);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
