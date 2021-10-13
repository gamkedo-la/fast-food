using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingPatienceButtonCheat : ButtonScript
{
    [SerializeField] GameObject customerManager;

    public override void HandleButtonClick()
    {
        for (int i = 0; i < customerManager.GetComponent<CustomerManagerScript>().listOfCustomers.Count; i++)
        {
            if (customerManager.GetComponent<CustomerManagerScript>().listOfCustomersPatienceSliders[i].value > 
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomersPatienceSliders[i].GetComponent<PatienceTimerSliderScript>().timerDuration / 2)
            {
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomersPatienceSliders[i].value = 
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomersPatienceSliders[i].GetComponent<PatienceTimerSliderScript>().timerDuration / 2;
                return;
            }
        }
    }
}
