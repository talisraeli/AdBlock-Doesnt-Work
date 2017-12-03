using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField]
    private GameObject loadingScene;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(loadingScene);

        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        var scene = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while(!scene.isDone)
            loadingScene.SetActive(true);
        loadingScene.SetActive(false);
    }
}
