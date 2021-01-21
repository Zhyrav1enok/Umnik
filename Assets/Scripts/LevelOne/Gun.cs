using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace LevelOne
{
    public class Gun : MonoBehaviour
    {
        public GameController gameController;
        public CrystalManager crystalManager;
        public Camera cameraGun;
        public GameObject particles;
        public Transform particleSpawnPoint;
        
        [Header("SteamVR_Input")]
        public SteamVR_Input_Sources m_Source = SteamVR_Input_Sources.RightHand;
        public SteamVR_Action_Boolean m_Click = null;

        [HideInInspector]public int countDestroyCrystals = 0;

        public void Update()
        {
            if (m_Click.GetStateDown(m_Source))
            {
                Instantiate(particles, particleSpawnPoint.position, particleSpawnPoint.rotation);
                
                RaycastHit hit;

                if (Physics.Raycast(cameraGun.transform.position, cameraGun.transform.forward, out hit))
                {
                    if (hit.collider.CompareTag("Crystal"))
                    {
                        countDestroyCrystals++;
                        crystalManager.crystals.Remove(hit.collider.gameObject);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}

