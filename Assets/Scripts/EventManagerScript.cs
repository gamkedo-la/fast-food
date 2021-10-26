using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManagerScript 
{
    #region Events

    //utility
    //public static UnityEvent initializeLevel = new UnityEvent();
    //public static UnityEvent levelInitializationFinishedEvent = new UnityEvent();
    //customers
    public static UnityEvent customerEntersRestaurantEvent = new UnityEvent();
    public static UnityEvent customerExitsRestaurantEvent = new UnityEvent();
    //chef
    //public static UnityEvent chefPicksUpHamburgerEvent = new UnityEvent();
    //public static UnityEvent chefPicksUpLettuceEvent = new UnityEvent();
    //public static UnityEvent chefPicksUpTomatoeEvent = new UnityEvent();
    //public static UnityEvent chefPicksUpOnionEvent = new UnityEvent();
    //order submission
    public static UnityEvent correctOrderSubmissionEvent = new UnityEvent();
    public static UnityEvent incorrectOrderSubmissionEvent = new UnityEvent();
    public static UnityEvent anyOrderSubmissionEvent = new UnityEvent();
    public static UnityEvent burgerSubmissionEvent = new UnityEvent();
    public static UnityEvent chickenDonerSubmissionEvent = new UnityEvent();
    public static UnityEvent lostCustomerEvent = new UnityEvent();
    public static UnityEvent levelCompletedEvent = new UnityEvent();
    public static UnityEvent suggestReviewToPlayerEvent = new UnityEvent();

    //public static UnityEvent playerSelectsBurgerEvent = new UnityEvent();
    //public static UnityEvent playerSelectsChickenDonerEvent = new UnityEvent();

    public static UnityEvent timerRanOutOfTimeEvent = new UnityEvent();

    public static UnityEvent customerLosingPatienceEvent = new UnityEvent();
    
    #endregion

    public static void AddEventHandlerToTargetEvent(UnityEvent targetEvent, UnityAction handlerToAdd)
    {
        targetEvent.AddListener(handlerToAdd);
    }
}
