using UnityEngine;

public class Brick : MonoBehaviour {

    #region public Properties

    public Sprite[] hitsprites;
    public static int brickCount = 0;
    public GameObject smoke;

    #endregion

    #region Private Properties

    private int timesHit;
    private LevelManager LevelManager;
    private bool isBreakable;

    #endregion

    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    public void Start()
    {
        isBreakable = (this.tag == "Breakable");

        // Keep track of breakable bricks
        if (isBreakable)
        {
            brickCount++;
        }

        timesHit = 0;
        LevelManager = GameObject.FindObjectOfType<LevelManager>();

    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {

    }

    /// <summary>
    /// When the ball hits the brick, increment times hit by 1
    /// </summary>
    public void OnCollisionEnter2D(Collision2D col)
    {
        // if the object hit is breakable, call HandleHits method
        if (isBreakable)
        {
            HandleHits();
        }
    }

    /// <summary>
    /// Handles all hits between the brick and the ball
    /// </summary>
    public void HandleHits()
    {
        timesHit++;
        int maxHits = hitsprites.Length + 1;

        // If times hit exceeds or equates to maxhits
        // Else call LoadSprites method
        if (timesHit >= maxHits)
        {
            brickCount--;
            LevelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    /// <summary>
    /// Create smoke particles
    /// </summary>
    public void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    /// <summary>
    /// Changes the brick sprites
    /// </summary>
    public void LoadSprites()
    {
        int SpriteIndex = timesHit - 1;

        // If hitsprites is not null 
        if (hitsprites[SpriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitsprites[SpriteIndex];
        }
    }

    #endregion
}