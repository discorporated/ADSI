using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Climber : MonoBehaviour
{

    public SteamVR_Input_Sources Hand;
    public int TouchedCount;
    public bool grabbing;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            TouchedCount++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Climbable"))
        {
            TouchedCount--;
        }
    }

}
