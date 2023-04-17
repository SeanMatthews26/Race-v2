using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float startTime;
    [SerializeField] GameObject raceController;
    [SerializeField] TextMeshProUGUI winText;

    public float time = 0.0f;
    private TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        time = startTime;
        timerText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (raceController.GetComponent<RaceController>().raceOn) 
        {
            if(time > 0.0f) 
            {
                time -= 1 * Time.deltaTime;
            }
            else if(time < 0.0f) 
            {
                time = 0.0f;
                raceController.GetComponent<RaceController>().LoseRace();
            }
            timerText.text = time.ToString("0.0");
        }
    }
}
