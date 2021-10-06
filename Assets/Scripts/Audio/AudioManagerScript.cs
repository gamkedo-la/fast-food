using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript audioManagerScript = null;

    // Start is called before the first frame update
    void Start()
    {
        if (audioManagerScript == null)
        {
            audioManagerScript = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayOneShot(AudioClip clipToPlay)
    {
        GetComponent<AudioSource>().PlayOneShot(clipToPlay);
    }
}
