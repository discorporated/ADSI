using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]

public class mainClimb : MonoBehaviour
{

    public Climber RightHand;
    public Climber LeftHand;
    public SteamVR_Action_Boolean ToggleGripButton;
    public SteamVR_Action_Pose position;
    public ConfigurableJoint CliberHandle;

    private bool climbing;
    private Climber ActiveHand;

    
    // Update is called once per frame
    void Update()
    {
        updateHand(RightHand);
        updateHand(LeftHand);
        if (climbing)
        {
            CliberHandle.targetPosition = -ActiveHand.transform.localPosition;

        }
    }
    void updateHand(Climber Hand)
    {
        if (climbing && Hand==ActiveHand)
        {
            if(ToggleGripButton.GetStateUp(Hand.Hand))
            {
                CliberHandle.connectedBody = null;
                climbing = false;

                GetComponent<Rigidbody>().useGravity = true;
            }
        }
        else
        {
            if (ToggleGripButton.GetStateDown(Hand.Hand)||Hand.grabbing)
            {
                Hand.grabbing = true;
                if (Hand.TouchedCount>0)
                {
                    ActiveHand = Hand;
                    climbing = true;
                    CliberHandle.transform.position = Hand.transform.position;
                    GetComponent<Rigidbody>().useGravity = false;
                    CliberHandle.connectedBody = GetComponent<Rigidbody>();
                    Hand.grabbing = false;
                }
                  
            }
        }
    }
}
