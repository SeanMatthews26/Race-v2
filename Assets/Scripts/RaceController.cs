using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    [SerializeField] GameObject[] checkPoint;
    [SerializeField] Material yellowMat;
    [SerializeField] GameObject racer;
    [SerializeField] Collider player;


    private int checkPointsPassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < checkPoint.Length; i++)
        {
            checkPoint[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckPointColour();
        if (checkPoint[0].GetComponent<CheckPoint>().OnTriggerEnter(player))
        {
            Debug.Log("Hello");
        }
    }

    public void RaceStarted()
    {
        for (int i = 0; i < checkPoint.Length; i++)
        {
            checkPoint[i].SetActive(true);
        }
    }

    void CheckPointColour()
    {
        checkPoint[checkPointsPassed].GetComponentInChildren<MeshRenderer>().material = yellowMat;
    }
}
