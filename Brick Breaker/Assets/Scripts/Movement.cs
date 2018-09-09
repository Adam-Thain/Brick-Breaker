using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Public Properties

    /// <summary>
    /// The Direction of travel for invincible bricks
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Left Movement
        /// </summary>
        Left,

        /// <summary>
        /// Right Movement
        /// </summary>
        Right
    }

    // Direction allows MovementDirection to be accessed in the inspector
    public Direction MovementDirection;

    /// <summary>
    /// The Speed of the Object
    /// </summary>
    public float Speed;

    /// <summary>
    /// The Start point on the X axis where the objects position will flip 
    /// </summary>
    public float StartXFlipPoint;

    /// <summary>
    /// The End point on the X axis where the objects position will flip 
    /// </summary>
    public float EndXFlipPoint;

    #endregion

    #region Constructor

    /// <summary>
    /// Call when the game starts for the first time
    /// </summary>
    public void Start()
    {
        
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void FixedUpdate()
    {
        // If the Movement Direction is set to left
        // Else the Movement Direction is set to right
        if(MovementDirection == Direction.Left)
        {
            // If the x position of the object is greater than XFlipPoint
            // Else set the x position to the right of the scene (just off screen)
            if (transform.position.x > StartXFlipPoint)
            {
                transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position = new Vector3(EndXFlipPoint, transform.position.y, 0);
            }
        }
        else
        {
            // If the x position of the object is less than XFlipPoint
            // Else set the x position to the right of the scene (just off screen)
            if (transform.position.x < StartXFlipPoint)
            {
                transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position = new Vector3(EndXFlipPoint, transform.position.y, 0);
            }
        }
    }

    #endregion
}
