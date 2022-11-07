/// <summary>
/// FactoryのConcreteCreatorにあたるクラス
/// </summary>
public class EnemyCreator : CharactorCreator
{
    /// <summary>
    /// キャラクターをCreatorから生成するメソッド
    /// </summary>
    /// <param name="name">Charactorの名前</param>
    /// <param name="damage">Charactorが与えるダメージ</param>
    public override Character Create(string name, int damage)
    {
        name = "エネミー : " + name;
        Character character = new Enemy(name, damage);
        return character;
    }
}
