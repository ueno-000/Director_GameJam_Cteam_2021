using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title2 : MonoBehaviour
{
    private Image image;

    bool addFlag = false;

    [SerializeField]
    float fadespeed = 0.01f;
   
    float image_red;
    float image_green;
    float image_blue;
    float image_transparent;

 
    void Start()
    {
        
        image = GetComponent<Image>();
        image_red = image.color.r;
        image_green = image.color.g;
        image_blue = image.color.b;
        image_transparent = image.color.a;
    }
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            addFlag = true;
        }

        if (addFlag == false)
        {
            addfadein();

        }
        else
        {
            //Debug.Log("a");

            addfadeout();
        }
       
    }

    void addfadeout()
    {
        setTransparent_fade();
        if (image_transparent < 1)
        {
            image_transparent += fadespeed;
        }
        else
        {
            
            SceneManager.LoadScene("MasterGameScene");//仮
        }
    }

    void addfadein()
    {
        setTransparent_fade();
        {
            image_transparent -= fadespeed;
        }

    }
    void setTransparent_fade()
    {
        GetComponent<Image>().color = new Color(image_red, image_green, image_blue, image_transparent);
    }  
}
