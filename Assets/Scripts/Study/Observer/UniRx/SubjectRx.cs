using UnityEngine;
using UniRx;
using System;

public class SubjectRx : MonoBehaviour
{
    private Subject<int> _subjectUniRx = new();

    //このインスタンスのSubjectを参照できるようにする
    public IObservable<int> SubjectUniRx => _subjectUniRx;

    private void OnDisable()
    {
        var answer = UnityEngine.Random.Range(0, 10);

        //Observerへ通知を発行する
        _subjectUniRx.OnNext(answer);

        //適宜インスタンスを破棄する
        _subjectUniRx.Dispose();
    }
}
