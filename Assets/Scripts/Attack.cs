using UnityEngine;

public class Attack : MonoBehaviour
{
    public HitData hitData;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))
        {
            other.GetComponent<Breakable>().Break();
        }
        else if (other.isTrigger)
        {
            if (gameObject.CompareTag("Enemy") && other.gameObject.CompareTag("Enemy"))
                return;

            var otherCharacter = other.GetComponent<Character>();
            if (otherCharacter == null)
                return;

            var hit = new Hit() { source = transform, data = hitData };
            otherCharacter.ReceiveHit(hit);
        }
    }
}
