using UnityEngine;

public class ObserverEasy : MonoBehaviour
{
    [SerializeField]
    private GameObject _subjectPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�I�u�W�F�N�g�𐶐����A����Subject�R���|�[�l���g���擾
            var go = Instantiate(_subjectPrefab);
            var subject = go.GetComponent<SubjectEasy>();

            // �Ď��Ώۂ���������R�[���o�b�N(�Ď��Ώۂ��w��)
            subject.OnFinished += OnFinished;

            // �Ď��Ώۂ�3�b��ɍ폜
            Destroy(go, 3);
        }
    }

    // �Ď��Ώۂ���̃R�[���o�b�N
    private void OnFinished(int value)
    {
        Debug.Log($"Subject����X�R�A�����s����܂����BScore�́o{value}�p�ł�");
    }
}
