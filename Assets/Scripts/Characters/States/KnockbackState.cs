public sealed class KnockbackState : CharacterState
{
    Hit hit;

    void Awake()
    {
        character.OnHitReceived += (hit) =>
        {
            this.hit = hit;
            ForceSetState();
        };
    }

    protected override void Update()
    {
        base.Update();
    }

    void FixedUpdate()
    {
        var forceDirection = character.transform.position - hit.source.transform.position;
        var force = forceDirection.normalized * hit.thrust;
        character.body.velocity = force;
    }

    public override bool CanExitState => timeSinceEnabled > hit.knockTime;
}
