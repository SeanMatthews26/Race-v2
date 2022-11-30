using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaceStarter : MonoBehaviour
{
    [SerializeField] GameObject raceController;
    [SerializeField] GameObject other;
    private RaceController rc;
    private GameObject raceStarter;

    // Start is called before the first frame update
    void Start()
    {
        rc = raceController.GetComponent<RaceController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter()
    {
        rc.RaceStarted();

    }
}
