using UnityEngine;

public class Racer : MonoBehaviour
{


    private float speed;
    private bool shouldMove = false;
    private int _position = 0;
    private SpriteRenderer _blobSpriteRenderer;

    private SpriteRenderer _medalSpriteRenderer;

    public bool IsFinished { get; private set; }

    public int Position {
        get => _position;
        set {
            _position = value;
            if (_position > 0)
            {
                AnnouncePosition();
                setPositionColor();
            }
        }
    }


    public RaceSettings raceSettings;
    public GameObject medalSprite;
    public GameObject blobSprite;



        void Start()
    {
        speed = raceSettings.minSpeedRange;
        Position = 0;
        _medalSpriteRenderer = medalSprite.GetComponent<SpriteRenderer>();
        _blobSpriteRenderer = blobSprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (shouldMove)
        {
            Move();
        }
    }

    // <summary>
    /// Moves the racer based on the current speed and race settings.
    // </summary>
    void Move()
    {
        if (transform.position.x < raceSettings.endX)
        {
            if(Random.Range(0f, 100f) < raceSettings.chanceToChangeSpeed)
            {
                changeSpeed();
            }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > raceSettings.endX)
            {
                transform.position = new Vector3(raceSettings.endX, transform.position.y, 0);
                shouldMove = false;
                IsFinished = true;
            }
        }
    }

    void changeSpeed() {
        speed = Random.Range(raceSettings.minSpeedRange, raceSettings.maxSpeedRange);
    }

    public void Reset () {
        transform.position = new Vector3(raceSettings.startX, transform.position.y, 0);
        speed = raceSettings.minSpeedRange;
        shouldMove = false;
        Position = 0;
        IsFinished = false;
        _blobSpriteRenderer.color = raceSettings.defaultColor;
    }

    public void Race()
    {
        shouldMove = true;
        _medalSpriteRenderer.enabled = false;
    }

    void AnnouncePosition()
    {
        Debug.Log($"Racer {name} finished in position {Position}");
    }

    void setPositionColor() {

        if (Position < 4)
        {
            _medalSpriteRenderer.enabled = true;
        }
        
        if (Position == 1)
        {
           _medalSpriteRenderer.color = raceSettings.firstPlaceColor;
        }
        else if (Position == 2)
        {
           _medalSpriteRenderer.color = raceSettings.secondPlaceColor;
        }
        else if (Position == 3)
        {
           _medalSpriteRenderer.color = raceSettings.thirdPlaceColor;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            float boost = other.gameObject.GetComponent<PowerUp>().getBoostValue();
            // Debug.Log($"Racer {name} picked up a power up and got a boost of {boost}");
            speed += boost;
            Invoke("checkSpeed", 0.25f);
        }
    }

    void checkSpeed() {
        if (speed < raceSettings.minSpeedRange)
        {
            speed = raceSettings.minSpeedRange;
        }
    }
}
