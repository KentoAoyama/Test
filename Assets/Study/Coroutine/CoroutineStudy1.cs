using System.Collections;
using UnityEngine;

public class CoroutineStudy1 : MonoBehaviour
{
    CoroutineStudy2 _coroutineStudy2 = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartDelay());
        }
    }

    IEnumerator StartDelay()
    {
        Debug.Log("Start実行開始");

        yield return _coroutineStudy2.DelayCoroutine();

        Debug.Log("Start実行終了");
    }
}
