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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chef")
        {
            GameManagerScript.chefHasBurger = true;
            
            Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["hamburger"]);
        }
    }

    public void ResetBurger()
    {
        gameObject.transform.position = startingPositionVector2;
        GameManagerScript.chefHasBurger = false;
        GameManagerScript.playerIsDraggingChef = false;

        lettuceSpriteRenderer.enabled = false;
        tomatoeSpriteRenderer.enabled = false;
        onionSpriteRenderer.enabled = false;

        GameManagerScript.burgerHasLettuce = false;
        GameManagerScript.burgerHasTomatoe = false;
        GameManagerScript.burgerHasOnion = false;
    }
}
