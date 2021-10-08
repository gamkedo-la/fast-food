using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManagerScript 
{
    #region Events

    //utility
    public static UnityEvent initializeLevel = new UnityEvent();
    //customers
    public static UnityEvent customerEntersRestaurantEvent = new UnityEvent();
    public static UnityEvent customerExitsRestaurantEvent = new UnityEvent();
    //chef
    public static UnityEvent chefPicksUpHamburgerEvent = new UnityEvent();
    public static UnityEvent chefPicksUpLettuceEvent = new UnityEvent();
    public static UnityEvent chefPicksUpTomatoeEvent = new UnityEvent();
    public static UnityEvent chefPicksUpOnionEvent = new UnityEvent();
    //order submission
    public static UnityEvent correctOrderSubmissionEvent = new UnityEvent();
    public static UnityEvent incorrectOrderSubmissionEvent = new UnityEvent();
    public static UnityEvent anyBurgerSubmissionEvent = new UnityEvent();
    public static UnityEvent levelCompletedEvent = new UnityEvent();

    public static UnityEvent playerSelectsBurgerEvent = new UnityEvent();

    public static UnityEvent timerRanOutOfTimeEvent = new UnityEvent();
    #endregion

    public static void AddEventHandlerToTargetEvent(UnityEvent targetEvent, UnityAction handlerToAdd)
    {
        targetEvent.AddListener(handlerToAdd);
    }
}
