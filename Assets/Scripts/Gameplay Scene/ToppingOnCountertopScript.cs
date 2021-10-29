using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ToppingOnCountertopScript : MonoBehaviour
{
    protected SpriteRenderer mySpriteRenderer;

    private Camera mainCamera;
    private CircleCollider2D toppingOnCountertopCircleCollider;

    private Vector2 currentTouchPositionVector2InScreenPixels;
    private Vector3 currentTouchPositionVector3InWorldUnits;

    // Start is called before the first frame update
    public virtual void Start()
    {
        mainCamera = Camera.main;
        toppingOnCountertopCircleCollider = gameObject.GetComponent<CircleCollider2D>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, Reappear);
    }
    //Android
    public virtual void Update()
    {
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Android)
        {
            return;
        }
        if (Touchscreen.current == null) return; // avoid errors when testing with a mouse
        
        currentTouchPositionVector2InScreenPixels = Touchscreen.current.primaryTouch.position.ReadValue();

        currentTouchPositionVector3InWorldUnits = mainCamera.ScreenToWorldPoint(currentTouchPositionVector2InScreenPixels);

        //prevent the z coordinate from making the chef disappear
        currentTouchPositionVector3InWorldUnits = new Vector3(currentTouchPositionVector3InWorldUnits.x, currentTouchPositionVector3InWorldUnits.y, 0);

        if (toppingOnCountertopCircleCollider.OverlapPoint(currentTouchPositionVector3InWorldUnits))
        {
            HandleChefPicksMeUpEvent();
        }
    }

    public virtual void Reappear()
    {
        
    }

    protected void Disappear()
    {
        mySpriteRenderer.enabled = false;
    }

    public virtual void HandleChefPicksMeUpEvent()
    {
    }

    public virtual void OnMouseUp()
    {

    }
}
