using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelOne
{
    public class CrystalManager : MonoBehaviour
    {
        public Gun gun;
        public GameObject crystalPrefab;
        public float spawnTimeFew = 10f;
        public float spawnTimeMore = 5f;
        public int countCrystalsToDestroy = 20;

        public List<GameObject> crystals = new List<GameObject>();
        private int[,] arr = new int[10, 10];

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
        }

        private IEnumerator LifeCrystal()
        {
            while (gun.countDestroyCrystals <= countCrystalsToDestroy)
            {
                if (crystals.Count < 5) yield return new WaitForSeconds(spawnTimeFew);
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
    }
}