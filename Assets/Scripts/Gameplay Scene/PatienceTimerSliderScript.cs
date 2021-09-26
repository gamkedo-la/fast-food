using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatienceTimerSliderScript : MonoBehaviour
{
    public bool isActive = false;

    private float timerDuration;
    [SerializeField] private float minimumTimerDuration = 10.0f;
    [SerializeField] private float maximumTimerDuration = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        InitializeTimer();
    }

    public void InitializeTimer()
    {
        timerDuration = Random.Range(minimumTimerDuration, maximumTimerDuration);
        gameObject.GetComponent<Slider>().maxValue = timerDuration;
        gameObject.GetComponent<Slider>().value = timerDuration;
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (gameObject.GetComponent<Slider>().value > 0)
            {
                gameObject.GetComponent<Slider>().value -= Time.deltaTime;
            }
        }
    }

    public float PercentageOfTimerLeft()
    {
        float percentageOfTimerLeft = 0.0f;
        float timeLeft = timerDuration - gameObject.GetComponent<Slider>().value;
        percentageOfTimerLeft = timeLeft / timerDuration;
        if (percentageOfTimerLeft < 0)
        {
            percentageOfTimerLeft = 0.0f;
        }
        return percentageOfTimerLeft;
    }
}
