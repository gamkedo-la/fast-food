using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomerPromptTypeEnumerables
{
    Text,
    Audio
}
public static class GameManagerScript 
{
    public static CurrentPlatformEnum currentPlatformEnum;

    public static Language currentLanguage = Language.English;//default for working around bugs

    public static CustomerPromptTypeEnumerables currentCustomerPromptType = CustomerPromptTypeEnumerables.Text;

    public static bool gameIsPaused = false;

    public static bool cameraShouldFollowChef = false;

    public static bool playerIsTouchingScreenBool = false;
    public static bool playerIsTouchingChef = false;
    public static bool playerIsDraggingChef = false;

    public static bool chefHasBaseFood = false;

    public static bool chefHasBurger = false;
    public static bool chefHasChickenDoner = false;
    public static float burgerBeingHeldXOffset = 1.0f;
    public static float burgerBeingHeldYOffset = 1.0f;

    public static bool burgerHasLettuce = false;
    public static bool burgerHasTomatoe = false;
    public static bool burgerHasOnion = false;

    public static bool chefHasBeer = false;
    public static bool chefHasRedWine = false;
    public static bool chefHasWhiteWine = false;
    public static bool chefHasWater = false;

    public static float chickenDonerBeingHeldXOffset = 1.0f;
    public static float chickenDonerBeingHeldYOffset = 0.0f;

    public static bool chickenDonerHasLettuce = false;
    public static bool chickenDonerHasTomatoe = false;
    public static bool chickenDonerHasOnion = false;

    public static float numberOfCorrectOrders = 0;
    public static float numberOfIncorrectOrders = 0;
    public static float totalSubmittedOrders = 0;
    public static float accuracy = 0;
    public static float speedBonus = 0;

    public static ProfileDataScript currentProfile;

    public static int currentLevel = 1;
    public static int currentSpellingLevel = 1;
    public static int currentSentencesLevel = 1;
    public static int currentNumbersLevel = 1;
    public static int currentColorsLevel = 1;
    public static int currentEnglishPhonicsLevel = 1;
    public static int currentAlbanianPhonicsLevel = 1;
    public static int currentGeorgianPhonicsLevel = 1;


    public static int maxSpellingLevel = 5;
    public static int maxSentencesLevel = 8;
    public static int maxNumbersLevel = 5;
    public static int maxColorsLevel = 8;
    public static int maxEnglishPhonicsLevel = 26;
    public static int maxAlbanianPhonicsLevel = 34;
    public static int maxGeorgianPhonicsLevel = 33;

    public static int minimumSubmittedOrdersToCompleteLevel1 = 5;
    public static int minimumSubmittedOrdersToCompleteLevel2 = 10;
    public static int minimumSubmittedOrdersToCompleteLevel3 = 15;
    public static int minimumSubmittedOrdersToCompleteLevel4 = 20;

    public static int minimumSubmittedOrdersToCompleteCurrentLevel = minimumSubmittedOrdersToCompleteLevel1;
    public static float minimumAccuracyToCompleteLevel = 90.0f;

    public static bool levelStarterFirstTimeStarted = false;

    public static bool impatienceSoundIsPlaying = false;

    public static bool shouldIntroduceNewLevel = false;
    public static bool hasIntroducedLevel1 = false;
    public static bool hasIntroducedLevel2 = false;
    public static bool hasIntroducedLevel3 = false;
    public static bool hasIntroducedLevel4 = false;
    public static bool hasIntroducedLevel5 = false;
    public static bool hasIntroducedLevel6 = false;
    public static bool hasIntroducedLevel7 = false;

    public static bool progressToNextLevelEventHasBeenAdded = false;
}
