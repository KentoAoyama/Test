using System;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour, IObservable<int>
{
    //自分を購読したIObserver<int>のリスト
    private List<IObserver<int>> _observers = new();

    /// <summary>
    /// IObservableインターフェースによって実装される、Observerで購読を行うためのメソッド
    /// </summary>
    /// <param name="observer">購読を行うObserver</param>
    /// <returns></returns>
    public IDisposable Subscribe(IObserver<int> observer)
    {
        //observerが重複しないように、すでに自分を監視していないかチェック
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }

        //購読解除用のクラスをIDisposableとして返す
        return new Unsubscriber(_observers, observer);
    }

    // 購読解除用の内部クラス
    class Unsubscriber : IDisposable //IDisposableは参照の破棄を目的としたインターフェース
    {
        //発行先のリスト
        private List<IObserver<int>> _observers;
        //Disposeされたときに削除するための参照
        private IObserver<int> _observer;

        //コンストラクタ
        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        /// <summary>
        /// 発行先リストから対象の発行先を削除することで購読をDispose(破棄)するメソッド
        /// </summary>
        public void Dispose()
        {
            _observers.Remove(_observer);
        }
    }

    // ゲームオブジェクトをDestroy()時に呼び出す
    private void OnDisable()
    {
        var answer = UnityEngine.Random.Range(0, 10);

        //すべての発行先に対してスコアを発行
        foreach (var observer in _observers)
        {
            observer.OnNext(answer);
        }
    }
}
