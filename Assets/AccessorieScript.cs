using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorieScript : MonoBehaviour
{
    private Transform parentCustomerTransform;

    public float myXPositionWhenRotated;
    public float myYPositionWhenRotated;

    public float myXPositionWhenWaiting;
    public float myYPositionWhenWaiting;

    public Vector2 startingPosition;

    private void Start()
    {
        startingPosition = gameObject.transform.position;

        parentCustomerTransform = transform.root;
        float xOffset = parentCustomerTransform.position.x + myXPositionWhenRotated;
        float yOffset = parentCustomerTransform.position.y + myYPositionWhenRotated;
        transform.position = new Vector2(xOffset,yOffset);
    }
}
