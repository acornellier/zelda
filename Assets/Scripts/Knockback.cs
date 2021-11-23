using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var otherCharacter = other.GetComponent<Character>();
            if (otherCharacter == null)
                return;

            var hit = new Hit() { source = transform, knockTime = knockTime, thrust = thrust };
            otherCharacter.ReceiveHit(hit);
        }
    }
}
