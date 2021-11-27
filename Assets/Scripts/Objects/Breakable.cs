using Animancer;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public AnimationClip clip;
    AnimancerComponent animancer;

    public void Break()
    {
        var state = animancer.Play(clip);
        state.Events.OnEnd = () => Destroy(gameObject);
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        gameObject.GetComponentInParentOrChildren(ref animancer);
    }
#endif
}
