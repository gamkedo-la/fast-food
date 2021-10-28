using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Video;

public class TutorialVideoPlatformManagement : MonoBehaviour
{
    [SerializeField] private GameObject androidVideoPlayerParentGameObject;
    [SerializeField] private GameObject itchVideoPlayerParentGameObject;
    [SerializeField] private GameObject childItchVideoPlayerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerScript.currentPlatformEnum == CurrentPlatformEnum.Android)
        {
            androidVideoPlayerParentGameObject.SetActive(true);
        }
        else if (GameManagerScript.currentPlatformEnum == CurrentPlatformEnum.Itch)
        {
            itchVideoPlayerParentGameObject.SetActive(true);
            childItchVideoPlayerGameObject.GetComponent<UnityEngine.Video.VideoPlayer>().url = Path.Combine(Application.streamingAssetsPath, "placeholderTutorialVideo.mp4");
        }
    }
}
