using UnityEngine;

public enum SpawnDestinationTag
{
    A,
    B,
    C,
    D,
    E,
    F,
    G,
}

public class PlayerSpawnPoint : MonoBehaviour
{
    public SpawnDestinationTag destinationTag;
}
