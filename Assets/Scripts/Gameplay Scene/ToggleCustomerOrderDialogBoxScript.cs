using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ToggleCustomerOrderDialogBoxScript : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject myOrderingCanvasDialogBoxImage;
    [SerializeField] TextMeshProUGUI orderTextboxTextMeshPro;
    [SerializeField] GameObject customer;
    #endregion    

    public void HandleToggleCustomerDialogBoxButtonClick()
    {
        if (myOrderingCanvasDialogBoxImage.activeSelf == false)
        {
            Debug.Log("toggling on customer dialog box from toggle button script");
            myOrderingCanvasDialogBoxImage.SetActive(true);
        }
        else
        {
            Debug.Log("toggling off customer dialog box from toggle button script");
            myOrderingCanvasDialogBoxImage.SetActive(false);
        }
    }

    public void PlayMyOrderAudioClip()
    {
        //AudioManagerScript.audioManagerScript.PlayOneShot(customer.GetComponent<CustomerOrderingScript>().myCurrentOrdersAudioClip);
        if (GameManagerScript.currentLevel >= 5)
        {
            AudioController.instance.PlayAudioInSequence(
            AudioController.instance.ConvertCustomerOrderStringToGameSoundEnum(customer.GetComponent<CustomerOrderingScript>().currentCustomerFoodOrderString),
            AudioController.instance.ConvertCustomerOrderStringToGameSoundEnum(customer.GetComponent<CustomerOrderingScript>().currentCustomerDrinkOrderString));
        }
        else
        {
            AudioController.instance.PlayAudio(
            AudioController.instance.ConvertCustomerOrderStringToGameSoundEnum(customer.GetComponent<CustomerOrderingScript>().currentCustomerDialogueString));
        }
        
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(customer.GetComponent<CustomerOrderingScript>().myCurrentOrdersAudioClip);
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
