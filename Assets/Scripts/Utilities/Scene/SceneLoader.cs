using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    protected static SceneLoader instance;
    public static SceneLoader Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = FindObjectOfType<SceneLoader>();

            if (instance != null)
                return instance;

            var gameObject = new GameObject("SceneLoader");
            instance = gameObject.AddComponent<SceneLoader>();

            return instance;
        }
    }

    void Awake()
    {
        SetPlayerPosition(SpawnDestinationTag.A);
    }

    public static void LoadScene(string sceneToLoad, SpawnDestinationTag destinationTag)
    {
        Instance.StartCoroutine(Instance.LoadSceneAdditive(sceneToLoad, destinationTag));
    }

    public static void SetPlayerPosition(SpawnDestinationTag destinationTag)
    {
        foreach (var spawnPoint in FindObjectsOfType<PlayerSpawnPoint>())
        {
            if (spawnPoint.destinationTag == destinationTag)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position =
                    spawnPoint.transform.position;
                return;
            }
        }
    }

    IEnumerator LoadSceneAdditive(string sceneToLoad, SpawnDestinationTag destinationTag)
    {
        var activeScene = SceneManager.GetActiveScene();
        var loadOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        loadOperation.allowSceneActivation = false;

        while (loadOperation.progress < 0.9f)
            yield return null;

        var unloadOperation = SceneManager.UnloadSceneAsync(activeScene);
        loadOperation.allowSceneActivation = true;

        while (!loadOperation.isDone || !unloadOperation.isDone)
            yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));
        SetPlayerPosition(destinationTag);
    }
}
