using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManagerScript : MonoBehaviour
{
    public List<GameObject> listOfCustomers = new List<GameObject>();
    [SerializeField] GameObject customer1;
    [SerializeField] GameObject customer2;
    [SerializeField] GameObject customer3;

    // Start is called before the first frame update
    void Start()
    {
        listOfCustomers.Add(customer1);
        listOfCustomers.Add(customer2);
        listOfCustomers.Add(customer3);
    }

    public bool AreAnyCustomersLosingPatience()
    {
        for (int i = 0; i < listOfCustomers.Count; i++)
        {
            if (listOfCustomers[i].GetComponent<CustomerOrderingScript>().losingPatience)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
