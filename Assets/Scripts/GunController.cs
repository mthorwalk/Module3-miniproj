using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GunController : MonoBehaviour
{

    public SteamVR_Action_Boolean shootAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "Shoot");

    private bool shoot;
    private SteamVR_Input_Sources hand;
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {

        if (interactable.attachedToHand)
        {
            interactable.handFollowTransform = true;

            hand = interactable.attachedToHand.handType;
            Debug.Log("Gun Update + " + shootAction[hand].state);
            if (shootAction[hand].state)
            {
                Debug.Log("this is a test ahhhhhhhhhhhhhhhhhhhh");
            }
        }
    }
}
