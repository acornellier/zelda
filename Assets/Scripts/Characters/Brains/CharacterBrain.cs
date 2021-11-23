using Animancer;
using UnityEngine;

public abstract class CharacterBrain : MonoBehaviour
{
    public Character character;

#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        gameObject.GetComponentInParentOrChildren(ref character);
    }
#endif
}
