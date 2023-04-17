using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    [SerializeField] GameObject[] checkPoint;
    [SerializeField] Material activeMat;
    [SerializeField] Material normalMat;
    [SerializeField] GameObject racer;
    [SerializeField] Collider player;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI loseText;
    [SerializeField] GameObject raceStarter;
    [SerializeField] Timer timer;
    [SerializeField] int laps;

    public bool raceOn = false;
    public int checkPointsPassed = 0;
    private int lapsDone = 0;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        loseText.enabled = false;
        ResetRace();
    }

    private void ResetRace()
    {
        timerText.enabled = false;
        raceStarter.SetActive(true);
        checkPointsPassed = 0;

        timer.GetComponent<Timer>().time = timer.GetComponent<Timer>().startTime;

        for (int i = 0; i < checkPoint.Length; i++)
        {
            checkPoint[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCheckPoints();
        CheckPointColour();
    }

    private void UpdateCheckPoints()
    {
        for (int i = 0; i < checkPoint.Length; i++)
        {
            if (checkPoint[i].GetComponent<CheckPoint>().passed)
            {
                if (checkPointsPassed == i)
                {
                    checkPointsPassed++;
                }
                else
                {
                    checkPoint[i].GetComponent<CheckPoint>().passed = false;
                }
            }
        }

        //Laps
        if(raceOn)
        {
            if (checkPointsPassed >= checkPoint.Length)
            {
                lapsDone++;
                checkPointsPassed = 0;

                if(lapsDone == laps)
                {
                    WinRace();
                }
            }
        }
    }

    private void WinRace()
    {
        raceOn = false;
        winText.enabled = true;
        ResetRace();
    }

    public void RaceStarted()
    {
        raceStarter.SetActive(false);
        raceOn= true;
        winText.enabled = false;
        loseText.enabled = false;
        timerText.enabled = true;
        checkPointsPassed = 0;
        lapsDone = 0;

        for (int i = 0; i < checkPoint.Length; i++)
        {
            CheckPointColour();
            checkPoint[i].SetActive(true);
        }
    }

    void CheckPointColour()
    {
       if(raceOn)
        {
            for (int i = 0; i < checkPoint.Length; i++)
            {
                checkPoint[i].GetComponentInChildren<MeshRenderer>().material = normalMat;
            }
            checkPoint[checkPointsPassed].GetComponentInChildren<MeshRenderer>().material = activeMat;
        }
    }

    public void LoseRace()
    {
        raceOn = false;
        loseText.enabled = true;
        ResetRace();
    }
}
