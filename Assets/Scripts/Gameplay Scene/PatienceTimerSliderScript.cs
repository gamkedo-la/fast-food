using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatienceTimerSliderScript : MonoBehaviour
{

    public bool isActive = false;

    public float timerDuration;
    [SerializeField] private float minimumTimerDuration = 10.0f;
    [SerializeField] private float maximumTimerDuration = 20.0f;

    [SerializeField] private Image fill;
    private Color greenColor;
    private Color yellowColor;
    private Color redColor;

    public Gradient gradient;

    [SerializeField] GameObject parentCustomerObject;

    // Start is called before the first frame update
    void Start()
    {        
        InitializeTimer();

        greenColor = Color.green;
        yellowColor = Color.yellow;
        redColor = Color.red;

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
                float percentageOfTimerLeft = PercentageOfTimerLeft();
                float adjustedLerpValue;
                if (percentageOfTimerLeft < 0.5f)
                {
                    adjustedLerpValue = percentageOfTimerLeft * 2;
                    fill.color = Color.Lerp(greenColor, yellowColor, adjustedLerpValue);
                }
                else
                {
                    
                    parentCustomerObject.GetComponent<CustomerOrderingScript>().losingPatience = true;
                    EventManagerScript.customerLosingPatienceEvent.Invoke();
                    adjustedLerpValue = (percentageOfTimerLeft - 0.5f) * 2;
                    fill.color = Color.Lerp(yellowColor, redColor, adjustedLerpValue);
                }

            }
        }
    }

    public float PercentageOfTimerLeft()
    {
        float timeLeft = timerDuration - gameObject.GetComponent<Slider>().value;
        float percentageOfTimerLeft = timeLeft / timerDuration;
        if (percentageOfTimerLeft < 0)
        {
            percentageOfTimerLeft = 0.0f;
        }
        return percentageOfTimerLeft;
    }
}
