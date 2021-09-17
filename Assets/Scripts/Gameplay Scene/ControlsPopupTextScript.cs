using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPopupTextScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyMeAfterAFewSeconds());
    }

    IEnumerator DestroyMeAfterAFewSeconds()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
