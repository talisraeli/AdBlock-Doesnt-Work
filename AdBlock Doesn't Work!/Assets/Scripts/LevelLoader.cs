using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

    private GameObject loadingScene;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        loadingScene = GameObject.Find("LoadingScene");

        StartCoroutine(LoadLevel());
    }

    public IEnumerator LoadLevel(int sceneIndex = -1, float timeScale = 0f)
    {
        Time.timeScale = 1f;
        if(sceneIndex == -1)
            sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        var scene = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScene.SetActive(true);

        scene.completed += x =>
        {
            loadingScene.SetActive(false);
            Time.timeScale = timeScale;
        };

        while(!scene.isDone)
        {
            Debug.Log(scene.progress);
            yield return null;
        }

    }
}
