using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ButtonItemInfo : MonoBehaviour
{
    public GameObject canvas;
    
    [Header("SteamVR_Input")]
    public SteamVR_Input_Sources m_Source = SteamVR_Input_Sources.RightHand;
    public SteamVR_Action_Boolean m_Click = null;

    private bool isActive = false;
    
    public void Update()
    {
        if (m_Click.GetStateDown(m_Source))
        {
            if (isActive)
            { 
                canvas.SetActive(false);
                isActive = false;
            }
            else
            {
                canvas.SetActive(true);
                isActive = true;
            }
        }
    }

    public void Detach()
    {
        isActive = false;
    }
}
