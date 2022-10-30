using UnityEngine;

///=======Factory�p�^�[���Ƃ�=======
///�R���X�g���N�^�̑���ɂȂ郁�\�b�h���쐬�A���p����p�^�[��
///��������I�u�W�F�N�g���ƂɃt�@�N�g��������A���������̓T�u�N���X�ōs���B
///���������ƃI�u�W�F�N�g�̏������N���X���ƂɋL�q���邱�ƂŁA����𗘗p���鑤�̓R�[�h�̏����������K�v�Ȃ��Ȃ�
///
public class FactoryController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] 
    private string _playerName = "��������";

    [SerializeField]
    private int _playerDamage = 100;

    [Header("Enemy")]
    [SerializeField]
    private string _enemyName = "�X���C��";

    [SerializeField]
    private int _enemyDamage = 10;

    private void Start()
    {
        //Player�𐶐�
        CharactorCreator playerCreator = new PlayerCreator();
        Character player = playerCreator.Create(_playerName, _playerDamage);

        //Enemy�𐶐�
        CharactorCreator enemyCreator = new EnemyCreator();
        Character enemy = enemyCreator.Create(_enemyName, _enemyDamage);

        //���������C���X�^���X�̃��\�b�h�����s
        player.Attack();
        enemy.Attack();
    }
}
