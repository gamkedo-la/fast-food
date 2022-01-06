using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRestaurantSFXTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioController.instance.PlayAudio(GameSoundEnum.SFX_Customer_Leave);
        gameObject.SetActive(false);
    }
}
