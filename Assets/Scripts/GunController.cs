using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GunController : MonoBehaviour
{

    public SteamVR_Action_Boolean shootAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "Shoot");

    private bool shoot;
    private SteamVR_Input_Sources rightHand;

    // Start is called before the first frame update
    void Start()
    {
        rightHand = SteamVR_Input_Sources.RightHand;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootAction[rightHand].stateDown)
        {
            Debug.Log("this is a test ahhhhhhhhhhhhhhhhhhhh");
        }
    }

}
