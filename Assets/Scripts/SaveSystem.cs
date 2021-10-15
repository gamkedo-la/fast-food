using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveProfileData(ProfileDataScript profileToSave)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/profileData." + profileToSave.userName;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, profileToSave);
        stream.Close();
    }

    public static ProfileDataScript LoadProfileData(ProfileDataScript profileToLoad)
    {
        string path = Application.persistentDataPath + "/profileData." + profileToLoad.userName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            profileToLoad = formatter.Deserialize(stream) as ProfileDataScript;
            stream.Close();

            return profileToLoad;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
