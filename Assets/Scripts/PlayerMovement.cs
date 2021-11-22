using UnityEngine;
using Animancer;

enum PlayerState
{
    walk, attack
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    [Header("Animations")]
    public AnimancerComponent animancer;
    public DirectionalAnimationSet idle;
    public DirectionalAnimationSet walk;
    public DirectionalAnimationSet attack;

    Rigidbody2D body;

    PlayerState state = PlayerState.walk;
    Vector2 facing = Vector2.down;
    Vector2 movement;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

        Play(idle);
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("attack") && state != PlayerState.attack)
        {
            state = PlayerState.attack;
        }
        else if (movement == default)
        {
            Play(idle);
        }
        else
        {
            facing = movement;
            Play(walk);
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + speed * Time.deltaTime * movement.normalized);
    }

    private void Play(DirectionalAnimationSet animations)
    {
        var clip = animations.GetClip(facing);
        animancer.Play(clip);
    }
}
