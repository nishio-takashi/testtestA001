using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Manager : MonoBehaviour
{
    // 自機を格納する変数
    public GameObject playerPrefab;
    // 敵機を格納する変数
    public GameObject emitterPrefab;
    // テキストオブジェクトを格納する変数
    public GameObject textTitle;
    // ゲームオーバーテキストオブジェクトを格納する変数
    public GameObject textGameOver;
    // 敵機の実態
    private GameObject emitter;

    private GameObject player;

    // ゲームのスタート時の処理
    void Start()
    {
        textGameOver.SetActive(false);
    }
 
    // ゲーム実行中の繰り返し処理
    void Update()
    {
        if(player == null && IsPlaying())
        {
            GameOver();
        }
        // ゲーム中ではなく、さらにXキーが押されたらtrueを返す。
        if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            // ゲーム開始処理を実行
            GameStart();
        }
    }
 
    // ゲーム開始処理
    void GameStart()
    {
        // タイトルオブジェクトを非表示にする
        textTitle.SetActive(false);
        // 自機を生成する
        player = Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        // 敵機を生成する
        emitter = Instantiate(emitterPrefab, emitterPrefab.transform.position, emitterPrefab.transform.rotation);
    }
 
    // ゲームオーバー時の処理
    public void GameOver()
    {
        // テキストオブジェクト表示のコルーチンを実行
        StartCoroutine("ShowGameOver");
    }
 
    // ゲームプレイ中か判定する処理
    public bool IsPlaying()
    {
        // タイトルオブジェクトが非表示であれば true を返す
        return textTitle.activeSelf == false && textGameOver.activeSelf == false;
    }
 
    // ゲームオーバー時にテキストオブジェクトを表示する処理（コルーチン）
    private IEnumerator ShowGameOver()
    {
        // ゲームオーバーを表示する
        textGameOver.SetActive(true);
        // 敵機のオブジェクトを削除する
        Destroy(emitter);
        //3秒後に処理を中断
        yield return new WaitForSeconds(3f);
        // ゲームオーバーテキストオブジェクトを非表示にする
        textGameOver.SetActive(false);
        // タイトルテキストオブジェクトを表示する
        textTitle.SetActive(true);
    }
}