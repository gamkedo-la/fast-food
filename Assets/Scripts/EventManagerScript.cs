using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManagerScript 
{
    #region Events
    public static UnityEvent customerEntersRestaurantEvent = new UnityEvent();
    public static UnityEvent customerExitsRestaurantEvent = new UnityEvent();

    public static UnityEvent chefPicksUpHamburgerEvent = new UnityEvent();

    public static UnityEvent correctOrderSubmissionEvent = new UnityEvent();
    public static UnityEvent incorrectOrderSubmissionEvent = new UnityEvent();
    public static UnityEvent anyBurgerSubmissionEvent = new UnityEvent();

    #endregion

    public static void AddEventHandlerToTargetEvent(UnityEvent targetEvent, UnityAction handlerToAdd)
    {
        targetEvent.AddListener(handlerToAdd);
    }
}