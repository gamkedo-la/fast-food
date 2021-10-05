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
    public static string currentLanguage = "English";

    public static CustomerPromptTypeEnumerables currentCustomerPromptType = CustomerPromptTypeEnumerables.Text;

    public static bool gameIsPaused = false;

    public static bool cameraShouldFollowChef = false;

    public static bool playerIsTouchingScreenBool = false;
    public static bool playerIsTouchingChef = false;
    public static bool playerIsDraggingChef = false;

    public static bool chefHasBurger = false;
    public static float burgerBeingHeldXOffset = 1.0f;

    public static bool burgerHasLettuce = false;
    public static bool burgerHasTomatoe = false;
    public static bool burgerHasOnion = false;

    public static float numberOfCorrectOrders = 0;
    public static float numberOfIncorrectOrders = 0;
    public static float totalSubmittedOrders = 0;
    public static float accuracy = 0;
    public static float speedBonus = 0;

    public static string currentProfile = "Profile 1";

    public static int currentLevel = 1;
    public static int minimumSubmittedOrdersToCompleteLevel1 = 5;
    public static int minimumSubmittedOrdersToCompleteLevel2 = 10;
    public static int minimumSubmittedOrdersToCompleteLevel3 = 15;
    public static int minimumSubmittedOrdersToCompleteCurrentLevel = minimumSubmittedOrdersToCompleteLevel1;
    public static float minimumAccuracyToCompleteLevel = 90.0f;

    public static bool levelStarterFirstTimeStarted = false;
}
