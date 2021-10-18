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

        formatter.Serialize(stream, ProfileManagerScript.listOfProfiles);
        stream.Close();
    }

    public static void LoadListOfProfilesData()
    {
        string path = Application.persistentDataPath + "/profileData.listOfProfiles";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ProfileManagerScript.listOfProfiles = formatter.Deserialize(stream) as System.Collections.Generic.List<ProfileDataScript>;
            //for (int i = 0; i < ProfileManagerScript.listOfProfiles.Count; i++)
            //{
            //    Debug.Log("ProfileManagerScript.listOfProfiles[i].username: " + ProfileManagerScript.listOfProfiles[i].userName);
            //}
            stream.Close();
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }
}
