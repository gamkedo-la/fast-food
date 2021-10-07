using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageDictionary : MonoBehaviour
{
    #region Fields
    public static Dictionary<string, Dictionary<string, string>> languageDictionary = new Dictionary<string, Dictionary<string, string>>();

    public static Dictionary<string, Dictionary<string, AudioClip>> audioLanguageDictionary = new Dictionary<string, Dictionary<string, AudioClip>>();

    //for study cards and picking up food items during gameplay
    [SerializeField] AudioClip englishIWouldLikeAAudioClip;
    [SerializeField] AudioClip englishHamburgerAudioClip;
    [SerializeField] AudioClip englishLettuceAudioClip;
    [SerializeField] AudioClip englishTomatoAudioClip;
    [SerializeField] AudioClip englishOnionAudioClip;
    [SerializeField] AudioClip englishThankYouAudioClip;
    [SerializeField] AudioClip englishNoAudioClip;
    [SerializeField] AudioClip englishLettucePickupAudioClip;
    [SerializeField] AudioClip englishTomatoPickupAudioClip;
    [SerializeField] AudioClip englishOnionPickupAudioClip;

    //for customer orders
    [SerializeField] AudioClip iWouldLikeAHamburgerEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithTomatoEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithOnionEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceAndTomatoEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceAndOnionEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithTomatoAndOnionEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceTomatoAndOnionEnglishPrompt;


    //for study cards and picking up food items during gameplay
    [SerializeField] AudioClip albanianIWouldLikeAAudioClip;
    [SerializeField] AudioClip albanianHamburgerAudioClip;
    [SerializeField] AudioClip albanianLettuceAudioClip;
    [SerializeField] AudioClip albanianTomatoAudioClip;
    [SerializeField] AudioClip albanianOnionAudioClip;
    [SerializeField] AudioClip albanianThankYouAudioClip;
    [SerializeField] AudioClip albanianNoAudioClip;
    [SerializeField] AudioClip albanianLettucePickupAudioClip;
    [SerializeField] AudioClip albanianTomatoPickupAudioClip;
    [SerializeField] AudioClip albanianOnionPickupAudioClip;

    //for customer orders
    [SerializeField] AudioClip iWouldLikeAHamburgerAlbanianPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceAlbanianPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithTomatoAlbanianPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithOnionAlbanianPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceAndTomatoAlbanianPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceAndOnionAlbanianPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithTomatoAndOnionAlbanianPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceTomatoAndOnionAlbanianPrompt;
    #endregion

    void Start()
    {
        #region Initialize text dictionary
        //gameplay
        languageDictionary.Add("English", new Dictionary<string, string>());
        languageDictionary["English"].Add("I want a hamburger", "I would like a hamburger");
        languageDictionary["English"].Add("with", " with ");
        languageDictionary["English"].Add("only lettuce", "lettuce.");
        languageDictionary["English"].Add("only tomato", "tomato.");
        languageDictionary["English"].Add("only onion", "onion.");
        languageDictionary["English"].Add("lettuce and tomato", "lettuce and tomato.");
        languageDictionary["English"].Add("lettuce and onion", "lettuce and onion.");
        languageDictionary["English"].Add("tomato and onion", "tomato and onion.");
        languageDictionary["English"].Add("lettuce, tomato, and onion", "lettuce, tomato, and onion.");
        languageDictionary["English"].Add("Thank you!", "Thank you!");
        languageDictionary["English"].Add("That's not what I want!", "That's not what I want!");

        languageDictionary.Add("Albanian", new Dictionary<string, string>());
        languageDictionary["Albanian"].Add("I want a hamburger", "Unë dua një hamburger");
        languageDictionary["Albanian"].Add("with", " me ");
        languageDictionary["Albanian"].Add("only lettuce", "marule.");
        languageDictionary["Albanian"].Add("only tomato", "domate.");
        languageDictionary["Albanian"].Add("only onion", "qepë.");
        languageDictionary["Albanian"].Add("lettuce and tomato", "marule dhe domate.");
        languageDictionary["Albanian"].Add("lettuce and onion", "marule dhe qepë.");
        languageDictionary["Albanian"].Add("tomato and onion", "domate dhe qepë.");
        languageDictionary["Albanian"].Add("lettuce, tomato, and onion", "marule, domate, dhe qepë.");
        languageDictionary["Albanian"].Add("Thank you!", "Faleminderit!");
        languageDictionary["Albanian"].Add("That's not what I want!", "Kjo nuk është ajo që unë dua!");

        //study screen
        languageDictionary["English"].Add("I would like a", "I would like a");
        languageDictionary["English"].Add("hamburger", "hamburger");
        languageDictionary["English"].Add("lettuce", "lettuce");
        languageDictionary["English"].Add("tomato", "tomato");
        languageDictionary["English"].Add("onion", "onion");

        languageDictionary["Albanian"].Add("I would like a", "Unë dua një");
        languageDictionary["Albanian"].Add("hamburger", "hamburger");
        languageDictionary["Albanian"].Add("lettuce", "marule");
        languageDictionary["Albanian"].Add("tomato", "domate");
        languageDictionary["Albanian"].Add("onion", "qepë");
        #endregion


        #region Initialize audio dictionary
        //English
        //for study cards and food pickup
        audioLanguageDictionary.Add("English", new Dictionary<string, AudioClip>());
        audioLanguageDictionary["English"].Add("I would like a", englishIWouldLikeAAudioClip);
        audioLanguageDictionary["English"].Add("hamburger", englishHamburgerAudioClip);
        audioLanguageDictionary["English"].Add("lettuce", englishLettuceAudioClip);
        audioLanguageDictionary["English"].Add("tomato", englishTomatoAudioClip);
        audioLanguageDictionary["English"].Add("onion", englishOnionAudioClip);
        audioLanguageDictionary["English"].Add("Thank You", englishThankYouAudioClip);
        audioLanguageDictionary["English"].Add("No", englishNoAudioClip);

        audioLanguageDictionary["English"].Add("lettuce pickup", englishLettucePickupAudioClip);
        audioLanguageDictionary["English"].Add("tomato pickup", englishTomatoPickupAudioClip);
        audioLanguageDictionary["English"].Add("onion pickup", englishOnionPickupAudioClip);

        //for customer prompts
        audioLanguageDictionary["English"].Add("I would like a hamburger", iWouldLikeAHamburgerEnglishPrompt);
        audioLanguageDictionary["English"].Add("I would like a hamburger with lettuce.", iWouldLikeAHamburgerWithLettuceEnglishPrompt);
        audioLanguageDictionary["English"].Add("I would like a hamburger with tomato.", iWouldLikeAHamburgerWithTomatoEnglishPrompt);
        audioLanguageDictionary["English"].Add("I would like a hamburger with onion.", iWouldLikeAHamburgerWithOnionEnglishPrompt);
        audioLanguageDictionary["English"].Add("I would like a hamburger with lettuce and tomato.", iWouldLikeAHamburgerWithLettuceAndTomatoEnglishPrompt);
        audioLanguageDictionary["English"].Add("I would like a hamburger with lettuce and onion.", iWouldLikeAHamburgerWithLettuceAndOnionEnglishPrompt);
        audioLanguageDictionary["English"].Add("I would like a hamburger with tomato and onion.", iWouldLikeAHamburgerWithTomatoAndOnionEnglishPrompt);
        audioLanguageDictionary["English"].Add("I would like a hamburger with lettuce, tomato, and onion.", iWouldLikeAHamburgerWithLettuceTomatoAndOnionEnglishPrompt);



        //Albanian
        //for study cards and food pickups
        audioLanguageDictionary.Add("Albanian", new Dictionary<string, AudioClip>());
        audioLanguageDictionary["Albanian"].Add("I would like a", albanianIWouldLikeAAudioClip);
        audioLanguageDictionary["Albanian"].Add("hamburger", albanianHamburgerAudioClip);
        audioLanguageDictionary["Albanian"].Add("lettuce", albanianLettuceAudioClip);
        audioLanguageDictionary["Albanian"].Add("tomato", albanianTomatoAudioClip);
        audioLanguageDictionary["Albanian"].Add("onion", albanianOnionAudioClip);
        audioLanguageDictionary["Albanian"].Add("Thank You", albanianThankYouAudioClip);
        audioLanguageDictionary["Albanian"].Add("No", albanianNoAudioClip);

        audioLanguageDictionary["Albanian"].Add("lettuce pickup", albanianLettucePickupAudioClip);
        audioLanguageDictionary["Albanian"].Add("tomato pickup", albanianTomatoPickupAudioClip);
        audioLanguageDictionary["Albanian"].Add("onion pickup", albanianOnionPickupAudioClip);

        //for customer prompts
        audioLanguageDictionary["Albanian"].Add("Unë dua një hamburger", iWouldLikeAHamburgerAlbanianPrompt);
        audioLanguageDictionary["Albanian"].Add("Unë dua një hamburger me marule.", iWouldLikeAHamburgerWithLettuceAlbanianPrompt);
        audioLanguageDictionary["Albanian"].Add("Unë dua një hamburger me domate.", iWouldLikeAHamburgerWithTomatoAlbanianPrompt);
        audioLanguageDictionary["Albanian"].Add("Unë dua një hamburger me qepë.", iWouldLikeAHamburgerWithOnionAlbanianPrompt);
        audioLanguageDictionary["Albanian"].Add("Unë dua një hamburger me marule dhe domate.", iWouldLikeAHamburgerWithLettuceAndTomatoAlbanianPrompt);
        audioLanguageDictionary["Albanian"].Add("Unë dua një hamburger me marule dhe qepë.", iWouldLikeAHamburgerWithLettuceAndOnionAlbanianPrompt);
        audioLanguageDictionary["Albanian"].Add("Unë dua një hamburger me domate dhe qepë.", iWouldLikeAHamburgerWithTomatoAndOnionAlbanianPrompt);
        audioLanguageDictionary["Albanian"].Add("Unë dua një hamburger me marule, tomato, dhe qepë.", iWouldLikeAHamburgerWithLettuceTomatoAndOnionAlbanianPrompt);
        #endregion
    }

}
