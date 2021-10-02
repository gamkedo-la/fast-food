using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleCustomerOrderDialogBoxScript : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject myOrderingCanvasDialogBoxImage;

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
