using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManagerScript : MonoBehaviour
{
    public static List<ProfileDataScript> listOfProfiles = new List<ProfileDataScript>();

    [SerializeField] Text noExistingProfilesText;

    [SerializeField] GameObject profilePrefab1;
    [SerializeField] GameObject profilePrefab2;
    [SerializeField] GameObject profilePrefab3;
    [SerializeField] GameObject profilePrefab4;
    private List<GameObject> listOfProfilePrefabs = new List<GameObject>();

    [SerializeField] Text usernameTextbox1;
    [SerializeField] Text usernameTextbox2;
    [SerializeField] Text usernameTextbox3;
    [SerializeField] Text usernameTextbox4;
    private List<Text> listOfUsernameTextboxes = new List<Text>();

    [SerializeField] Text levelTextbox1;
    [SerializeField] Text levelTextbox2;
    [SerializeField] Text levelTextbox3;
    [SerializeField] Text levelTextbox4;
    private List<Text> listOfLevelTextboxes = new List<Text>();

    [SerializeField] Text languageTextbox1;
    [SerializeField] Text languageTextbox2;
    [SerializeField] Text languageTextbox3;
    [SerializeField] Text languageTextbox4;
    private List<Text> listOfLanguageTextboxes = new List<Text>();


    // Start is called before the first frame update
    void Start()
    {
        listOfProfilePrefabs.Add(profilePrefab1);
        listOfProfilePrefabs.Add(profilePrefab2);
        listOfProfilePrefabs.Add(profilePrefab3);
        listOfProfilePrefabs.Add(profilePrefab4);

        listOfUsernameTextboxes.Add(usernameTextbox1);
        listOfUsernameTextboxes.Add(usernameTextbox2);
        listOfUsernameTextboxes.Add(usernameTextbox3);
        listOfUsernameTextboxes.Add(usernameTextbox4);

        listOfLevelTextboxes.Add(levelTextbox1);
        listOfLevelTextboxes.Add(levelTextbox2);
        listOfLevelTextboxes.Add(levelTextbox3);
        listOfLevelTextboxes.Add(levelTextbox4);

        listOfLanguageTextboxes.Add(languageTextbox1);
        listOfLanguageTextboxes.Add(languageTextbox2);
        listOfLanguageTextboxes.Add(languageTextbox3);
        listOfLanguageTextboxes.Add(languageTextbox4);

        SaveSystem.LoadListOfProfilesData();
        
        if (listOfProfiles.Count != 0)
        {
            noExistingProfilesText.gameObject.SetActive(false);
            for (int i = 0; i < listOfProfiles.Count; i++)
            {
                listOfProfilePrefabs[i].SetActive(true);
                listOfUsernameTextboxes[i].text = listOfProfiles[i].userName;
                listOfLevelTextboxes[i].text = listOfProfiles[i].currentLevel.ToString();
                listOfLanguageTextboxes[i].text = listOfProfiles[i].targetLanguage;
            }
        }
    }

    public void DeactivateProfiles()
    {
        listOfProfiles.Clear();
        for (int i = 0; i < listOfProfilePrefabs.Count; i++)
        {
            listOfProfilePrefabs[i].SetActive(false);
        }
    }
}
