using UnityEngine;

/// <summary>
/// Factory��ConcreteProduct�ɂ�����N���X
/// </summary>
public class Player : Character
{
    public Player(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    /// <summary>
    /// Character���U��������ۂɌĂяo�����\�b�h
    /// </summary>
    public override void Attack()
    {
        Debug.Log($"{this.name}����{this.damage}�̃_���[�W!");
    }
}
