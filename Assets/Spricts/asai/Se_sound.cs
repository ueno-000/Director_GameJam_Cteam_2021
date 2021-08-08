using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Se_sound : MonoBehaviour
{
    private AudioSource sound0;
    // Start is called before the first frame update
    void Start()
    {
        sound0 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            sound0.PlayOneShot(sound0.clip);

        }
    }
}
