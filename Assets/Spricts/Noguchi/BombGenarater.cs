using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenarater : MonoBehaviour
{
    [SerializeField] Bomb bombPrefab;
    [SerializeField] int numberOfInitialGeneration = 5;

    [SerializeField] Vector2 upperLeft = new Vector2(-0.5f, -0.5f);
    [SerializeField] Vector2 lowerRight = new Vector2(0.5f, 0.5f);

    [SerializeField] float timeCount = 0;
    float generateTime = 5.0f;

    private void Start()
    {
        Setup();
    }

    public void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= generateTime)
        {
            timeCount = 0;
            if (generateTime > 0.2f)
            {
                generateTime -= 0.3f;
            }
            else if (generateTime != 0.2f)
            {
                generateTime = 0.2f;
            }
            float generatePosX = Random.Range(upperLeft.x, lowerRight.x);
            float generatePosY = Random.Range(upperLeft.y, lowerRight.y);
            GenerateBomb(generatePosX, generatePosY);
        }
    }


    public void Setup()
    {

        for (int i = 0; i < numberOfInitialGeneration; i++)
        {
            float generatePosX = Random.Range(upperLeft.x, lowerRight.x);
            float generatePosY = Random.Range(upperLeft.y, lowerRight.y);

            GenerateBomb(generatePosX, generatePosY);
        }
    }

    public void GenerateBomb(float x, float y)
    {
        GameObject generateBomb = Instantiate(bombPrefab.gameObject);

        var worldPoint = transform.TransformPoint(new Vector2(x, y));

        generateBomb.transform.position = worldPoint;
    }
}
