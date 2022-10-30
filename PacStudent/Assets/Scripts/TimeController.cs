using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeController : MonoBehaviour
{

    public Text timeDisplay;
    private float elapsedTime;
    private TimeSpan timePlaying;

    // Start is called before the first frame update
    void Start()
    {
        timeDisplay.text = "Time: 00:00:00";
        elapsedTime = 0.0f;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer() {

        while (true) {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string displayText = "Time: " + timePlaying.ToString("mm':'ss':'ff");
            timeDisplay.text = displayText;
            yield return null;
        }
    }

}
