using System;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour, IObservable<int>
{
    //�������w�ǂ���IObserver<int>�̃��X�g
    private List<IObserver<int>> _observers = new();

    /// <summary>
    /// IObservable�C���^�[�t�F�[�X�ɂ���Ď��������AObserver�ōw�ǂ��s�����߂̃��\�b�h
    /// </summary>
    /// <param name="observer">�w�ǂ��s��Observer</param>
    /// <returns></returns>
    public IDisposable Subscribe(IObserver<int> observer)
    {
        //observer���d�����Ȃ��悤�ɁA���łɎ������Ď����Ă��Ȃ����`�F�b�N
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }

        //�w�ǉ����p�̃N���X��IDisposable�Ƃ��ĕԂ�
        return new Unsubscriber(_observers, observer);
    }

    // �w�ǉ����p�̓����N���X
    class Unsubscriber : IDisposable //IDisposable�͎Q�Ƃ̔j����ړI�Ƃ����C���^�[�t�F�[�X
    {
        //���s��̃��X�g
        private List<IObserver<int>> _observers;
        //Dispose���ꂽ�Ƃ��ɍ폜���邽�߂̎Q��
        private IObserver<int> _observer;

        //�R���X�g���N�^
        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        /// <summary>
        /// ���s�惊�X�g����Ώۂ̔��s����폜���邱�Ƃōw�ǂ�Dispose(�j��)���郁�\�b�h
        /// </summary>
        public void Dispose()
        {
            _observers.Remove(_observer);
        }
    }

    // �Q�[���I�u�W�F�N�g��Destroy()���ɌĂяo��
    private void OnDisable()
    {
        var answer = UnityEngine.Random.Range(0, 10);

        //���ׂĂ̔��s��ɑ΂��ăX�R�A�𔭍s
        foreach (var observer in _observers)
        {
            observer.OnNext(answer);
        }
    }
}
