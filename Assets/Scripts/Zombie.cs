using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public float speed = 1.0f;
    public float health = 100.0f;
    public Slider healthBar; // Reference to the health bar UI element

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (healthBar != null)
        {
            healthBar.value = health;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add death logic here (e.g., play animation, drop loot, etc.)
        Destroy(gameObject);
    }

    void MoveToPlayer() {  
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            transform.LookAt(player.transform);
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
