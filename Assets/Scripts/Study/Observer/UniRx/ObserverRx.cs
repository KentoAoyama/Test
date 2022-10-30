using UnityEngine;
using UniRx;
using System;

public class ObserverRx : MonoBehaviour
{
    [SerializeField]
    private GameObject _subjectPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�I�u�W�F�N�g�𐶐����A����Subject�R���|�[�l���g���擾
            var subjectObject = Instantiate(_subjectPrefab);
            var subject = subjectObject.GetComponent<SubjectRx>();

            //�V�����Ď��Ώۂ��w�ǂ��A�l���ω������Ƃ��̏�����o�^����
            //subject.SubjectUniRx.Subscribe(i => OnFinished(i));

            subject.SubjectUniRx
                .DelayFrame(300)
                .Select(i => i += 100)
                .Subscribe(i => OnFinished(i));

            //�Ď��Ώۂ�3�b��ɍ폜
            Destroy(subjectObject, 3.0f);
        }
    }

    private void OnFinished(int score)
    {
        Debug.Log($"Subject����X�R�A�����s����܂����BScore�́o{score}�p�ł�");
    }
}
