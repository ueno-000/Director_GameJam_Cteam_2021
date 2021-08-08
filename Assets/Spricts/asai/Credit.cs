using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public GameObject image;
    bool creditdispryed = false;

    void Start()
    {
        image.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (creditdispryed == true)
            {
                image.SetActive(false);
                creditdispryed = false;
            }
            else
            {
                image.SetActive(true);
                creditdispryed = true;
            }            
        }      
    }
}
