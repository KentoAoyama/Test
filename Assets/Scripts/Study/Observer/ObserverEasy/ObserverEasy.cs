using UnityEngine;

public class ObserverEasy : MonoBehaviour
{
    [SerializeField]
    private GameObject _subjectPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //オブジェクトを生成し、そのSubjectコンポーネントを取得
            var go = Instantiate(_subjectPrefab);
            var subject = go.GetComponent<SubjectEasy>();

            // 監視対象が消えたらコールバック(監視対象を購読)
            subject.OnFinished += OnFinished;

            // 監視対象を3秒後に削除
            Destroy(go, 3);
        }
    }

    // 監視対象からのコールバック
    private void OnFinished(int value)
    {
        Debug.Log($"Subjectからスコアが発行されました。Scoreは｛{value}｝です");
    }
}
