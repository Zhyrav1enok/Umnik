using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    public GameObject crystalPrefab;
    public float spawnTimeFew = 10f;
    public float spawnTimeMore = 5f;

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
        while (crystals.Count < 100)
        {
            if (crystals.Count < 5) yield return new WaitForSeconds(spawnTimeFew);
            else yield return new WaitForSeconds(spawnTimeMore);
            int randCryst = Random.Range(0, crystals.Count);
            Vector3 coord = PositionSet(crystals[randCryst].transform.position);
            GameObject crystal = Instantiate(crystalPrefab, coord, Quaternion.identity);
            crystals.Add(crystal);
        }
    }

    private Vector3 PositionSet(Vector3 position)
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


        // int randX = Random.Range(0, 10);
        // int randY = Random.Range(0, 10);
        //
        // if (arr[randX, randY] == 1)
        // {
        //     
        // }

        // List<bool> sides = new List<bool>();
        // int[] sidesInt = new[] {0, 0, 0, 0,};
        // bool isLeft = false;
        // bool isRight = false;
        // bool isDown = false;
        // bool isUp = false;
        //
        // foreach (GameObject crystal in crystals)
        // {
        //     if ((int)position.x + 1 == (int)crystal.transform.position.x) isLeft = true;
        //     if ((int)position.x - 1 == (int)crystal.transform.position.x) isRight = true;
        //     if ((int)position.z + 1 == (int)crystal.transform.position.z) isDown = true;
        //     if ((int)position.z - 1 == (int)crystal.transform.position.z) isUp = true;
        // }
        //
        // if (!isLeft)
        // {
        //     sides.Add(isLeft);
        //     sidesInt[0] = 1;
        // }
        //
        // if (!isRight)
        // {
        //     sides.Add(isRight);
        //     sidesInt[1] = 2;
        // }
        //
        // if (!isDown)
        // {
        //     sides.Add(isDown);
        //     sidesInt[2] = 3;
        // }
        //
        // if (!isUp)
        // {
        //     sides.Add(isUp);
        //     sidesInt[3] = 4;
        // }
        //
        // //int range = Random.Range(0, sidesInt.Length);
        // //
        // // if (sidesInt[range] != 0) range = sidesInt[range];
        // // else if (range > 0) range = sidesInt[range - 1];
        // // else range = sidesInt[range + 1];
        //
        // int range = 0;
        // while (range == 0)
        // {
        //     range = Random.Range(0, 3);
        //     if (sidesInt[range] != 0) range = sidesInt[range];
        // }
        //
        //
        // switch (range)
        // {
        //     case 1:
        //         return position + Vector3.right;
        //
        //         break;
        //     case 2:
        //         return position + Vector3.left;
        //
        //         break;
        //     case 3:
        //         return position + Vector3.forward;
        //
        //         break;
        //     case 4:
        //         return position + Vector3.back;
        //
        //         break;
        //     default:
        //         return Vector3.zero;
        //         break;
        // }


        // if (sides[range] == isLeft)
        // {
        //     return position + Vector3.right;
        //     sides.Clear();
        // }
        // else if (sides[range] == isRight)
        // {
        //     return position + Vector3.left;
        //     sides.Clear();
        // }
        // else if (sides[range] == isDown)
        // {
        //     return position + Vector3.forward;
        //     sides.Clear();
        // }
        // else if (sides[range] == isUp)
        // {
        //     return position + Vector3.back;
        //     sides.Clear();
        // }
        // else
        // {
        //     return Vector3.zero;
        //     sides.Clear();
        // }
        // sides.Clear();
    }
}