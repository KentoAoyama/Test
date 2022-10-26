using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestEvent : MonoBehaviour
{
    static int _loadCount;
    bool _update;

    void Start()
    {
        Debug.Log("Startが呼ばれました");
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void Awake()
    {
        Debug.Log("Awakeが呼ばれました");
    }

    void OnEnable()
    {
        Debug.Log("OnEnableが呼ばれました");
    }

    void Update()
    {
        if (!_update)
        {
            _update = true;
            Debug.Log("Updateが呼ばれました");
        }
    }

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        Debug.Log("SceneLoadedが呼ばれました。");
        Debug.Log("次のシーンの名前は" + nextScene.name + "です");
        Debug.Log("LoadSceneModeは" + mode + "です");
    }
}
