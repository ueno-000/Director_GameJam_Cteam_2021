using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    Image fade;

    bool addFlag = false;

    [SerializeField]
    float fadespeed = 1;

    float red = 0;
    float green = 0;
    float blue = 0;
    float add = 0;

    void Start()
    {
        fade = GetComponent<Image>();
        red = fade.color.r;
        green = fade.color.g;
        blue = fade.color.b;
        add = fade.color.a;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            addFlag = true;
        }
        if (addFlag == true)
        {
            addfadein();
        }
    }

    void addfadein()
    {
        setadd();
        if (add < 1)
        {
            add += fadespeed;
        }
        else
        {
            SceneManager.LoadScene("result");
           
        }
    }
    void setadd()
    {
        GetComponent<Image>().color = new Color(red, green, blue, add);
    }
}
