using UnityEngine;

public class LogWakeup : SceneLinkedSMB<LogMovement>
{
    public override void OnSLStateExit(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex
    )
    {
        monoBehaviour.SetStateWalking();
    }
}
