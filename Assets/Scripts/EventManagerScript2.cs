using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages connections between event listeners and event invokers
/// </summary>
public static class EventManagerScript2
{
    #region Fields
    public static List<HamburgerBaseFoodScript> listOfPlayerPicksUpHamburgerEventInvokerFields = new List<HamburgerBaseFoodScript>();
    public static List<UnityAction> listOfPlayerPicksUpHamburgerEventHandlerFields = new List<UnityAction>();

    public static List<FullHeadOfLettuceScript> listOfPlayerPicksUpLettuceEventInvokerFields = new List<FullHeadOfLettuceScript>();
    public static List<UnityAction> listOfPlayerPicksUpLettuceEventHandlerFields = new List<UnityAction>();
    #endregion

    #region Methods

    #region Pick up hamburger event
    public static void AddPlayerPicksUpHamburgerEventInvoker(HamburgerBaseFoodScript playerPicksUpHamburgerEventInvokerArgument)
    {
        listOfPlayerPicksUpHamburgerEventInvokerFields.Add(playerPicksUpHamburgerEventInvokerArgument);
        foreach (UnityAction handler in listOfPlayerPicksUpHamburgerEventHandlerFields)
        {
            playerPicksUpHamburgerEventInvokerArgument.AddPlayerPicksUpHamburgerEventHandler(handler);
        }
    }

    public static void AddPlayerPicksUpHamburgerEventHandler(UnityAction eventHandlerArgument)
    {
        listOfPlayerPicksUpHamburgerEventHandlerFields.Add(eventHandlerArgument);
        foreach (HamburgerBaseFoodScript invoker in listOfPlayerPicksUpHamburgerEventInvokerFields)
        {
            invoker.AddPlayerPicksUpHamburgerEventHandler(eventHandlerArgument);
        }
    }
    #endregion

    #region Pick up lettuce event
    public static void AddPlayerPicksUpLettuceEventInvoker(FullHeadOfLettuceScript playerPicksUpLettuceEventInvokerArgument)
    {
        listOfPlayerPicksUpLettuceEventInvokerFields.Add(playerPicksUpLettuceEventInvokerArgument);
        foreach (UnityAction handler in listOfPlayerPicksUpLettuceEventHandlerFields)
        {
            playerPicksUpLettuceEventInvokerArgument.AddPlayerPicksUpLettuceEventHandler(handler);
        }
    }

    
    public static void AddPlayerPicksUpLettuceEventHandler(UnityAction eventHandlerArgument)
    {
        listOfPlayerPicksUpHamburgerEventHandlerFields.Add(eventHandlerArgument);
        foreach (FullHeadOfLettuceScript invoker in listOfPlayerPicksUpLettuceEventInvokerFields)
        {
            invoker.AddPlayerPicksUpLettuceEventHandler(eventHandlerArgument);
        }
    }
    #endregion

    #endregion
}
