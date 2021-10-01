using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToppingOnCountertopScript : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    public virtual void Start()
    {
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyBurgerSubmissionEvent, Reappear);
    }

    private void Reappear()
    {
        mySpriteRenderer.enabled = true;
    }

    protected void Disappear()
    {
        mySpriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chef" && GameManagerScript.chefHasBurger)
        {
            HandleChefPicksMeUpEvent();
        }
    }

    public virtual void HandleChefPicksMeUpEvent()
    {
    }
}
