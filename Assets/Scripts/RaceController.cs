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
    [SerializeField] TextMeshProUGUI timer;

    public bool raceStarted = false;
    public int checkPointsPassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer.enabled = false;

        for (int i = 0; i < checkPoint.Length; i++)
        {
            checkPoint[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       for(int i = 0; i < checkPoint.Length;i++) 
        {
            if (checkPoint[i].GetComponent<CheckPoint>().passed)
            {
               if(checkPointsPassed == i)
                {
                    checkPointsPassed++;
                    CheckPointColour();
                }
                else
                {
                    Debug.Log("WrongCheckPoint");
                }
            }
        }
    }

    public void RaceStarted()
    {
        raceStarted= true;
        timer.enabled = true;

        for (int i = 0; i < checkPoint.Length; i++)
        {
            CheckPointColour();
            checkPoint[i].SetActive(true);
            Debug.Log("RaceStarted");
        }
    }

    void CheckPointColour()
    {
        for(int i = 0; i<checkPoint.Length; i++) 
        {
            checkPoint[i].GetComponentInChildren<MeshRenderer>().material = normalMat;
        }
        checkPoint[checkPointsPassed].GetComponentInChildren<MeshRenderer>().material = activeMat;
    }
}
