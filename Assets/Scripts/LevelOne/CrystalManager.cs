using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace LevelOne
{
    public class CrystalManager : MonoBehaviour
    {
        public Text timerText;
        public Gun gun;
        public GameObject crystalPrefab;
        public float spawnTimeFew = 10f;
        public float spawnTimeMore = 5f;
        public int countToMoreTime = 10;
        public int countCrystalsToDestroy = 20;

        public List<GameObject> crystals = new List<GameObject>();
        private int[,] arr = new int[10, 10];

        public float time = 180;
        
        void Start()
        {
            StartCoroutine(LifeCrystal());
            GameObject firstCrystal = Instantiate(crystalPrefab, new Vector3(5, 0, 5f), Quaternion.identity);
            crystals.Add(firstCrystal);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    arr[i, j] = 0;
                }
            }

            arr[5, 5] = 1;

            timerText.gameObject.SetActive(true);
            timerText.text = time.ToString();
        }

        private void Update()
        {
            time -= Time.deltaTime;
            timerText.text = Math.Round(time).ToString();

            if (time <= 0)
            {
                //StopCoroutine(LifeCrystal());
                gun.gameController.Lose();
            }
        }

        private IEnumerator LifeCrystal()
        {
            while (gun.countDestroyCrystals <= countCrystalsToDestroy)
            {
                if (crystals.Count < countToMoreTime) yield return new WaitForSeconds(spawnTimeFew);
                else yield return new WaitForSeconds(spawnTimeMore);
                Vector3 coord = PositionSet();
                GameObject crystal = Instantiate(crystalPrefab, coord, Quaternion.identity);
                crystals.Add(crystal);
            }

            while (crystals.Count != 0)
            {
                yield return null;
            }
            gun.gameController.Win();
        }

        private Vector3 PositionSet()
        {
            while (true)
            {
                int randX = Random.Range(0, 10);
                int randZ = Random.Range(0, 10);

                if (arr[randX, randZ] == 0)
                {
                    arr[randX, randZ] = 1;
                    return new Vector3(randX, 0, randZ);
                }
            }
        }

        private void OnDestroy()
        {
            crystals.Clear();
        }
    }
}