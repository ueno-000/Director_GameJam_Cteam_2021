using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] int hp = 50;

    [SerializeField] bulletGenerater bulletGenerater;

    public int id = 0;

    public delegate void BombsDestructor(int id);

    public BombsDestructor bombsDestructor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bullet2")
        {
            hp--;
            if (hp <= 0)
            {
                Explosion();
                bombsDestructor(id);
                Destroy(this.gameObject);
                Destroy(this);
            }
        }
    }

    public void Explosion()
    {
        //ジェネレート
        Debug.Log("爆弾爆破");
        for (int i = 0; i < 360; i += 20)
        {
            bulletGenerater.bulletShot(i , this.transform.position);

        }
    }

}
