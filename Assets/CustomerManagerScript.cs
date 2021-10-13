using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManagerScript : MonoBehaviour
{
    public List<GameObject> listOfCustomers = new List<GameObject>();
    [SerializeField] GameObject customer1;
    [SerializeField] GameObject customer2;
    [SerializeField] GameObject customer3;

    public List<Slider> listOfCustomersPatienceSliders = new List<Slider>();
    [SerializeField] Slider slider1;
    [SerializeField] Slider slider2;
    [SerializeField] Slider slider3;



    // Start is called before the first frame update
    void Start()
    {
        listOfCustomers.Add(customer1);
        listOfCustomers.Add(customer2);
        listOfCustomers.Add(customer3);

        listOfCustomersPatienceSliders.Add(slider1);
        listOfCustomersPatienceSliders.Add(slider2);
        listOfCustomersPatienceSliders.Add(slider3);
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
