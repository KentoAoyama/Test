using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CoroutineStudy2
{
    //Delay�̏��������s����R���[�`��
    public IEnumerator DelayCoroutine()
    {
        Debug.Log("Delay�J�n");

        var sequence = DOTween.Sequence();

        yield return sequence
            .SetDelay(3)
            .OnComplete(() => Debug.Log("Delay�I��"))
            .Play()
            .WaitForCompletion();
    }
}
