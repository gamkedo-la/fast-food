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

        languageDictionary[Language.English].Add("beer", " And a beer.");
        languageDictionary[Language.English].Add("water", " And a water.");
        languageDictionary[Language.English].Add("red wine", " And a red wine.");
        languageDictionary[Language.English].Add("white wine", " And a white wine.");

        languageDictionary.Add(Language.Albanian, new Dictionary<string, string>());
        languageDictionary[Language.Albanian].Add("I want a hamburger", "Unë dua një hamburger");
        languageDictionary[Language.Albanian].Add("I want a chicken doner", "Unë dua një doner pule");
        languageDictionary[Language.Albanian].Add("with", " me ");
        languageDictionary[Language.Albanian].Add("only lettuce", "marule.");
        languageDictionary[Language.Albanian].Add("only tomato", "domate.");
        languageDictionary[Language.Albanian].Add("only onion", "qepë.");
        languageDictionary[Language.Albanian].Add("lettuce and tomato", "marule dhe domate.");
        languageDictionary[Language.Albanian].Add("lettuce and onion", "marule dhe qepë.");
        languageDictionary[Language.Albanian].Add("tomato and onion", "domate dhe qepë.");
        languageDictionary[Language.Albanian].Add("lettuce, tomato, and onion", "marule, domate, dhe qepë.");
        languageDictionary[Language.Albanian].Add("Thank you!", "Faleminderit!");
        languageDictionary[Language.Albanian].Add("That's not what I want!", "Kjo nuk është ajo që unë dua!");

        languageDictionary[Language.Albanian].Add("beer", " Dhe një birrë.");
        languageDictionary[Language.Albanian].Add("water", " Dhe një ujë.");
        languageDictionary[Language.Albanian].Add("red wine", " Dhe një verë e kuqe.");
        languageDictionary[Language.Albanian].Add("white wine", " Dhe një verë të bardhë.");
            
        //თუ შეიძლება, 'may I'... added at the end of the sentence
        languageDictionary.Add(Language.Georgian, new Dictionary<string, string>());
        languageDictionary[Language.Georgian].Add("I want a hamburger", "ერთი ჰამბურგერი");
        languageDictionary[Language.Georgian].Add("I want a chicken doner", "ერთი ქათმის შაურმა");
        languageDictionary[Language.Georgian].Add("with", " ");
        languageDictionary[Language.Georgian].Add("only lettuce", "სალათის ფურწლით");
        languageDictionary[Language.Georgian].Add("only tomato", "პამიდორით");
        languageDictionary[Language.Georgian].Add("only onion", "ხახვით");
        languageDictionary[Language.Georgian].Add("lettuce and tomato", "სალათის ფურწლით და პამიდორით");
        languageDictionary[Language.Georgian].Add("lettuce and onion", "სალათის ფურწლით და ხახვით");
        languageDictionary[Language.Georgian].Add("tomato and onion", "პამიდორით და ხახვით");
        languageDictionary[Language.Georgian].Add("lettuce, tomato, and onion", "სალათით, პამიდორით,\nდა ხახვით");
        languageDictionary[Language.Georgian].Add("Thank you!", "მადლობა!");
        languageDictionary[Language.Georgian].Add("That's not what I want!", "არა!");

        languageDictionary[Language.Georgian].Add("beer", " და ერთი ლუდი.");
        languageDictionary[Language.Georgian].Add("water", " და ერთი წყალი.");
        languageDictionary[Language.Georgian].Add("red wine", " და ერთი წითელი ღვინო.");
        languageDictionary[Language.Georgian].Add("white wine", " და ერთი თეთრი ღვინო.");

        languageDictionary.Add(Language.Turkish, new Dictionary<string, string>());
        languageDictionary[Language.Turkish].Add("a", "Bir adet ");
        languageDictionary[Language.Turkish].Add("with only lettuce", "marullu ");
        languageDictionary[Language.Turkish].Add("with only tomato", "domatesli ");
        languageDictionary[Language.Turkish].Add("with only onion", "soğanlı ");
        languageDictionary[Language.Turkish].Add("with lettuce and tomato", "marullu ve domatesli ");
        languageDictionary[Language.Turkish].Add("with lettuce and onion", "marullu ve soğanlı ");
        languageDictionary[Language.Turkish].Add("with tomato and onion", "domatesli ve soğanlı ");
        languageDictionary[Language.Turkish].Add("with lettuce, tomato, and onion", "marullu, domatesli, ve soğanlı ");
        languageDictionary[Language.Turkish].Add("Thank you!", "Teşekkür ederim!");
        languageDictionary[Language.Turkish].Add("That's not what I want!", "İstediğim bu değil!");
        languageDictionary[Language.Turkish].Add("I want", " istiyorum.");

        languageDictionary[Language.Turkish].Add("beer", " Ve bira");
        languageDictionary[Language.Turkish].Add("water", " Ve su");
        languageDictionary[Language.Turkish].Add("red wine", " Ve kırmızı şarap");
        languageDictionary[Language.Turkish].Add("white wine", " Ve beyaz şarap");

        //study screen
        languageDictionary[Language.English].Add("I would like a", "I would like a");
        languageDictionary[Language.English].Add("hamburger", "hamburger");
        languageDictionary[Language.English].Add("lettuce", "lettuce");
        languageDictionary[Language.English].Add("tomato", "tomato");
        languageDictionary[Language.English].Add("onion", "onion");

        languageDictionary[Language.Albanian].Add("I would like a", "Unë dua një");
        languageDictionary[Language.Albanian].Add("hamburger", "hamburger");
        languageDictionary[Language.Albanian].Add("lettuce", "marule");
        languageDictionary[Language.Albanian].Add("tomato", "domate");
        languageDictionary[Language.Albanian].Add("onion", "qepë");

        languageDictionary[Language.Georgian].Add("I would like a", "ერთი ______ თუ შეიძლება");
        languageDictionary[Language.Georgian].Add("hamburger", "ჰამბურგერი");
        languageDictionary[Language.Georgian].Add("chicken doner", "ქათმის შაურმა");
        languageDictionary[Language.Georgian].Add("lettuce", "სალათის ფურწლი");
        languageDictionary[Language.Georgian].Add("tomato", "პამიდორი");
        languageDictionary[Language.Georgian].Add("onion", "ხახვი");

        languageDictionary[Language.Turkish].Add("I would like a", "Bir adet ______ istiyorum");
        languageDictionary[Language.Turkish].Add("hamburger", "hamburger");
        languageDictionary[Language.Turkish].Add("chicken doner", "tavuk döner");
        languageDictionary[Language.Turkish].Add("lettuce", "marul");
        languageDictionary[Language.Turkish].Add("tomato", "domates");
        languageDictionary[Language.Turkish].Add("onion", "soğan");
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
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një hamburger", iWouldLikeAHamburgerAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një hamburger me marule.", iWouldLikeAHamburgerWithLettuceAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një hamburger me domate.", iWouldLikeAHamburgerWithTomatoAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një hamburger me qepë.", iWouldLikeAHamburgerWithOnionAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një hamburger me marule dhe domate.", iWouldLikeAHamburgerWithLettuceAndTomatoAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një hamburger me marule dhe qepë.", iWouldLikeAHamburgerWithLettuceAndOnionAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një hamburger me domate dhe qepë.", iWouldLikeAHamburgerWithTomatoAndOnionAlbanianPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një hamburger me marule, tomato, dhe qepë.", iWouldLikeAHamburgerWithLettuceTomatoAndOnionAlbanianPrompt);

        audioLanguageDictionary[Language.Albanian].Add("Unë dua një doner pule", albanianIWouldLikeAChickenDonerPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një doner pule me marule.", albanianIWouldLikeAChickenDonerWithLettucePrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një doner pule me domate.", albanianIWouldLikeAChickenDonerWithTomatoPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një doner pule me qepë.", albanianIWouldLikeAChickenDonerWithOnionPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një doner pule me marule dhe domate.", albanianIWouldLikeAChickenDonerWithLettuceAndTomatoPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një doner pule me marule dhe qepë.", albanianIWouldLikeAChickenDonerWithLettuceAndOnionPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një doner pule me domate dhe qepë.", albanianIWouldLikeAChickenDonerWithTomatoAndOnionPrompt);
        audioLanguageDictionary[Language.Albanian].Add("Unë dua një doner pule me marule, tomato, dhe qepë.", albanianWouldLikeAChickenDonerWithLettuceTomatoAndOnionPrompt);
        #endregion
    }

}
