using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シューティングゲームの自機を操作するためのコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))] // Rigidbody コンポーネントのアタッチを強制する
public class PlayerController : MonoBehaviour
{
    /// <summary>プレイヤーの移動速度</summary>
    [SerializeField] float m_moveSpeed = 5f;
    /// <summary>弾のプレハブ</summary>
    [SerializeField] GameObject m_bulletPrefab = null;
    /// <summary>弾の発射位置</summary>
    [SerializeField] Transform m_muzzle = null;
    /// <summary>一画面の最大段数 (0 = 無制限)</summary>
    [SerializeField, Range(0, 10)] int m_bulletLimit = 0;
    Rigidbody2D m_rb;
    //Helthの設定
    [SerializeField] int hp = 5;
    [SerializeField]HelthController helth;
    [SerializeField] PlayerController enemy;
    [SerializeField] KeyCode key;
    [SerializeField] int id;
  
    AudioSource m_audio = default;
    AudioClip se;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_audio = GetComponent<AudioSource>();
        se = GetComponent<AudioClip>();
    }

    void Update()
    {

        float h = 0;
        float v = 0;

        // 自機を移動させる
        if (id == 1)
        {
             h = Input.GetAxisRaw("Horizontal");   // 垂直方向の入力を取得する
             v = Input.GetAxisRaw("Vertical");     // 水平方向の入力を取得する
           
        }
        else
        {
            h = Input.GetAxisRaw("Horizontal2");   // 垂直方向の入力を取得する
            v = Input.GetAxisRaw("Vertical2");     // 水平方向の入力を取得する
        }
        Vector2 dir = new Vector2(h, v).normalized; // 進行方向の単位ベクトルを作る (dir = direction) 
        m_rb.velocity = dir * m_moveSpeed;        // 単位ベクトルにスピードをかけて速度ベクトルにして、それを Rigidbody の速度ベクトルとしてセットする

        // 弾を発射する（単発）

        if (id == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Fire1();
                m_audio.PlayOneShot(m_audio.clip);
            }
        }
        if (id == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Fire1();
                m_audio.Play();
            }
        }

        //HP0でシーン遷移

        if (id==1&&hp==0)
        {
            Debug.Log("Player1:HPが０になってしまった");
            SceneManager.LoadScene("result_p2_win");
        }
        if (id == 2 && hp == 0)
        {
            Debug.Log("Player2:HPが０になってしまった");
            SceneManager.LoadScene("result_p1_win");
        }

    }

    /// <summary>
    /// 弾を発射する
    /// </summary>
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab にプレハブが設定されている時 かつ m_muzzle に弾の発射位置が設定されている時
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // インスペクターから設定した m_bulletPrefab をインスタンス化する
            go.transform.SetParent(this.transform);
            go.GetComponent<BulletController>().enemy = this.enemy;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (id == 1)
        {
            if (collision.gameObject.tag == "Bullet2")
            {
                hp = hp - 1;
                m_audio.Play();
                Debug.Log("Player1:hpが減った");
                helth.UpdateSlider(hp);
            }
        }
        if(id ==2)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                hp = hp - 1;
                m_audio.Play();
                Debug.Log("Player2:hpが減った");
                helth.UpdateSlider(hp);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            hp = hp - 1;
            //m_audio.Play();
            Debug.Log("爆弾ダメージ");
            helth.UpdateSlider(hp);
        }
    }
}
