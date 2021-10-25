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

    public static List<FullTomatoeScript> listOfPlayerPicksUpTomatoEventInvokerFields = new List<FullTomatoeScript>();
    public static List<UnityAction> listOfPlayerPicksUpTomatoEventHandlerFields = new List<UnityAction>();

    public static List<FullOnionScript> listOfPlayerPicksUpOnionEventInvokerFields = new List<FullOnionScript>();
    public static List<UnityAction> listOfPlayerPicksUpOnionEventHandlerFields = new List<UnityAction>();
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

    #region Pick up tomato event

    public static void AddPlayerPicksUpTomatoEventInvoker(FullTomatoeScript playerPicksUpTomatoEventInvokerArgument)
    {
        listOfPlayerPicksUpTomatoEventInvokerFields.Add(playerPicksUpTomatoEventInvokerArgument);
        foreach (UnityAction handler in listOfPlayerPicksUpTomatoEventHandlerFields)
        {
            playerPicksUpTomatoEventInvokerArgument.AddPlayerPicksUpTomatoEventHandler(handler);
        }
    }


    public static void AddPlayerPicksUpTomatoEventHandler(UnityAction eventHandlerArgument)
    {
        listOfPlayerPicksUpTomatoEventHandlerFields.Add(eventHandlerArgument);
        foreach (FullTomatoeScript invoker in listOfPlayerPicksUpTomatoEventInvokerFields)
        {
            invoker.AddPlayerPicksUpTomatoEventHandler(eventHandlerArgument);
        }
    }

    #endregion

    #region Player picks up onion event

    public static void AddPlayerPicksUpOnionEventInvoker(FullOnionScript playerPicksUpOnionEventInvokerArgument)
    {
        listOfPlayerPicksUpOnionEventInvokerFields.Add(playerPicksUpOnionEventInvokerArgument);
        foreach (UnityAction handler in listOfPlayerPicksUpOnionEventHandlerFields)
        {
            playerPicksUpOnionEventInvokerArgument.AddPlayerPicksUpOnionEventHandler(handler);
        }
    }


    public static void AddPlayerPicksUpOnionEventHandler(UnityAction eventHandlerArgument)
    {
        listOfPlayerPicksUpOnionEventHandlerFields.Add(eventHandlerArgument);
        foreach (FullOnionScript invoker in listOfPlayerPicksUpOnionEventInvokerFields)
        {
            invoker.AddPlayerPicksUpOnionEventHandler(eventHandlerArgument);
        }
    }

    #endregion
    #endregion
}
