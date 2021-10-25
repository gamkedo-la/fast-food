using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectOrderButtonCheatScript : ButtonScript
{
    [SerializeField] GameObject customerManager;

    public override void HandleButtonClick()
    {
        for (int i = 0; i < customerManager.GetComponent<CustomerManagerScript>().listOfCustomers.Count; i++)
        {
            if (customerManager.GetComponent<CustomerManagerScript>().listOfCustomers[i].GetComponent<CustomerScript>().myStateEnumeration ==
                CustomerStateEnumerations.WaitingForMyOrder ||
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomers[i].GetComponent<CustomerScript>().myStateEnumeration ==
                CustomerStateEnumerations.EnteringRestaurant)
            {
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomers[i].GetComponent<CustomerScript>().isProcessingOrder = true;
                EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                EventManagerScript.anyOrderSubmissionEvent.Invoke();
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomers[i].GetComponent<CustomerScript>().isProcessingOrder = false;

                return;
            }
        }
    }
}
