using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDonerBaseFoodScript : BaseFoodScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.playerSelectsChickenDonerEvent, HandlePlayerSelectsBaseFoodEvent);
    }

    public override void HandlePlayerSelectsBaseFoodEvent()
    {
        base.HandlePlayerSelectsBaseFoodEvent();

        if (gameObject.name == "ChickenDonerScriptablePrefab")
        {
            GameManagerScript.chefHasChickenDoner = true;
        }
    }

    public override void ResetBaseFood()
    {
        base.ResetBaseFood();
        if (gameObject.name == "ChickenDonerScriptablePrefab")
        {
            GameManagerScript.chefHasChickenDoner = false;
            GameManagerScript.chickenDonerHasLettuce = false;
            GameManagerScript.chickenDonerHasTomatoe = false;
            GameManagerScript.chickenDonerHasOnion = false;
        }   
    }
}
