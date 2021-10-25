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
    public static HamburgerBaseFoodScript playerPicksUpHamburgerEventInvokerField;
    public static UnityAction playerPicksUpHamburgerEventHandlerField;

    public static FullHeadOfLettuceScript playerPicksUpLettuceEventInvokerField;
    public static UnityAction playerPicksUpLettuceEventHandlerField;
    #endregion

    #region Methods
    public static void AddPlayerPicksUpHamburgerEventInvoker(HamburgerBaseFoodScript playerPicksUpHamburgerEventInvokerArgument)
    {
        playerPicksUpHamburgerEventInvokerField = playerPicksUpHamburgerEventInvokerArgument;
        if (playerPicksUpHamburgerEventHandlerField != null)
        {
            playerPicksUpHamburgerEventInvokerField.AddPlayerPicksUpHamburgerEventHandler(playerPicksUpHamburgerEventHandlerField);
        }
    }

    public static void AddPlayerPicksUpHamburgerEventHandler(UnityAction eventHandlerArgument)
    {
        playerPicksUpHamburgerEventHandlerField = eventHandlerArgument;
        if (playerPicksUpHamburgerEventInvokerField != null)
        {
            playerPicksUpHamburgerEventInvokerField.AddPlayerPicksUpHamburgerEventHandler(playerPicksUpHamburgerEventHandlerField);
        }
    }


    public static void AddPlayerPicksUpLettuceEventInvoker(FullHeadOfLettuceScript playerPicksUpLettuceEventInvokerArgument)
    {
        playerPicksUpLettuceEventInvokerField = playerPicksUpLettuceEventInvokerArgument;
        if (playerPicksUpLettuceEventHandlerField != null)
        {
            playerPicksUpLettuceEventInvokerField.AddPlayerPicksUpLettuceEventHandler(playerPicksUpLettuceEventHandlerField);
        }
    }

    public static void AddPlayerPicksUpLettuceEventHandler(UnityAction eventHandlerArgument)
    {
        playerPicksUpLettuceEventHandlerField = eventHandlerArgument;
        if (playerPicksUpLettuceEventInvokerField != null)
        {
            playerPicksUpLettuceEventInvokerField.AddPlayerPicksUpLettuceEventHandler(playerPicksUpLettuceEventHandlerField);
        }
    }
    #endregion
}
