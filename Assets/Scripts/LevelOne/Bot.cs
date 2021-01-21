using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelOne
{
    public class Bot : MonoBehaviour
    {
        public GameController gameController;
        
        [Header("Gun")]
        public GameObject gun;
        public GameObject materia;
        
        private Animator animator;
    
        void Start()
        {
            gun.SetActive(false);
            materia.SetActive(false);
            animator = GetComponent<Animator>();
        }

        void Update()
        {
        
        }
    }
}

