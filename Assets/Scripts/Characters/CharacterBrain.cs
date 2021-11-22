using Animancer;
using UnityEngine;

public abstract class CharacterBrain : MonoBehaviour
{
    public Character character;
    public Vector2 facingDirection = Vector2.down;
    public Vector2 movementDirection;

#if UNITY_EDITOR
    protected void Reset()
    {
        character = gameObject.GetComponentInParentOrChildren<Character>();
    }
#endif
}
