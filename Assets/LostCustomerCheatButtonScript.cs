using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostCustomerCheatButtonScript : ButtonScript
{
    [SerializeField] GameObject customerManager;

    public override void HandleButtonClick()
    {
        for (int i = 0; i < customerManager.GetComponent<CustomerManagerScript>().listOfCustomers.Count; i++)
        {
            if (customerManager.GetComponent<CustomerManagerScript>().listOfCustomersPatienceSliders[i].value > 0)
            {
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomersPatienceSliders[i].value = 0;
                EventManagerScript.lostCustomerEvent.Invoke();
                return;
            }
        }
    }
}
