using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageDictionary : MonoBehaviour
{
    #region Fields
    public static Dictionary<Language, Dictionary<string, string>> languageDictionary = new Dictionary<Language, Dictionary<string, string>>();

    public static Dictionary<Language, Dictionary<string, AudioClip>> audioLanguageDictionary = new Dictionary<Language, Dictionary<string, AudioClip>>();

    //for study cards and picking up food items during gameplay
    [SerializeField] AudioClip englishIWouldLikeAAudioClip;
    [SerializeField] AudioClip englishHamburgerAudioClip;
    [SerializeField] AudioClip englishChickenDonerAudioClip;
    [SerializeField] AudioClip englishLettuceAudioClip;
    [SerializeField] AudioClip englishTomatoAudioClip;
    [SerializeField] AudioClip englishOnionAudioClip;
    [SerializeField] AudioClip englishThankYouAudioClip;
    [SerializeField] AudioClip englishNoAudioClip;
    [SerializeField] AudioClip englishLettucePickupAudioClip;
    [SerializeField] AudioClip englishTomatoPickupAudioClip;
    [SerializeField] AudioClip englishOnionPickupAudioClip;

    //for customer orders
    //hamburger
    [SerializeField] AudioClip iWouldLikeAHamburgerEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithTomatoEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithOnionEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceAndTomatoEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceAndOnionEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithTomatoAndOnionEnglishPrompt;
    [SerializeField] AudioClip iWouldLikeAHamburgerWithLettuceTomatoAndOnionEnglishPrompt;
    //chicken doner
    [SerializeField] AudioClip englishIWouldLikeAChickenDonerPrompt;
    [SerializeField] AudioClip englishIWouldLikeAChickenDonerWithLettucePrompt;
    [SerializeField] AudioClip englishIWouldLikeAChickenDonerWithTomatoPrompt;
    [SerializeField] AudioClip englishIWouldLikeAChickenDonerWithOnionPrompt;
    [SerializeField] AudioClip englishIWouldLikeAChickenDonerWithLettuceAndTomatoPrompt;
    [SerializeField] AudioClip englishIWouldLikeAChickenDonerWithLettuceAndOnionPrompt;
    [SerializeField] AudioClip englishIWouldLikeAChickenDonerWithTomatoAndOnionPrompt;
    [SerializeField] AudioClip englishIWouldLikeAChickenDonerWithLettuceTomatoAndOnionPrompt;



    //for study cards and picking up food items during gameplay
    [SerializeField] AudioClip albanianIWouldLikeAAudioClip;
    [SerializeField] AudioClip albanianHamburgerAudioClip;
    [SerializeField] AudioClip albanianChickenDonerAudioClip;
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

    [SerializeField] AudioClip albanianIWouldLikeAChickenDonerPrompt;
    [SerializeField] AudioClip albanianIWouldLikeAChickenDonerWithLettucePrompt;
    [SerializeField] AudioClip albanianIWouldLikeAChickenDonerWithTomatoPrompt;
    [SerializeField] AudioClip albanianIWouldLikeAChickenDonerWithOnionPrompt;
    [SerializeField] AudioClip albanianIWouldLikeAChickenDonerWithLettuceAndTomatoPrompt;
    [SerializeField] AudioClip albanianIWouldLikeAChickenDonerWithLettuceAndOnionPrompt;
    [SerializeField] AudioClip albanianIWouldLikeAChickenDonerWithTomatoAndOnionPrompt;
    [SerializeField] AudioClip albanianWouldLikeAChickenDonerWithLettuceTomatoAndOnionPrompt;
    #endregion

    void Start()
    {
        #region Initialize text dictionary
        //gameplay
        languageDictionary.Add(Language.English, new Dictionary<string, string>());
        languageDictionary[Language.English].Add("I want a hamburger", "I would like a hamburger");
        languageDictionary[Language.English].Add("I want a chicken doner", "I would like a chicken doner");
        languageDictionary[Language.English].Add("with", " with ");
        languageDictionary[Language.English].Add("only lettuce", "lettuce.");
        languageDictionary[Language.English].Add("only tomato", "tomato.");
        languageDictionary[Language.English].Add("only onion", "onion.");
        languageDictionary[Language.English].Add("lettuce and tomato", "lettuce and tomato.");
        languageDictionary[Language.English].Add("lettuce and onion", "lettuce and onion.");
        languageDictionary[Language.English].Add("tomato and onion", "tomato and onion.");
        languageDictionary[Language.English].Add("lettuce, tomato, and onion", "lettuce, tomato, and onion.");
        languageDictionary[Language.English].Add("Thank you!", "Thank you!");
        languageDictionary[Language.English].Add("That's not what I want!", "That's not what I want!");

        languageDictionary.Add(Language.Albanian, new Dictionary<string, string>());
        languageDictionary[Language.Albanian].Add("I want a hamburger", "Un� dua nj� hamburger");
        languageDictionary[Language.Albanian].Add("I want a chicken doner", "Un� dua nj� doner pule");
        languageDictionary[Language.Albanian].Add("with", " me ");
        languageDictionary[Language.Albanian].Add("only lettuce", "marule.");
        languageDictionary[Language.Albanian].Add("only tomato", "domate.");
        languageDictionary[Language.Albanian].Add("only onion", "qep�.");
        languageDictionary[Language.Albanian].Add("lettuce and tomato", "marule dhe domate.");
        languageDictionary[Language.Albanian].Add("lettuce and onion", "marule dhe qep�.");
        languageDictionary[Language.Albanian].Add("tomato and onion", "domate dhe qep�.");
        languageDictionary[Language.Albanian].Add("lettuce, tomato, and onion", "marule, domate, dhe qep�.");
        languageDictionary[Language.Albanian].Add("Thank you!", "Faleminderit!");
        languageDictionary[Language.Albanian].Add("That's not what I want!", "Kjo nuk �sht� ajo q� un� dua!");

        //study screen
        languageDictionary[Language.English].Add("I would like a", "I would like a");
        languageDictionary[Language.English].Add("hamburger", "hamburger");
        languageDictionary[Language.English].Add("lettuce", "lettuce");
        languageDictionary[Language.English].Add("tomato", "tomato");
        languageDictionary[Language.English].Add("onion", "onion");

        languageDictionary[Language.Albanian].Add("I would like a", "Un� dua nj�");
        languageDictionary[Language.Albanian].Add("hamburger", "hamburger");
        languageDictionary[Language.Albanian].Add("lettuce", "marule");
        languageDictionary[Language.Albanian].Add("tomato", "domate");
        languageDictionary[Language.Albanian].Add("onion", "qep�");
        #endregion


        #region Initialize audio dictionary
        //English
        //for study cards and food pickup
        audioLanguageDictionary.Add(Language.English, new Dictionary<string, AudioClip>());
        audioLanguageDictionary[Language.English].Add("I would like a", englishIWouldLikeAAudioClip);
        audioLanguageDictionary[Language.English].Add("hamburger", englishHamburgerAudioClip);
        audioLanguageDictionary[Language.English].Add("chicken doner", englishHamburgerAudioClip);
        audioLanguageDictionary[Language.English].Add("lettuce", englishLettuceAudioClip);
        audioLanguageDictionary[Language.English].Add("tomato", englishTomatoAudioClip);
        audioLanguageDictionary[Language.English].Add("onion", englishOnionAudioClip);
        audioLanguageDictionary[Language.English].Add("Thank You", englishThankYouAudioClip);
        audioLanguageDictionary[Language.English].Add("No", englishNoAudioClip);

        audioLanguageDictionary[Language.English].Add("lettuce pickup", englishLettucePickupAudioClip);
        audioLanguageDictionary[Language.English].Add("tomato pickup", englishTomatoPickupAudioClip);
        audioLanguageDictionary[Language.English].Add("onion pickup", englishOnionPickupAudioClip);

        //for customer prompts
        audioLanguageDictionary[Language.English].Add("I would like a hamburger", iWouldLikeAHamburgerEnglishPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a hamburger with lettuce.", iWouldLikeAHamburgerWithLettuceEnglishPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a hamburger with tomato.", iWouldLikeAHamburgerWithTomatoEnglishPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a hamburger with onion.", iWouldLikeAHamburgerWithOnionEnglishPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a hamburger with lettuce and tomato.", iWouldLikeAHamburgerWithLettuceAndTomatoEnglishPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a hamburger with lettuce and onion.", iWouldLikeAHamburgerWithLettuceAndOnionEnglishPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a hamburger with tomato and onion.", iWouldLikeAHamburgerWithTomatoAndOnionEnglishPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a hamburger with lettuce, tomato, and onion.", iWouldLikeAHamburgerWithLettuceTomatoAndOnionEnglishPrompt);

        audioLanguageDictionary[Language.English].Add("I would like a chicken doner", englishIWouldLikeAChickenDonerPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a chicken doner with lettuce.", englishIWouldLikeAChickenDonerWithLettucePrompt);
        audioLanguageDictionary[Language.English].Add("I would like a chicken doner with tomato.", englishIWouldLikeAChickenDonerWithTomatoPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a chicken doner with onion.", englishIWouldLikeAChickenDonerWithOnionPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a chicken doner with lettuce and tomato.", englishIWouldLikeAChickenDonerWithLettuceAndTomatoPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a chicken doner with lettuce and onion.", englishIWouldLikeAChickenDonerWithLettuceAndOnionPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a chicken doner with tomato and onion.", englishIWouldLikeAChickenDonerWithTomatoAndOnionPrompt);
        audioLanguageDictionary[Language.English].Add("I would like a chicken doner with lettuce, tomato, and onion.", englishIWouldLikeAChickenDonerWithLettuceTomatoAndOnionPrompt);


        //Albanian
        //for study cards and food pickups
        audioLanguageDictionary.Add(Language.Albanian, new Dictionary<string, AudioClip>());
        audioLanguageDictionary[Language.Albanian].Add("I would like a", albanianIWouldLikeAAudioClip);
        audioLanguageDictionary[Language.Albanian].Add("hamburger", albanianHamburgerAudioClip);
        audioLanguageDictionary[Language.Albanian].Add("lettuce", albanianLettuceAudioClip);
        audioLanguageDictionary[Language.Albanian].Add("tomato", albanianTomatoAudioClip);
        audioLanguageDictionary[Language.Albanian].Add("onion", albanianOnionAudioClip);
        audioLanguageDictionary[Language.Albanian].Add("Thank You", albanianThankYouAudioClip);
        audioLanguageDictionary[Language.Albanian].Add("No", albanianNoAudioClip);

        audioLanguageDictionary[Language.Albanian].Add("lettuce pickup", albanianLettucePickupAudioClip);
        audioLanguageDictionary[Language.Albanian].Add("tomato pickup", albanianTomatoPickupAudioClip);
        audioLanguageDictionary[Language.Albanian].Add("onion pickup", albanianOnionPickupAudioClip);

        //for customer prompts
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� hamburger", iWouldLikeAHamburgerAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� hamburger me marule.", iWouldLikeAHamburgerWithLettuceAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� hamburger me domate.", iWouldLikeAHamburgerWithTomatoAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� hamburger me qep�.", iWouldLikeAHamburgerWithOnionAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� hamburger me marule dhe domate.", iWouldLikeAHamburgerWithLettuceAndTomatoAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� hamburger me marule dhe qep�.", iWouldLikeAHamburgerWithLettuceAndOnionAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� hamburger me domate dhe qep�.", iWouldLikeAHamburgerWithTomatoAndOnionAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� hamburger me marule, tomato, dhe qep�.", iWouldLikeAHamburgerWithLettuceTomatoAndOnionAlbanianPrompt);

        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� doner pule", albanianIWouldLikeAChickenDonerPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� doner pule me marule.", albanianIWouldLikeAChickenDonerWithLettucePrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� doner pule me domate.", albanianIWouldLikeAChickenDonerWithTomatoPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� doner pule me qep�.", albanianIWouldLikeAChickenDonerWithOnionPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� doner pule me marule dhe domate.", albanianIWouldLikeAChickenDonerWithLettuceAndTomatoPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� doner pule me marule dhe qep�.", albanianIWouldLikeAChickenDonerWithLettuceAndOnionPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� doner pule me domate dhe qep�.", albanianIWouldLikeAChickenDonerWithTomatoAndOnionPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Un� dua nj� doner pule me marule, tomato, dhe qep�.", albanianWouldLikeAChickenDonerWithLettuceTomatoAndOnionPrompt);
        #endregion
    }

}
