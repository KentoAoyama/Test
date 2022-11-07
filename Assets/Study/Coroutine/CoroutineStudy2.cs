using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CoroutineStudy2
{
    //Delayの処理を実行するコルーチン
    public IEnumerator DelayCoroutine()
    {
        Debug.Log("Delay開始");

        var sequence = DOTween.Sequence();

        yield return sequence
            .SetDelay(3)
            .OnComplete(() => Debug.Log("Delay終了"))
            .Play()
            .WaitForCompletion();
    }
}
