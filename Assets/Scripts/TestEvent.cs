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
        Debug.Log("Start���Ă΂�܂���");
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void Awake()
    {
        Debug.Log("Awake���Ă΂�܂���");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable���Ă΂�܂���");
    }

    void Update()
    {
        if (!_update)
        {
            _update = true;
            Debug.Log("Update���Ă΂�܂���");
        }
    }

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        Debug.Log("SceneLoaded���Ă΂�܂����B");
        Debug.Log("���̃V�[���̖��O��" + nextScene.name + "�ł�");
        Debug.Log("LoadSceneMode��" + mode + "�ł�");
    }
}
