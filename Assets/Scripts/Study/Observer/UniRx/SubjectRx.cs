using UnityEngine;
using UniRx;
using System;

public class SubjectRx : MonoBehaviour
{
    private Subject<int> _subjectUniRx = new();

    //���̃C���X�^���X��Subject���Q�Ƃł���悤�ɂ���
    public Subject<int> SubjectUniRx => _subjectUniRx;

    private void OnDisable()
    {
        var answer = UnityEngine.Random.Range(0, 10);
        //Observer�֒ʒm�𔭍s����
        _subjectUniRx.OnNext(answer);
    }
}
