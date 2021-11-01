using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturningStudentButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (ProfileManagerScript.listOfProfiles.Count == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
