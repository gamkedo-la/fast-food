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
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Randomizing customer accessories!");

        bool accessorize = (Random.Range(0,100)<=percentAny);
        int count = 0;

        // randomly leave a couple sprites visible
        for(int i = 0; i < transform.childCount; i++) {
        
           Transform child = transform.GetChild(i);

            if (accessorize && count<maxAccessories) {
                if (Random.Range(0,100)<=percentEach) {
                    Debug.Log("WEARING: "+child.name);
                    child.gameObject.SetActive(true);
                    count++;
                } else {
                    Debug.Log("Not wearing "+child.name);
                    child.gameObject.SetActive(false);
                }
            } else {
                Debug.Log("Skipping "+child.name);
                child.gameObject.SetActive(false);
            }
        }        
    }

}
