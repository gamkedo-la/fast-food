using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFoodScript : MonoBehaviour
{
    #region Fields

    [SerializeField] private BaseFoodScriptableObject baseFoodScriptableObject;

    [SerializeField] private string englishWord;

    private Vector2 startingPositionVector2;

    [SerializeField] private Sprite baseFoodImage;
    private SpriteRenderer baseFoodSpriteRenderer;
    [SerializeField] private Sprite topping1Image;
    private SpriteRenderer topping1SpriteRenderer;
    [SerializeField] private Sprite topping2Image;
    private SpriteRenderer topping2SpriteRenderer;
    [SerializeField] private Sprite topping3Image;
    private SpriteRenderer topping3SpriteRenderer;

    #endregion

    private void OnValidate()
    {
        if (baseFoodScriptableObject != null)
        {
            englishWord = baseFoodScriptableObject.englishWord;

            baseFoodSpriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
            topping1SpriteRenderer = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
            topping2SpriteRenderer = gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>();
            topping3SpriteRenderer = gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>();

            baseFoodImage = baseFoodScriptableObject.baseFoodImage;
            topping1Image = baseFoodScriptableObject.topping1Image;
            topping2Image = baseFoodScriptableObject.topping2Image;
            topping3Image = baseFoodScriptableObject.topping3Image;

            baseFoodSpriteRenderer.sprite = baseFoodImage;
            topping1SpriteRenderer.sprite = topping1Image;
            topping2SpriteRenderer.sprite = topping2Image;
            topping3SpriteRenderer.sprite = topping3Image;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startingPositionVector2 = gameObject.transform.position;

        gameObject.GetComponent<SpriteRenderer>().sprite = baseFoodImage;

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpHamburgerEvent, HandleChefPicksUpBurgerEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyBurgerSubmissionEvent, ResetBurger);
    }

    private void HandleChefPicksUpBurgerEvent()
    {
        GameManagerScript.chefHasBurger = true;

        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage][englishWord]);
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

        baseFoodSpriteRenderer.enabled = false;
        topping1SpriteRenderer.enabled = false;
        topping2SpriteRenderer.enabled = false;
        topping3SpriteRenderer.enabled = false;
    }
}
