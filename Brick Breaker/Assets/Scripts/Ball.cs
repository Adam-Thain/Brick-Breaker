using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Public Properties

    public Paddle paddle;

    public int ballSpeed = 7;

    #endregion

    #region Private Varibles

    private bool hasStarted = false;
    private Vector3 paddleToBallVector;
    private Rigidbody2D myScriptsRigidbody2D;

    #endregion

    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    public void Start()
    {

        myScriptsRigidbody2D = GetComponent<Rigidbody2D>();

        // Find paddle Gameobject
        paddle = GameObject.FindObjectOfType<Paddle>();

        // get distance between ball and paddle
        paddleToBallVector = this.transform.position - paddle.transform.position;

    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        if (!hasStarted)
        {

            // Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for mouse press to launch
            if (Input.GetMouseButton(0))
            {
                hasStarted = true;
                myScriptsRigidbody2D.velocity = new Vector2(1f, (float)ballSpeed);
            }
        }
    }


    /// <summary>
    /// When the ball collides with a collider
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (hasStarted)
        {
            Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

            myScriptsRigidbody2D.velocity += tweak;
        }
    }

    #endregion
}