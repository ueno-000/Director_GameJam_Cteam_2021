using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGenerater : MonoBehaviour
{
    public GameObject bulletPoint;
    public GameObject bullet;
    public float speed = 30f; //弾の速度

    public Vector2 generatePos;


    //弾を生成するための関数
    public void bulletShot(float x, float y)
    {
        Vector2 bulletPos = bulletPoint.transform.position;
        GameObject newBullet = Instantiate(bullet, bulletPos, transform.rotation);
        //Vector2 dir = newBullet.transform.right;
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y));
        newBullet.name = bullet.name;
        Destroy(newBullet, 2f);
    }


    public void bulletShot(float angle, Vector2 pos)
    {
        Vector3 angleV3 = GetDirection(angle);
        //generatePos = bulletPoint.transform.position;
        GameObject newBullet = Instantiate(bullet, pos, transform.rotation);
        //Vector2 dir = newBullet.transform.right;
        newBullet.GetComponent<Rigidbody2D>().AddForce(angleV3 * 10);
        newBullet.name = bullet.name;
        Destroy(newBullet, 2f);
    }

    // 指定された角度（ 0 ～ 360 ）をベクトルに変換して返す
    public  Vector3 GetDirection(float angle)
    {
        return new Vector3
        (
            Mathf.Cos(angle * Mathf.Deg2Rad) * speed,
            Mathf.Sin(angle * Mathf.Deg2Rad) * speed,
            0
        );
    }

}
