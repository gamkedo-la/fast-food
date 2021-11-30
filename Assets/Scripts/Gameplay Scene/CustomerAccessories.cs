using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAccessories : MonoBehaviour
{
    [Range(0, 100)]
    public int percentAny = 100;
    [Range(0, 100)]
    public int percentEach = 5;
    [Range(0, 10)]
    public int maxAccessories = 2;

    public SpriteRenderer RainbowShirt;

    [SerializeField] GameObject parentCustomerGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        RandomizeAccesories();
    }

    public void RandomizeAccesories()
    {
        //Debug.Log("Randomizing customer accessories!");

        // tint the rainbow shirt a random colour!
        if (RainbowShirt) {
            //Debug.Log("Randomizing shirt color!");
            RainbowShirt.color = Random.ColorHSV();
        }

        bool accessorize = (Random.Range(0, 100) <= percentAny);
        int count = 0;

        // randomly leave a couple sprites visible
        for (int i = 0; i < transform.childCount; i++)
        {

            Transform child = transform.GetChild(i);

            if (parentCustomerGameObject.GetComponent<CustomerOrderingScript>().myStateEnumeration != CustomerStateEnumerations.WaitingForMyOrder)
            {
                Debug.Log("inside check for rotation");
                child.transform.eulerAngles = new Vector3(0,0,90);

                float newXWhileRotated = child.GetComponent<AccessorieScript>().myXPositionWhenRotated;
                float newYWhileRotated = child.GetComponent<AccessorieScript>().myYPositionWhenRotated;
                child.transform.position = new Vector3(newXWhileRotated, newYWhileRotated, 0);
            }
            else
            {
                child.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (accessorize && count < maxAccessories)
            {
                if (Random.Range(0, 100) <= percentEach)
                {
                    //Debug.Log("WEARING: " + child.name);
                    child.gameObject.SetActive(true);
                    count++;
                }
                else
                {
                    //Debug.Log("Not wearing " + child.name);
                    child.gameObject.SetActive(false);
                }
            }
            else
            {
                //Debug.Log("Skipping " + child.name);
                child.gameObject.SetActive(false);
            }
        }
    }

}
