using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
 
public class Spaceship : MonoBehaviour
{
    // 機体の移動スピードを格納する変数
    public float speed;
    // 弾を撃つ間隔を格納する変数
    public float shotDelay;
    // 弾のプレハブを格納する変数
    public GameObject bullet;
    // Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D rb;
    // 爆発用のPrefab
    public GameObject explosion;
    // 
    public AudioSource seExplosion;
 
    private int time = 0;
    // ゲーム起動時の処理
    void Awake()
    {
        // Rigidbody2D コンポーネントを取得して変数 rb に格納
        rb = GetComponent<Rigidbody2D>();
    }
 
    // 弾を作成する処理
    public void Shot(Transform origin, Vector3 direction, float bulletSpeed)
    {
        time++;
        // 弾を引数 origin と同じ位置/角度で作成
        GameObject shot = Instantiate(bullet, origin.position, origin.rotation);
        Debug.Log("Shot("+time+") : "+shot.transform.position);
        shot.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(shot, shotDelay * 20f);
    }
 
    // 機体の移動処理
    public void Move(Vector2 direction)
    {
        // Rigidbody2D コンポーネントの velocity に方向と移動速度を掛けた値を渡す
        rb.velocity = direction * speed;
    }

    // 爆発の処理
    public void Explosion()
    {
        GameObject exp = Instantiate(explosion);
        exp.transform.position = this.transform.position;
        seExplosion.Play();
        Destroy(exp, 1.5f);
    }
}