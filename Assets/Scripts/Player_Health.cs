using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
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
        // Disable player shooting
        GetComponent<Gun>().enabled= false;

        // Disable the player's collider
        GetComponent<Collider>().enabled = false;

        // Hide the player object
        gameObject.SetActive(false);

        Debug.Log("Player has died!");
    }
}
