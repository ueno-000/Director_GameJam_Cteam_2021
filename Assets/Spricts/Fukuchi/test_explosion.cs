using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_explosion : MonoBehaviour
{
    [SerializeField] bulletGenerater bulletBomb;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 360; i += 50)
        {
            bulletBomb.bulletShot(i, this.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
