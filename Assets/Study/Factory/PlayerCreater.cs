/// <summary>
/// Factory��ConcreteCreator�ɂ�����N���X
/// </summary>
public class PlayerCreator : CharactorCreator
{
    /// <summary>
    /// �L�����N�^�[��Creator���琶�����郁�\�b�h
    /// </summary>
    /// <param name="name">Charactor�̖��O</param>
    /// <param name="damage">Charactor���^����_���[�W</param>
    /// <returns></returns>
    public override Character Create(string name, int damage)
    {
        name = "�v���C���[ : " + name;
        Character character = new Player(name, damage);
        return character;
    }
}
