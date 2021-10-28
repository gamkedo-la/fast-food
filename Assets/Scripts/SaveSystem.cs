using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveListOfProfilesData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/profileData.listOfProfiles";
        FileStream stream = new FileStream(path, FileMode.Create);

        for (int i = 0; i < ProfileManagerScript.listOfProfiles.Count; i++)
        {
            if (ProfileManagerScript.listOfProfiles[i] == GameManagerScript.currentProfile)
            {
                ProfileManagerScript.listOfProfiles[i].currentLevel = GameManagerScript.currentProfile.currentLevel;
            }
        }
        formatter.Serialize(stream, ProfileManagerScript.listOfProfiles);

        stream.Close();
    }

    public static void LoadListOfProfilesData()
    {
        string path = Application.persistentDataPath + "/profileData.listOfProfiles";
        if (File.Exists(path))
        {
            Debug.Log("inside path existence check of LoadListOfProfilesData");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ProfileManagerScript.listOfProfiles = formatter.Deserialize(stream) as System.Collections.Generic.List<ProfileDataScript>;
            if (ProfileManagerScript.listOfProfiles.Count == 0)
            {
                Debug.Log("there are 0 profiles in ProfileManagerScript.listOfProfiles");
            }
            for (int i = 0; i < ProfileManagerScript.listOfProfiles.Count; i++)
            {
                Debug.Log("ProfileManagerScript.listOfProfiles[i]: " + ProfileManagerScript.listOfProfiles[i]);
            }
            stream.Close();
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }
}
