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

    #region Level Initialization Events

    public static List<LevelStarterScript> listOfLevelInitializationEventInvokerFields = new List<LevelStarterScript>();
    public static List<UnityAction> listOfLevelInitializationEventHandlerFields = new List<UnityAction>();

    public static List<LevelStarterScript> listOfLevelInitializationFinishedEventInvokerFields = new List<LevelStarterScript>();
    public static List<UnityAction> listOfLevelInitializationFinishedEventHandlerFields = new List<UnityAction>();

    #endregion

    #region Player Selects Food Item Events
    public static List<HamburgerBaseFoodScript> listOfPlayerPicksUpHamburgerEventInvokerFields = new List<HamburgerBaseFoodScript>();
    public static List<UnityAction> listOfPlayerPicksUpHamburgerEventHandlerFields = new List<UnityAction>();

    public static List<FullHeadOfLettuceScript> listOfPlayerPicksUpLettuceEventInvokerFields = new List<FullHeadOfLettuceScript>();
    public static List<UnityAction> listOfPlayerPicksUpLettuceEventHandlerFields = new List<UnityAction>();

    public static List<FullTomatoeScript> listOfPlayerPicksUpTomatoEventInvokerFields = new List<FullTomatoeScript>();
    public static List<UnityAction> listOfPlayerPicksUpTomatoEventHandlerFields = new List<UnityAction>();

    public static List<FullOnionScript> listOfPlayerPicksUpOnionEventInvokerFields = new List<FullOnionScript>();
    public static List<UnityAction> listOfPlayerPicksUpOnionEventHandlerFields = new List<UnityAction>();

    public static List<ChickenDonerBaseFoodScript> listOfPlayerPicksUpChickenDonerEventInvokerFields = new List<ChickenDonerBaseFoodScript>();
    public static List<UnityAction> listOfPlayerPicksUpChickenDonerEventHandlerFields = new List<UnityAction>();
    #endregion
    #endregion

    #region Methods

    #region Level Initialization Methods
    public static void AddLevelInitializationEventInvoker(LevelStarterScript levelInitializationEventInvokerArgument)
    {
        listOfLevelInitializationEventInvokerFields.Add(levelInitializationEventInvokerArgument);
        foreach (UnityAction handler in listOfLevelInitializationEventHandlerFields)
        {
            levelInitializationEventInvokerArgument.AddLevelInitializationEventHandler(handler);
        }
    }

    public static void AddLevelInitialzationEventHandler(UnityAction eventHandlerArgument)
    {
        listOfLevelInitializationEventHandlerFields.Add(eventHandlerArgument);
        foreach (LevelStarterScript invoker in listOfLevelInitializationEventInvokerFields)
        {
            invoker.AddLevelInitializationEventHandler(eventHandlerArgument);
        }
    }


    public static void AddLevelInitializationFinishedEventInvoker(LevelStarterScript levelInitializationFinishedEventInvokerArgument)
    {
        listOfLevelInitializationFinishedEventInvokerFields.Add(levelInitializationFinishedEventInvokerArgument);
        foreach (UnityAction handler in listOfLevelInitializationFinishedEventHandlerFields)
        {
            levelInitializationFinishedEventInvokerArgument.AddLevelInitializationFinishedEventHandler(handler);
        }
    }

    public static void AddLevelInitialzationFinishedFinishedEventHandler(UnityAction eventHandlerArgument)
    {
        listOfLevelInitializationFinishedEventHandlerFields.Add(eventHandlerArgument);
        foreach (LevelStarterScript invoker in listOfLevelInitializationFinishedEventInvokerFields)
        {
            invoker.AddLevelInitializationFinishedEventHandler(eventHandlerArgument);
        }
    }

    #endregion
    #region Player Selects Food Item Methods
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

    #region Player picks up chicken doner

    public static void AddPlayerPicksUpChickenDonerEventInvoker(ChickenDonerBaseFoodScript playerPicksUpChickenDonerEventInvokerArgument)
    {
        listOfPlayerPicksUpChickenDonerEventInvokerFields.Add(playerPicksUpChickenDonerEventInvokerArgument);
        foreach (UnityAction handler in listOfPlayerPicksUpChickenDonerEventHandlerFields)
        {
            playerPicksUpChickenDonerEventInvokerArgument.AddPlayerPicksUpChickenDonerEventHandler(handler);
        }
    }


    public static void AddPlayerPicksUpChickenDonerEventHandler(UnityAction eventHandlerArgument)
    {
        listOfPlayerPicksUpChickenDonerEventHandlerFields.Add(eventHandlerArgument);
        foreach (ChickenDonerBaseFoodScript invoker in listOfPlayerPicksUpChickenDonerEventInvokerFields)
        {
            invoker.AddPlayerPicksUpChickenDonerEventHandler(eventHandlerArgument);
        }
    }
    #endregion

    #endregion

    #endregion
}
