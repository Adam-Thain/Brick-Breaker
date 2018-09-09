using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    #region Public Methods

    /// <summary>
    /// Load level
    /// </summary>
    /// <param name="name"> name of level </param>
    public void LoadLevel(string name)
    {

        // Set the brick count to zero
        Brick.brickCount = 0;

        // Load the level
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// Request to quit the current game
    /// </summary>
	public void QuitRequest()
    {
        // Quit the game
        Application.Quit();
    }

    /// <summary>
    /// Load the next level
    /// </summary>
    public void LoadNextLevel()
    {

        // Set the brick count to zero
        Brick.brickCount = 0;

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// When a brick is destroyed
    /// </summary>
    public void BrickDestroyed()
    {
        // if the last brick in the level is destroyed
        if (Brick.brickCount <= 0)
        {
            LoadNextLevel();
        }
    }

    #endregion
}
