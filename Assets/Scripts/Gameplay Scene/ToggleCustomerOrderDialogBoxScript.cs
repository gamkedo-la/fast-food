using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleCustomerOrderDialogBoxScript : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject myOrderingCanvasDialogBoxImage;
    [SerializeField] GameObject customer;
    #endregion    

    public void HandleToggleCustomerDialogBoxButtonClick()
    {
        if (myOrderingCanvasDialogBoxImage.activeSelf == false)
        {
            myOrderingCanvasDialogBoxImage.SetActive(true);
        }
        else
        {
            myOrderingCanvasDialogBoxImage.SetActive(false);
        }
    }

    public void PlayMyOrderAudioClip()
    {
        //AudioManagerScript.audioManagerScript.PlayOneShot(customer.GetComponent<CustomerOrderingScript>().myCurrentOrdersAudioClip);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(customer.GetComponent<CustomerOrderingScript>().myCurrentOrdersAudioClip);
    }

    public void HandleInvisibleCustomerOrderButtonClick()
    {
        if (GameManagerScript.currentCustomerPromptType == CustomerPromptTypeEnumerables.Text)
        {
            HandleToggleCustomerDialogBoxButtonClick();
        }
        else
        {
            PlayMyOrderAudioClip();
        }
    }
}
