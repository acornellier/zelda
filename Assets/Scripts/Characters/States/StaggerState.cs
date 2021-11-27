using UnityEngine;

public sealed class StaggerState : CharacterState
{
    public AnimationClip dieAnimation;

    Hit hit;

    void Awake()
    {
        character.OnHealthChanged += (oldHealth, newHealth) =>
        {
            if (newHealth < oldHealth)
                ForceState();
        };

        character.OnHitReceived += (hit) =>
        {
            if (hit.data.damage > 0)
            {
                this.hit = hit;
                ForceState();
            }
        };
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if (character.Health <= 0)
        {
            if (dieAnimation)
            {
                var state = character.animancer.Play(dieAnimation);
                state.Events.OnEnd = () => Destroy(character.gameObject);
            }
            else
            {
                character.stateMachine.ForceSetState(null);
                Destroy(character.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        var forceDirection = character.transform.position - hit.source.transform.position;
        var force = forceDirection.normalized * hit.data.thrust;
        character.body.velocity = force;
    }

    public override bool CanExitState => timeSinceEnabled > hit.data.staggerTime;
}
