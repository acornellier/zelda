using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(KnockCo(other.GetComponent<Rigidbody2D>()));
        }
    }

    IEnumerator KnockCo(Rigidbody2D enemy)
    {
        var forceDirection = enemy.transform.position - transform.position;
        var force = forceDirection.normalized * thrust;

        enemy.velocity = force;
        yield return new WaitForSeconds(knockTime);

        enemy.velocity = Vector2.zero;
    }
}
