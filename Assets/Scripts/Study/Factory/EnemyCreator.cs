/// <summary>
/// Factory��ConcreteCreator�ɂ�����N���X
/// </summary>
public class EnemyCreator : CharactorCreator
{
    /// <summary>
    /// �L�����N�^�[��Creator���琶�����郁�\�b�h
    /// </summary>
    /// <param name="name">Charactor�̖��O</param>
    /// <param name="damage">Charactor���^����_���[�W</param>
    public override Character Create(string name, int damage)
    {
        name = "�G�l�~�[ : " + name;
        Character character = new Enemy(name, damage);
        return character;
    }
}
