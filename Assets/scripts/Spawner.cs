using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    const int maxCoins = 10;
    [SerializeField] GameObject coin;

    void Start()
    {
        Spawn();

    }

    void Spawn()
    {
        //int xMin = -12;
        //int xMax = 12;
        //int yMin = -6;
        //int yMax = 2;

        //for (int i = 0; i < maxCoins; i++)
        //{
        //    Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        //    Instantiate(coin, position, Quaternion.identity);
        //}

        for (int i = 0; i < maxCoins; i++)
        {
            int posX = Random.Range(-10, 10);
            int posY = Random.Range(-4, 2);
            int posz = 10;
            Vector3 pos = new Vector3(posX, posY, posz);
            GameObject go = Instantiate(coin, pos, Quaternion.identity);
            go.transform.SetParent(gameObject.transform);
            //go.transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
