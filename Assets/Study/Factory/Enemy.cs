using UnityEngine;

/// <summary>
/// Factory��ConcreteProduct�ɂ�����N���X
/// </summary>
public class Enemy : Character
{
    public Enemy(string name, int damage)
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
