using UnityEngine;
using System.Linq;

public class RaceManager : MonoBehaviour
{
    [SerializeField] Racer[] racers;
    [SerializeField] private RaceSettings _raceSettings;

    private RaceStage _raceStage;
    private int _racerPosition;

    void Start()
    {
        _raceStage = RaceStage.Start;
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     ResetRace();
        // }
        // else if (Input.GetKeyDown(KeyCode.Return))
        // {
        //     StartRace();
        // }

        if (Input.GetMouseButtonUp(0))
        {
            switch (_raceStage)
            {
                case RaceStage.Start:
                    StartRace();
                    break;
                case RaceStage.Running:
                    ResetRace();
                    if (_raceSettings.autoPlay) StartRace();
                    break;
                case RaceStage.End:
                    ResetRace();
                    if (_raceSettings.autoPlay) StartRace();
                    break;
            }
        }
        if (_raceStage == RaceStage.Running)
        {
            AssignPosition();
            CheckRaceStatus();
        }
    }

    private void ResetRace()
    {
        foreach (Racer racer in racers)
        {
            racer.Reset();
        }
        _racerPosition = 1;
        _raceStage = RaceStage.Start;
    }

    void StartRace()
    {
        _raceStage = RaceStage.Running;
        foreach (Racer racer in racers)
        {
            racer.Race();
        }
    }

    void AssignPosition()
    {

        foreach (Racer racer in racers)
        {
            if (racer.IsFinished && racer.Position == 0)
            {
                racer.Position = _racerPosition++;
            }
        }
    }

    void EndRace()
    {
        _raceStage = RaceStage.End;
    }

    void CheckRaceStatus()
    {
        if (racers.All(racer => racer.IsFinished))
        {
            Debug.Log("__________________________");
            EndRace();
            if (_raceSettings.autoPlay)
            {
                Invoke("ResetAndStart", 2);
            }
        }
    }

    void ResetAndStart()
    {
        ResetRace();
        StartRace();
    }
}
