using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManagerScript 
{
    public static string currentLanguage = "English";

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
}
