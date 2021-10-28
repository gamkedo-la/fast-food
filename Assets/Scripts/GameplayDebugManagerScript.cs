using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayDebugManagerScript : MonoBehaviour
{
    [SerializeField] GameObject levelStatsCanvas;
    [SerializeField] GameObject customerManager;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            EventManagerScript.levelCompletedEvent.Invoke();
            levelStatsCanvas.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.C))
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
                    return;
                }
            }
        }
    }
}
