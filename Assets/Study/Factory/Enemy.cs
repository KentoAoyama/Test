using UnityEngine;

/// <summary>
/// FactoryのConcreteProductにあたるクラス
/// </summary>
public class Enemy : Character
{
    public Enemy(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    /// <summary>
    /// Characterが攻撃をする際に呼び出すメソッド
    /// </summary>
    public override void Attack()
    {
        Debug.Log($"{this.name}から{this.damage}のダメージ!");
    }
}
