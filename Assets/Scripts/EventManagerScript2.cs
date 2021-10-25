using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages connections between event listeners and event invokers
/// </summary>
public static class EventManagerScript2
{
    public static HamburgerBaseFoodScript playerPicksUpHamburgerEventInvokerField;
    public static UnityAction playerPicksUpHamburgerEventHandlerField;

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
}
