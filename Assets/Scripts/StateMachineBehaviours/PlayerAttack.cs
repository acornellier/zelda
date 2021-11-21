using UnityEngine;

public class PlayerAttack : SceneLinkedSMB<PlayerMovement>
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
