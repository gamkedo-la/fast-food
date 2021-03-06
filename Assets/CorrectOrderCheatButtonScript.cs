using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectOrderCheatButtonScript : ButtonScript
{
    [SerializeField] GameObject customerManager;

    public override void HandleButtonClick()
    {
        for (int i = 0; i < customerManager.GetComponent<CustomerManagerScript>().listOfCustomers.Count; i++)
        {
            if (customerManager.GetComponent<CustomerManagerScript>().listOfCustomers[i].GetComponent<CustomerOrderingScript>().myStateEnumeration ==
                CustomerStateEnumerations.WaitingForMyOrder ||
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomers[i].GetComponent<CustomerOrderingScript>().myStateEnumeration ==
                CustomerStateEnumerations.EnteringRestaurant)
            {
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomers[i].GetComponent<CustomerOrderingScript>().isProcessingOrder = true;
                EventManagerScript.correctOrderSubmissionEvent.Invoke();
                EventManagerScript.anyOrderSubmissionEvent.Invoke();
                customerManager.GetComponent<CustomerManagerScript>().listOfCustomers[i].GetComponent<CustomerOrderingScript>().isProcessingOrder = false;

                return;
            }
        }
    }
}
