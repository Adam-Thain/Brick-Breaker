using UnityEngine;

public class LoseCollider : MonoBehaviour {
    
    #region Private Properties

    private LevelManager levelManager;

    #endregion
    
    #region Public Methods

    /// <summary>
    /// When an object enters a trigger collider
    /// </summary>
    /// <param name="collision"> Object of collision </param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose Screen");
    }

    /// <summary>
    /// When an object enters a trigger collider
    /// </summary>
    /// <param name="collision"> Object of collision </param>
    public void OnCollisonEnter2D(Collider2D collision)
    {
        print("Collision");
    }

    #endregion
}