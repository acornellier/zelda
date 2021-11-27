using Animancer;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public AnimationClip crossfadeStart;
    public AnimationClip crossfadeEnd;
    public AnimancerComponent animancer;

    void Awake()
    {
        SetPlayerPosition(SpawnDestinationTag.A);
    }

    public static void LoadScene(string sceneToLoad, SpawnDestinationTag destinationTag)
    {
        Instance.StartCoroutine(Instance.LoadSceneCo(sceneToLoad, destinationTag));
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

    IEnumerator LoadSceneCo(string sceneToLoad, SpawnDestinationTag destinationTag)
    {
        var activeScene = SceneManager.GetActiveScene();
        var loadOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        loadOperation.allowSceneActivation = false;

        animancer.Play(crossfadeStart);

        while (loadOperation.progress < 0.9f)
            yield return null;

        var unloadOperation = SceneManager.UnloadSceneAsync(activeScene);
        loadOperation.allowSceneActivation = true;

        while (!loadOperation.isDone || !unloadOperation.isDone)
            yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));
        SetPlayerPosition(destinationTag);
        animancer.Play(crossfadeEnd);
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        gameObject.GetComponentInParentOrChildren(ref animancer);
    }
#endif
}
