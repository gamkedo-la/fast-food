using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonScript : MonoBehaviour
{
    public AudioClip buttonClickAudioClip;

    public virtual void HandleButtonClick()
    {
    }


}
