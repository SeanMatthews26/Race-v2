using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTime;
    [SerializeField] GameObject raceController;

    private float time = 0.0f;
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
        if (raceController.GetComponent<RaceController>().raceStarted) 
        {
            time -= 1 * Time.deltaTime;
            timerText.text = time.ToString("0.0");
            Debug.Log(timerText);
        }
    }
}
