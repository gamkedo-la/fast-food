using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float duration = 1.0f;
    private float timeRemaining;
    [SerializeField] Text myTextbox;
    // Start is called before the first frame update
    void Start()
    {
        myTextbox.text = duration.ToString();
        SetTimerDuration();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining == 0)
        {
            EventManagerScript.timerRanOutOfTimeEvent.Invoke();
            return;
        }

        else if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int roundedUpTime = Mathf.RoundToInt(timeRemaining);
            myTextbox.text = roundedUpTime.ToString();
        }
        else if (timeRemaining < 0)
        {
            timeRemaining = 0;
            myTextbox.text = timeRemaining.ToString();
        }
    }

    private void SetTimerDuration()
    {
        switch (GameManagerScript.currentLevel)
        {
            case 1:
                duration = 45.0f;
                break;
            case 2:
                duration = 75.0f;
                break;
            case 3:
                duration = 105.0f;
                break;
            case 4:
                duration = 135.0f;
                break;
            case 5:
                duration = 165.0f;
                break;
            case 6:
                duration = 195.0f;
                break;
            case 7:
                duration = 225.0f;
                break;
        }

        if (GameManagerScript.currentCustomerPromptType == CustomerPromptTypeEnumerables.Audio)
        {
            duration += 30.0f;
        }
        timeRemaining = duration;
    }
}
