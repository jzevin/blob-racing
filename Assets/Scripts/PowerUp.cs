using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject sprite;
    public RaceSettings raceSettings;
    private SpriteRenderer _spriteRenderer => sprite.GetComponent<SpriteRenderer>();
    private float _boostValue;

    void Awake()
    {
        // sprite = transform.GetChild(0).gameObject;
        _boostValue = Random.Range(-9f, 9f);
        setColor();
    }
    void Start()
    {;
        Invoke("DestroyPowerUp", 10);
    }
    public float getBoostValue()
    {
        return _boostValue;
    }

    void DestroyPowerUp()
    {
        Destroy(gameObject);
    }

    void setColor() {
        if (_boostValue < 0)
        {
            _spriteRenderer.color = raceSettings.negativePowerUpColor;
        }
        else
        {
            _spriteRenderer.color = raceSettings.positivePowerUpColor;
        }
    }
}
