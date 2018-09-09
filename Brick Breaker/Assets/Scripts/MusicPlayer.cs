using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    #region Constructor

    /// <summary>
    /// Call when the game starts for the first time
    /// </summary>
    public void Awake()
    {

        // if an instance of the music player exists, destroy the new instance
        // else set instance to this and dont destroy the player
        if (instance != null)
        {
            // destroy an already existing instance of the music player
            Destroy(gameObject);
        }
        else
        {
            // set the instance to this object
            instance = this;

            // dont destroy this music player
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {

    }

    #endregion
}
