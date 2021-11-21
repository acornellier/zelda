using UnityEngine;

public class Breakable : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Break()
    {
        animator.SetTrigger("break");
    }
}
