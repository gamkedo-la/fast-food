using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ClearProfileDataButtonScript : MonoBehaviour
{
    public void HandleButtonClick()
    {
        foreach (var directory in Directory.GetDirectories(Application.persistentDataPath))
        {
            DirectoryInfo data_dir = new DirectoryInfo(directory);
            data_dir.Delete(true);
        }

        foreach (var file in Directory.GetFiles(Application.persistentDataPath))
        {
            FileInfo file_info = new FileInfo(file);
            file_info.Delete();
        }
    }
}
