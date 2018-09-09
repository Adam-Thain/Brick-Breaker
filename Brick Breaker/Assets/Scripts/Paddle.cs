using UnityEngine;

public class Paddle : MonoBehaviour
{
    #region Public Properties

    public bool autoPlay = false;

    #endregion

    #region Private Properties

    private Ball ball;

    #endregion

    #region Constructor

    /// <summary>
    /// Call when the game starts for the first time
    /// </summary>
    public void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {

        // If autoplay is not enabled, play the game manually
        // Else play the game automatically
        if (!autoPlay)
            MoveWithMouse();
        else
            AutoPlay();
    }

    /// <summary>
    /// Paddle will follow the ball automatically on the X axis
    /// </summary>
    public void AutoPlay()
    {

        // Create new vector 3 for the paddle position
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        // Create new vector 3 for the ball position
        Vector3 ballPos = ball.transform.position;

        // Clamp the paddle X position to the X position of the ball 
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);

        // Set the transform position of the paddle to paddlepos
        this.transform.position = paddlePos;
    }

    /// <summary>
    /// Paddle will follow the mouse on the X axis
    /// </summary>
    public void MoveWithMouse()
    {

        // Create new vector 3 for the paddle position
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        // Create new vector 3 for the ball position
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        // Clamp the paddle X position to the X position of the ball 
        paddlePos.x = mousePosInBlocks;

        // Set the transform position of the paddle to paddlepos
        this.transform.position = paddlePos;
    }

    #endregion
}