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

    public SpriteRenderer RainbowShirtSpriteRenderer;
    
    [SerializeField] GameObject parentCustomerGameObject;
    
    private SpriteRenderer ParentSpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        // grab the sprite renderer from the parent 
        ParentSpriteRenderer = transform.parent.gameObject.GetComponent<SpriteRenderer>();

        RandomizeAccesories();
    }

    public void RandomizeAccesories()
    {
        // tint the rainbow shirt a random colour!
        if (RainbowShirtSpriteRenderer) {
            RainbowShirtSpriteRenderer.color = Random.ColorHSV();
        }

        // tint the base sprite for skin tone variations
        // FIXME only choose "normal" values? and make the sprite pure FFFFFF to blend them properly?
        if (ParentSpriteRenderer) {
            
            if (Random.value > 0.25f) {
                // random tint of bright colors
                // params: float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax);
                ParentSpriteRenderer.color = Random.ColorHSV(0.1f,1.0f,0.3f,1.0f,0.5f,1.0f); // brightened
            } else {
                // no tint - original sprite
                ParentSpriteRenderer.color = Color.white; 
            }
        }


        bool accessorize = (Random.Range(0, 100) <= percentAny);
        int count = 0;

        // randomly leave a couple sprites visible
        for (int i = 0; i < transform.childCount; i++)
        {

            Transform child = transform.GetChild(i);

            if (accessorize && count < maxAccessories)
            {
                if (Random.Range(0, 100) <= percentEach)
                {
                    //Debug.Log("WEARING: " + child.name);
                    child.gameObject.SetActive(true);
                    
                    if (parentCustomerGameObject.GetComponent<CustomerOrderingScript>().myStateEnumeration != CustomerStateEnumerations.WaitingForMyOrder)
                    {
                        child.transform.rotation = Quaternion.Euler(Vector3.forward * 90);
                    }
                    else
                    {
                        child.transform.rotation = Quaternion.Euler(Vector3.forward * 0);
                    }

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

    public List<Transform> ReturnAListOfActiveAccessoryTransforms()
    {
        List<Transform> listOfActiveAccessoryTransforms = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                listOfActiveAccessoryTransforms.Add(transform.GetChild(i));
            }
        }

        return listOfActiveAccessoryTransforms;
    }
}
