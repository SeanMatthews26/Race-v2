using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    [SerializeField] GameObject[] checkPointMarker;

    [SerializeField] GameObject checkPoint;

    private Vector3[] checkPointMarkerPos;

    private quaternion[] checkPointMarkerRot;

    public bool raceStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        checkPointMarkerPos = new Vector3[3];
        checkPointMarkerRot = new quaternion[3];

        for (int i = 0; i < 3 ; i++)
        {
            checkPointMarkerPos[i] = checkPointMarker[i].transform.position;
            Debug.Log(checkPointMarkerPos[i]);
            checkPointMarkerRot[i] = checkPointMarker[i].transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaceStarted()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(checkPoint, checkPointMarkerPos[i], checkPointMarkerRot[i]);
        }
        Debug.Log("Nice");
    }
}
