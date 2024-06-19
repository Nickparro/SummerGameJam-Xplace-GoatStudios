using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private UICanvasGroupHandler _loadingScreen;
    public void ChangeScene(int buildIndex)
    {
        StartCoroutine(LoadScene(buildIndex));
        
    }

    private IEnumerator LoadScene(int buildIndex)
    {
        _loadingScreen.SetCanvasGroup(true);
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(buildIndex);
        loadingOperation.allowSceneActivation = false;
        float simProgress = 0.0f;
        while (simProgress < 1.0f)
        {
            simProgress += Random.Range(0.1f, 0.3f);
            yield return new WaitForSeconds(0.1f);
        }

        loadingOperation.allowSceneActivation = true;
        _loadingScreen.SetCanvasGroup(true);
    }
}
