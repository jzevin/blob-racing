using System;
using UnityEngine;

public enum RaceStage
{
    Start,
    Running,
    End
}

[CreateAssetMenu(fileName = "RaceSettings", menuName = "Scriptable Objects/RaceSettings")]
public class RaceSettings : ScriptableObject
{
    public float minSpeedRange = 6f;
    public float maxSpeedRange = 9f;
    public float startX = -5f;
    public float endX = 5f;
    public float chanceToChangeSpeed = 3;

    public Color defaultColor;
    public Color firstPlaceColor;
    public Color secondPlaceColor;
    public Color thirdPlaceColor;

    public bool autoPlay = false;


    public Color negativePowerUpColor = Color.red;
    public Color positivePowerUpColor = Color.green;
}
