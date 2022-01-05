using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraScript : MonoBehaviour
{
    public GameObject fadeTransitioner;
    // Start is called before the first frame update
    void Start()
    {
        fadeTransitioner = GameObject.FindGameObjectWithTag("FadeTransitioner");
        fadeTransitioner.GetComponent<FadeTransitionerScript>().isFadingIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
