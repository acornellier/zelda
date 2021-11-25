using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public SpawnDestinationTag destinationTag;

    bool loaded;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !loaded)
        {
            loaded = true;
            SceneLoader.LoadScene(sceneToLoad, destinationTag);
        }
    }
}
