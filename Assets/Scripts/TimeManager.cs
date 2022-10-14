using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField, Tooltip("")] Text _timerText;
    [SerializeField, Tooltip("")] Text _countDownText;
    [SerializeField, Tooltip("")] string _finishText = "おわり";
    [SerializeField, Tooltip("")] float _endTime;
    [SerializeField, Tooltip("")] float _finishDelayTime = 2f;
    [SerializeField, Tooltip("")] string _resultSceneName;

    float _countDown = 3.5f;
    float _timer;

    /// <summary>ゲーム中であることを表す変数</summary>
    public static bool _isGame;


    void Awake()
    {
        _timer = _endTime;
    }


    void FixedUpdate()
    {
        TimeChange();
    }


    /// <summary>カウントダウンとタイムの管理を行うメソッド</summary>
    void TimeChange()
    {
        if (!_isGame)
        {
            //カウントダウン
            _countDown -= Time.deltaTime;

            _countDownText.text = Mathf.Floor(_countDown).ToString();
        }
        else
        {
            //タイマー
            _timer -= Time.deltaTime;

            _timerText.text = _timer.ToString("F2");
        }

        if (_countDown < 1)
        {
            //カウントダウンが終わったらゲームを開始
            _countDownText.text = "";
            _isGame = true;
        }

        if (_timer <= 0)
        {
            //タイマーが０になったらゲーム終了
            _timerText.text = "0000";
            StartCoroutine(GameOver());
        }
    }


    IEnumerator GameOver()
    {
        _isGame = false;
        _countDownText.text = _finishText;
        yield return new WaitForSeconds(_finishDelayTime);
        SceneManager.LoadScene(_resultSceneName);
    }
}
