using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenarater : MonoBehaviour
{
    [SerializeField] Bomb bombPrefab;
    [SerializeField] int numberOfInitialGeneration = 5;

    [SerializeField] Vector2 upperLeft = new Vector2(-0.5f, -0.5f);
    [SerializeField] Vector2 lowerRight = new Vector2(0.5f, 0.5f);

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        for (int i = 0; i < numberOfInitialGeneration; i++)
        {
            GameObject generateBomb = Instantiate(bombPrefab.gameObject);

            float generatePosX = Random.Range(upperLeft.x, lowerRight.x);
            float generatePosY = Random.Range(upperLeft.y, lowerRight.y);

            var worldPoint = transform.TransformPoint(new Vector2(generatePosX,generatePosY));

            generateBomb.transform.position = worldPoint;
        }


    }


}
