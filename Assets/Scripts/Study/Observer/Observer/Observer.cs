using System;
using UnityEngine;

//=======Observer�p�^�[���Ƃ�=======
//Subject(�ώ@����鑤)�̏�Ԃ��ω������ۂ�Observer(�ώ@���鑤)�ɒʒm���s���f�U�C���p�^�[��
//�|�C���g�Ƃ��Ă�Subject���͉����������Ď����Ă��邩�A��̓I�ȑ���͒m�炸��
//�ʒm���o���邱�ƂƁA��ɊĎ�����̂ł͂Ȃ���Ԃ̕ω����Ď����Ă���Ƃ������ƁB
//

public class Observer : MonoBehaviour, IObserver<int>
{
    [SerializeField]
    private GameObject _subjectPrefab;

    /// <summary>
    /// �w�ǂ���Object������IDisposable�C���^�[�t�F�[�X�̃C���X�^���X��ۑ����邽�߂̕ϐ�
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
            //�I�u�W�F�N�g�𐶐����A����Subject�R���|�[�l���g���擾
            var subjectObject = Instantiate(_subjectPrefab);
            var subject = subjectObject.GetComponent<Subject>();

            //�V�����Ď��Ώۂ��w�ǂ��AIObservable�C���^�[�t�F�[�X�̃��\�b�h���R�[���o�b�N����
            _disposable = subject.Subscribe(this);

            //�Ď��Ώۂ�3�b��ɍ폜
            Destroy(subjectObject, 3.0f);
        }
    }

    //�s�v�ȊĎ����s��Ȃ��悤�ɂ��邽�߁A�폜���ꂽ�ۂɍw�ǂ���������
    private void OnDestroy()
    {
        _disposable.Dispose();
    }


    //======�������牺��IObserver���p�����邱�ƂŎ�������郁�\�b�h======

    /// <summary>
    /// �f�[�^�̔��s�������������Ƃ�ʒm���郁�\�b�h
    /// </summary>
    public void OnCompleted()
    {
        Debug.Log("Completed");
    }

    /// <summary>
    /// �f�[�^�̔��s��ŃG���[�������������Ƃ�ʒm���郁�\�b�h
    /// </summary>
    /// <param name="error"></param>
    public void OnError(Exception error)
    {
        Debug.Log($"Error:{error.Message}");
    }

    /// <summary>
    /// �f�[�^��ʒm���郁�\�b�h
    /// </summary>
    /// <param name="value"></param>
    public void OnNext(int value)
    {
        Debug.Log($"Subject����X�R�A�����s����܂����BScore�́o{value}�p�ł�");
    }
}
