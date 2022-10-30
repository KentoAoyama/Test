using UnityEngine;

///=======Factoryパターンとは=======
///コンストラクタの代わりになるメソッドを作成、利用するパターン
///生成するオブジェクトごとにファクトリがあり、生成処理はサブクラスで行う。
///生成処理とオブジェクトの処理をクラスごとに記述することで、それを利用する側はコードの書き換えが必要なくなる
///
public class FactoryController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] 
    private string _playerName = "ああああ";

    [SerializeField]
    private int _playerDamage = 100;

    [Header("Enemy")]
    [SerializeField]
    private string _enemyName = "スライム";

    [SerializeField]
    private int _enemyDamage = 10;

    private void Start()
    {
        //Playerを生成
        CharactorCreator playerCreator = new PlayerCreator();
        Character player = playerCreator.Create(_playerName, _playerDamage);

        //Enemyを生成
        CharactorCreator enemyCreator = new EnemyCreator();
        Character enemy = enemyCreator.Create(_enemyName, _enemyDamage);

        //生成したインスタンスのメソッドを実行
        player.Attack();
        enemy.Attack();
    }
}
