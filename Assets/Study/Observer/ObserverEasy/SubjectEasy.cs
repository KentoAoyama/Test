using System;
using UnityEngine;

public class SubjectEasy : MonoBehaviour
{
    // コールバックの登録用のAction
    public event Action<int> OnFinished;

    // オブジェクト削除か無効にされた時にコールバックする
    private void OnDisable()
    {
        var answer = UnityEngine.Random.Range(0, 10);
        OnFinished?.Invoke(answer);
    }
}
