using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾を制御するコンポーネント
/// 出現時のプレイヤーの位置を検出して、その方向に等速直線運動する
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    public PlayerController enemy;

    void Start()
    {
        // 速度ベクトルを求める
       // GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (enemy)
        {
            Vector2 v = enemy.transform.position - this.transform.position;
            v = v.normalized * m_speed;

            // 速度ベクトルをセットする
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }
        else
        {
            // プレイヤーが居なかったら、すぐ消してしまう
            Destroy(this.gameObject);
        }
    }
}
