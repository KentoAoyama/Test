/// <summary>
/// FactoryのConcreteCreatorにあたるクラス
/// </summary>
public class PlayerCreator : CharactorCreator
{
    /// <summary>
    /// キャラクターをCreatorから生成するメソッド
    /// </summary>
    /// <param name="name">Charactorの名前</param>
    /// <param name="damage">Charactorが与えるダメージ</param>
    /// <returns></returns>
    public override Character Create(string name, int damage)
    {
        name = "プレイヤー : " + name;
        Character character = new Player(name, damage);
        return character;
    }
}
