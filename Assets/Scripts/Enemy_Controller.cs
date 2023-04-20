using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public int startingHealth = 10;
    public int damageAmount = 1;
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;

    private Transform player;
    private int currentHealth;
    private float nextAttackTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = startingHealth;
    }

    private void Update()
    {
        // Move towards the player
        transform.LookAt(player.position);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        // Check if the enemy is close enough to attack
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Deal damage to the player
        Player_Health playerComponent = player.GetComponent<Player_Health>();
        playerComponent.TakeDamage(damageAmount);

        // Set the next attack time based on the attack cooldown
        nextAttackTime = Time.time + attackCooldown;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Disable the enemy object
        gameObject.SetActive(false);

        /*// Add score to the player
        Player_Health playerComponent = player.GetComponent<Player>();
        playerComponent.AddScore(10);*/
    }
}
