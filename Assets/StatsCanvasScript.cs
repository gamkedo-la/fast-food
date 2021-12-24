using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject customer1;
    [SerializeField] GameObject customer2;
    [SerializeField] GameObject customer3;

    public void Appear()
    {
        Destroy(customer1);
        Destroy(customer2);
        Destroy(customer3);

        gameObject.SetActive(true);
        Time.timeScale = 0;
        AudioController.instance.StopAudio(GameSoundEnum.SFX_Customer_Impatience);
        GameManagerScript.impatienceSoundIsPlaying = false;
    }
}
