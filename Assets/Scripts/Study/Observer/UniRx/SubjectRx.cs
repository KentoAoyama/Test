using UnityEngine;
using UniRx;
using System;

public class SubjectRx : MonoBehaviour
{
    private Subject<int> _subjectUniRx = new();

    //このインスタンスのSubjectを参照できるようにする
    public Subject<int> SubjectUniRx => _subjectUniRx;

    private void OnDisable()
    {
        var answer = UnityEngine.Random.Range(0, 10);
        //Observerへ通知を発行する
        _subjectUniRx.OnNext(answer);
    }
}
