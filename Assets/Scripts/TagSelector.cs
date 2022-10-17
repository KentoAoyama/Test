using UnityEngine;
using UnityEditor;

/// <summary>
/// タグの選択を行えるようにするアトリビュート
/// </summary>
public class TagSelectorAttribute : PropertyAttribute　//カスタムプロパティー属性を派生させるベースクラス
{                                                      //その属性があるスクリプト変数がインスペクター上でどう表示されるか制御する
    public TagSelectorAttribute() { }
}


//PropertyDrawer または DecoratorDrawerクラスに、そのDrawerがどの実行時 Serializableクラスか PropertyAttributeであるかを通知する
[CustomPropertyDrawer(typeof(TagSelectorAttribute))]
////=====PropertyDrawerとは=====
//CustomPropertyDrawerの基底クラス。作成した Serializableクラス や PropertyAttribute変数の
//CustomDrawerを作成して使用することができる。
public class TagSelectorDrawer : PropertyDrawer
{
    /// <summary>
    ///このメソッドをオーバーライドすることで、プロパティ用の独自に制御される GUI(IMGUI)　を作成できる。
    /// </summary>
    /// <param name="position">プロパティ GUI に使用する形の指定</param>
    /// <param name="property">インスペクターに表示するための情報</param>
    /// <param name="label">インスペクターにどのように表示するか定めるクラス</param>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //=====PropertyWrapperとは=====
        //「プロパティの振る舞いを変更・追加し、簡単に再利用」するための仕組み

        //=====BeginPropertyとは=====
        //SerializedPropertyを GUI で管理しやすくするようにするための PropertyWrapper である GUIグループ を作成する
        EditorGUI.BeginProperty(position, label, property);

        //=====attributeとは=====
        //PropertyAttributeを表すプロパティ　->　public PropertyAttribute attribute { get; }
        var attrib = this.attribute as TagSelectorAttribute;

        if (attrib == null)
        {
            //=====EndPropertyとは=====
            //BeginProperty と開始した Property Wrapper を終了します。
            EditorGUI.EndProperty();
            return;
        }

        //=====TagFieldとは=====
        //position -> 表示位置
        //TagField -> フィールドのラベル
        //property -> フィールドが表示するタグ

        //EditorGUIの公式のリファレンス
        //https://docs.unity3d.com/ja/2018.4/ScriptReference/EditorGUI.html
        property.stringValue = EditorGUI.TagField(position, label, property.stringValue);

        EditorGUI.EndProperty();
    }
}