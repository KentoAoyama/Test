using System;
using UnityEngine;
using UnityEditor;


public class SceneSelectorAttribute : PropertyAttribute
{                                                
    public SceneSelectorAttribute() { }
}


[CustomPropertyDrawer(typeof(SceneSelectorAttribute))]
public class SceneDrawer : PropertyDrawer
{
    int _sceneIndex = -1;
    GUIContent[] _sceneNames;
    readonly string[] _scenePathSplitters = { "/", ".unity" };


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        //ChangeCheckの開始 GUIグループ内のGUI要素でなんらかの変更がなされたときにアクションを起こすメソッド
        EditorGUI.BeginChangeCheck();

        Setup(property);

        //int sceneIndex = EditorBuildSettings.scenes.ToList().FindIndex(s => s.path == property.stringValue);

        _sceneIndex = EditorGUI.Popup(position, label, _sceneIndex, _sceneNames);

        //property.stringValue = EditorBuildSettings.scenes[_sceneIndex].path;       

        if (EditorGUI.EndChangeCheck())
        {
            property.stringValue = EditorBuildSettings.scenes[_sceneIndex].path;
        }

        EditorGUI.EndProperty();
    }


    void Setup(SerializedProperty property)
    {
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        _sceneNames = new GUIContent[scenes.Length];

        for (int i = 0; i < _sceneNames.Length; i++)
        {
            string path = scenes[i].path;

            if (string.IsNullOrEmpty(path))
            {
                _sceneNames[i] = new GUIContent("シーン選択が無効です。シーンが削除されました");
            }
            else
            {
                string[] splitPath = path.Split(_scenePathSplitters, StringSplitOptions.RemoveEmptyEntries);
                _sceneNames[i] = new GUIContent(splitPath[splitPath.Length - 1]);
            }
        }

        if (_sceneNames.Length == 0)
            _sceneNames = new[] { new GUIContent("[Build Settings にシーンが設定されていません]") };

        if (!string.IsNullOrEmpty(property.stringValue))
        {
            bool sceneNameFound = false;
            for (int i = 0; i < _sceneNames.Length; i++)
            {
                if (_sceneNames[i].text == property.stringValue)
                {
                    _sceneIndex = i;
                    sceneNameFound = true;
                    break;
                }
            }
            if (!sceneNameFound)
                _sceneIndex = 0;
        }
        else _sceneIndex = 0;

        property.stringValue = _sceneNames[_sceneIndex].text;
    }
}
