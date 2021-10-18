using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ClearProfileDataButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject profileManager;

    public void HandleButtonClick()
    {
        profileManager.GetComponent<ProfileManagerScript>().DeactivateProfiles();

        Debug.Log("inside clear profiles button click");
        foreach (var directory in Directory.GetDirectories(Application.persistentDataPath))
        {
            Debug.Log("inside foreach deletion of directory of clear profile data button");
            DirectoryInfo data_dir = new DirectoryInfo(directory);
            data_dir.Delete(true);
        }

        foreach (var file in Directory.GetFiles(Application.persistentDataPath))
        {
            Debug.Log("inside foreach deletion of files of clear profile data button");
            FileInfo file_info = new FileInfo(file);
            file_info.Delete();
        }

    }
}
