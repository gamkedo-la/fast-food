using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour
{
    [SerializeField] GameObject leaveRestaurantSFXTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        leaveRestaurantSFXTrigger.SetActive(true);
    }
}
