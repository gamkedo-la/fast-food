using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageDictionary : MonoBehaviour
{
    #region Fields
    public static Dictionary<string, Dictionary<string, string>> languageDictionary = new Dictionary<string, Dictionary<string, string>>();

    public static Dictionary<string, Dictionary<string, AudioClip>> audioLanguageDictionary = new Dictionary<string, Dictionary<string, AudioClip>>();

    [SerializeField] AudioClip englishHamburgerAudioClip;
    [SerializeField] AudioClip englishLettuceAudioClip;
    [SerializeField] AudioClip englishTomatoeAudioClip;
    [SerializeField] AudioClip englishOnionAudioClip;
    [SerializeField] AudioClip englishThankYouAudioClip;
    [SerializeField] AudioClip englishNoAudioClip;
    [SerializeField] AudioClip englishLettucePickupAudioClip;
    [SerializeField] AudioClip englishTomatoePickupAudioClip;
    [SerializeField] AudioClip englishOnionPickupAudioClip;



    [SerializeField] AudioClip albanianHamburgerAudioClip;
    [SerializeField] AudioClip albanianLettuceAudioClip;
    [SerializeField] AudioClip albanianTomatoeAudioClip;
    [SerializeField] AudioClip albanianOnionAudioClip;
    [SerializeField] AudioClip albanianThankYouAudioClip;
    [SerializeField] AudioClip albanianNoAudioClip;
    [SerializeField] AudioClip albanianLettucePickupAudioClip;
    [SerializeField] AudioClip albanianTomatoePickupAudioClip;
    [SerializeField] AudioClip albanianOnionPickupAudioClip;
    #endregion

    void Start()
    {
        #region Initialize text dictionary
        //gameplay
        languageDictionary.Add("English", new Dictionary<string, string>());
        languageDictionary["English"].Add("I want a hamburger", "I want a hamburger");
        languageDictionary["English"].Add("with", " with ");
        languageDictionary["English"].Add("only lettuce", "lettuce.");
        languageDictionary["English"].Add("only tomatoe", "tomatoe.");
        languageDictionary["English"].Add("only onion", "onion.");
        languageDictionary["English"].Add("lettuce and tomatoe", "lettuce and tomatoe.");
        languageDictionary["English"].Add("lettuce and onion", "lettuce and onion.");
        languageDictionary["English"].Add("tomatoe and onion", "tomatoe and onion.");
        languageDictionary["English"].Add("lettuce, tomatoe, and onion", "lettuce, tomatoe, and onion.");
        languageDictionary["English"].Add("Thank you!", "Thank you!");
        languageDictionary["English"].Add("That's not what I want!", "That's not what I want!");

        languageDictionary.Add("Albanian", new Dictionary<string, string>());
        languageDictionary["Albanian"].Add("I want a hamburger", "Unë dua një hamburger");
        languageDictionary["Albanian"].Add("with", " me ");
        languageDictionary["Albanian"].Add("only lettuce", "marule.");
        languageDictionary["Albanian"].Add("only tomatoe", "domate.");
        languageDictionary["Albanian"].Add("only onion", "qepë.");
        languageDictionary["Albanian"].Add("lettuce and tomatoe", "marule dhe domate.");
        languageDictionary["Albanian"].Add("lettuce and onion", "marule dhe qepë.");
        languageDictionary["Albanian"].Add("tomatoe and onion", "domate dhe qepë.");
        languageDictionary["Albanian"].Add("lettuce, tomatoe, and onion", "marule, domate, dhe qepë.");
        languageDictionary["Albanian"].Add("Thank you!", "Faleminderit!");
        languageDictionary["Albanian"].Add("That's not what I want!", "Kjo nuk është ajo që unë dua!");

        //study screen
        languageDictionary["English"].Add("hamburger", "hamburger");
        languageDictionary["English"].Add("lettuce", "lettuce");
        languageDictionary["English"].Add("tomatoe", "tomatoe");
        languageDictionary["English"].Add("onion", "onion");

        languageDictionary["Albanian"].Add("hamburger", "hamburger");
        languageDictionary["Albanian"].Add("lettuce", "marule");
        languageDictionary["Albanian"].Add("tomatoe", "domate");
        languageDictionary["Albanian"].Add("onion", "qepë");
        #endregion


        #region Initialize audio dictionary
        //English
        audioLanguageDictionary.Add("English", new Dictionary<string, AudioClip>());
        audioLanguageDictionary["English"].Add("hamburger", englishHamburgerAudioClip);
        audioLanguageDictionary["English"].Add("lettuce", englishLettuceAudioClip);
        audioLanguageDictionary["English"].Add("tomatoe", englishTomatoeAudioClip);
        audioLanguageDictionary["English"].Add("onion", englishOnionAudioClip);
        audioLanguageDictionary["English"].Add("Thank You", englishThankYouAudioClip);
        audioLanguageDictionary["English"].Add("No", englishNoAudioClip);

        audioLanguageDictionary["English"].Add("lettuce pickup", englishLettucePickupAudioClip);
        audioLanguageDictionary["English"].Add("tomatoe pickup", englishTomatoePickupAudioClip);
        audioLanguageDictionary["English"].Add("onion pickup", englishOnionPickupAudioClip);


        //Albanian
        audioLanguageDictionary.Add("Albanian", new Dictionary<string, AudioClip>());
        audioLanguageDictionary["Albanian"].Add("hamburger", albanianHamburgerAudioClip);
        audioLanguageDictionary["Albanian"].Add("lettuce", albanianLettuceAudioClip);
        audioLanguageDictionary["Albanian"].Add("tomatoe", albanianTomatoeAudioClip);
        audioLanguageDictionary["Albanian"].Add("onion", albanianOnionAudioClip);
        audioLanguageDictionary["Albanian"].Add("Thank You", albanianThankYouAudioClip);
        audioLanguageDictionary["Albanian"].Add("No", albanianNoAudioClip);

        audioLanguageDictionary["Albanian"].Add("lettuce pickup", albanianLettucePickupAudioClip);
        audioLanguageDictionary["Albanian"].Add("tomatoe pickup", albanianTomatoePickupAudioClip);
        audioLanguageDictionary["Albanian"].Add("onion pickup", albanianOnionPickupAudioClip);
        #endregion
    }

}
