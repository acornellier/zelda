using UnityEngine.SceneManagement;
using UnityEditor;

[InitializeOnLoad]
public static class PlayModeStateChanged
{
    static PlayModeStateChanged()
    {
        EditorApplication.playModeStateChanged += LoadPersisentObjects;
    }

    static void LoadPersisentObjects(PlayModeStateChange state)
    {
        for (int index = 0; index < SceneManager.sceneCount; ++index)
            if (SceneManager.GetSceneAt(index).name == "PersistentObjects")
                return;

        SceneManager.LoadScene("PersistentObjects", LoadSceneMode.Additive);
    }
}
