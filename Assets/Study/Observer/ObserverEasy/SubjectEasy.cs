using System;
using UnityEngine;

public class SubjectEasy : MonoBehaviour
{
    // �R�[���o�b�N�̓o�^�p��Action
    public event Action<int> OnFinished;

    // �I�u�W�F�N�g�폜�������ɂ��ꂽ���ɃR�[���o�b�N����
    private void OnDisable()
    {
        var answer = UnityEngine.Random.Range(0, 10);
        OnFinished?.Invoke(answer);
    }
}
