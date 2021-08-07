using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] int hp = 50;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp--;
            if (hp <= 0)
            {
                Explosion();
                Destroy(this.gameObject);
                Destroy(this);
            }
        }
    }

    public void Explosion()
    {
        //ジェネレート

    }

}
