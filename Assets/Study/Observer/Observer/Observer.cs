using System;
using UnityEngine;

//=======Observerパターンとは=======
//Subject(観察される側)の状態が変化した際にObserver(観察する側)に通知を行うデザインパターン
//ポイントとしてはSubject側は何が自分を監視しているか、具体的な相手は知らずに
//通知を出せることと、常に監視するのではなく状態の変化を監視しているということ。
//

public class Observer : MonoBehaviour, IObserver<int>
{
    [SerializeField]
    private GameObject _subjectPrefab;

    /// <summary>
    /// 購読したObjectがもつIDisposableインターフェースのインスタンスを保存するための変数
    /// </summary>
    private IDisposable _disposable;

    private void Start()
    {
        _disposable = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //オブジェクトを生成し、そのSubjectコンポーネントを取得
            var subjectObject = Instantiate(_subjectPrefab);
            var subject = subjectObject.GetComponent<Subject>();

            //新しい監視対象を購読し、IObservableインターフェースのメソッドをコールバックする
            _disposable = subject.Subscribe(this);

            //監視対象を3秒後に削除
            Destroy(subjectObject, 3.0f);
        }
    }

    //不要な監視を行わないようにするため、削除された際に購読を解除する
    private void OnDestroy()
    {
        _disposable.Dispose();
    }


    //======ここから下がIObserverを継承することで実装されるメソッド======

    /// <summary>
    /// データの発行が完了したことを通知するメソッド
    /// </summary>
    public void OnCompleted()
    {
        Debug.Log("Completed");
    }

    /// <summary>
    /// データの発行先でエラーが発生したことを通知するメソッド
    /// </summary>
    /// <param name="error"></param>
    public void OnError(Exception error)
    {
        Debug.Log($"Error:{error.Message}");
    }

    /// <summary>
    /// データを通知するメソッド
    /// </summary>
    /// <param name="value"></param>
    public void OnNext(int value)
    {
        Debug.Log($"Subjectからスコアが発行されました。Scoreは｛{value}｝です");
    }
}
