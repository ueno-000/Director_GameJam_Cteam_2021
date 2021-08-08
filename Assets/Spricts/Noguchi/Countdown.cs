using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timeCount = 0;
    public int starttime = 5;

    public Image image;

    public Sprite[] countdownImageArray = new Sprite[5];

    bool[] countdownFlag = new bool[7];

    [SerializeField] float imageDefaultScale = 0.4f;

    [SerializeField] PlayerController player1;
    [SerializeField] PlayerController player2;
    [SerializeField] BombGenarater bombGenarater;

    private void Start()

    {
        countdownFlag[0] = false;
        countdownFlag[1] = false;
        countdownFlag[2] = false;
        countdownFlag[3] = false;
        countdownFlag[4] = false;
        countdownFlag[5] = false;
        countdownFlag[6] = false;

    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (countdownFlag[0] == false)
        {
            CountEvent(0);
            countdownFlag[0] = true;
        }
        if (timeCount >= 1 && countdownFlag[1] == false)
        {
            CountEvent(1);
            countdownFlag[1] = true;
        }
        if (timeCount >= 2 && countdownFlag[2] == false)
        {
            CountEvent(2);
            countdownFlag[2] = true;
        }
        if (timeCount >= 3 && countdownFlag[3] == false)
        {
            CountEvent(3);
            countdownFlag[3] = true;
        }
        if (timeCount >= 4 && countdownFlag[4] == false)
        {
            CountEvent(4);
            countdownFlag[4] = true;
        }
        if (timeCount >= 5 && countdownFlag[5] == false)
        {
            CountEvent(5);
            countdownFlag[5] = true;
        }
        if (timeCount >= 6 && countdownFlag[6] == false)
        {
            image.gameObject.SetActive(false);
            StartEvent();
        }
    }
    void CountEvent(int i)
    {
        image.sprite = countdownImageArray[i];
    }

    void StartEvent()
    {
        bombGenarater.isActive = true;

    }

    void ResetSprite()
    {
        image.gameObject.transform.localScale = new Vector2(imageDefaultScale, imageDefaultScale);
        image.color = new Color(1, 1, 1, 1);
    }
}
