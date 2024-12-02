using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public RaceSettings raceSettings;

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 pickRandomPosition()
    {
        float x = Random.Range(raceSettings.startX, raceSettings.endX);
        float y = Random.Range(-5f, 5f);
        return new Vector2(x, y);
    }

    public void SpawnPowerUp()
    {
        GameObject powerUp = Instantiate(powerUpPrefab, pickRandomPosition(), Quaternion.identity);
        var scale = 0.25f + Math.Abs(powerUp.GetComponent<PowerUp>().getBoostValue()) / 18;
        powerUp.GetComponent<Transform>().localScale = new Vector2(scale, scale);
    }
}
