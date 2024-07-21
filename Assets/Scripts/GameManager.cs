using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton
{
    private int lives = 3;

    protected new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
       
    }

    private void Start()
    {
        Debug.Log("Player lives: " + lives);
    }

    public void OnPlayerDeath()
    {
        lives--;

        Debug.Log("Player lives: " + lives);

        if (lives == 0)
        {
            Debug.Log("Dead player");
            Destroy(gameObject);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
