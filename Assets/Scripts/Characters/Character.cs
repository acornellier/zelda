using Animancer;
using Animancer.FSM;
using System;
using UnityEngine;

#pragma warning disable IDE0052

public sealed class Character : MonoBehaviour
{
    [SerializeField]
    int maxHealth;
    public int MaxHealth => maxHealth;

    [SerializeField]
    float health;
    public float Health
    {
        get => health;
        set
        {
            var oldHealth = health;
            health = Mathf.Clamp(value, 0, maxHealth);
            if (OnHealthChanged != null)
                OnHealthChanged(oldHealth, health);
            else if (health <= 0)
                Destroy(gameObject);
        }
    }

    public Inventory inventory;

    public AnimancerComponent animancer;
    public CharacterState idle;
    public CharacterBrain brain;
    public Rigidbody2D body;

    Vector2 facingDirection = Vector2.down;
    public Vector2 FacingDirection => facingDirection;

    Vector2 movementDirection;
    public Vector2 MovementDirection
    {
        get => movementDirection;
        set
        {
            movementDirection = value.normalized;
            if (movementDirection != default)
                facingDirection = movementDirection;
        }
    }

    public event Action<float, float> OnHealthChanged;
    public event Action<Hit> OnHitReceived;

    public StateMachine<CharacterState>.WithDefault stateMachine;

    [SerializeField]
    string currentState = null;

    void Awake()
    {
        health = maxHealth;
    }

    void OnEnable()
    {
        stateMachine = new StateMachine<CharacterState>.WithDefault { DefaultState = idle };
        stateMachine.SetAllowNullStates(true);
    }

    void Update()
    {
        currentState = stateMachine.CurrentState.Name;
    }

    public void TrySetState(CharacterState state) => stateMachine.TrySetState(state);

    public void ReceiveHit(Hit hit)
    {
        Health -= hit.data.damage;
        OnHitReceived?.Invoke(hit);
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        gameObject.GetComponentInParentOrChildren(ref animancer);
        gameObject.GetComponentInParentOrChildren(ref body);
        gameObject.GetComponentInParentOrChildren(ref brain);
        idle = gameObject.GetComponentInParentOrChildren<IdleState>();
    }
#endif
}
