using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerScript : MonoBehaviour
{
    #region Fields

    [SerializeField] SpriteRenderer lettuceSpriteRenderer;
    [SerializeField] SpriteRenderer tomatoeSpriteRenderer;
    [SerializeField] SpriteRenderer onionSpriteRenderer;

    private Vector2 startingPositionVector2;

    #endregion

    private void Start()
    {
        startingPositionVector2 = gameObject.transform.position;

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpHamburgerEvent, HandleChefPicksUpBurgerEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyBurgerSubmissionEvent, ResetBurger);
    }

    private void HandleChefPicksUpBurgerEvent()
    {
        GameManagerScript.chefHasBurger = true;

        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["hamburger"]);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chef")
        {
            EventManagerScript.chefPicksUpHamburgerEvent.Invoke();
        }
    }

    public void ResetBurger()
    {
        gameObject.transform.position = startingPositionVector2;
        GameManagerScript.chefHasBurger = false;
        GameManagerScript.playerIsDraggingChef = false;

        GameManagerScript.burgerHasLettuce = false;
        GameManagerScript.burgerHasTomatoe = false;
        GameManagerScript.burgerHasOnion = false;
    }
}
