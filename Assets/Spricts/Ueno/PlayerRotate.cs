using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //transform.Rotate(0, 0, x);
            transform.localEulerAngles = new Vector3(0, 0, 40);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //transform.Rotate(0, 0, x);
            transform.localEulerAngles = new Vector3(0, 0, -140);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //transform.Rotate(0, 0, x);
            transform.localEulerAngles = new Vector3(0, 0, -50);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //transform.Rotate(0, 0, x);
            transform.localEulerAngles = new Vector3(0, 0, 130);
        }
    }
      
        
}
