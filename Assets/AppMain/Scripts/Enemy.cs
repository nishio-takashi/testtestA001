using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Spaceship spaceship;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GetComponent<Spaceship>();
        spaceship.Move(transform.up * -0.25f);
        StartCoroutine("Shot");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // トリガーに入った時の処理
    // 衝突した相手の Collider2D コンポーネントを引数 c に格納
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得して layerName に格納
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "PlayerBullet") return;
        // 弾の削除
        Destroy(c.gameObject);
        // 爆発処理
        // スクリプト Spaceship の関数 Explosion() を実行
        spaceship.Explosion();
        // エネミーの削除
        Destroy(gameObject);
    }
 
     IEnumerator Shot()
    {
        while(true)
        {
            spaceship.Shot(transform, Vector3.down, 10f);
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }
}
