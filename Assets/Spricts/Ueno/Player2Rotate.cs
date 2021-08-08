using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Rotate : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //transform.Rotate(0, 0, x);
            transform.localEulerAngles = new Vector3(0, 0, 40);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //transform.Rotate(0, 0, x);
            transform.localEulerAngles = new Vector3(0, 0, -140);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //transform.Rotate(0, 0, x);
            transform.localEulerAngles = new Vector3(0, 0, -50);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            //transform.Rotate(0, 0, x);
            transform.localEulerAngles = new Vector3(0, 0, 130);
        }
    }


}

