using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;

    private Rigidbody2D rb;
    private Vector2 movement;

    public float hookRange = 5f;
    public float pullSpeed = 5f;
    private GameObject hookedEnemy = null;

    public int maxMana = 100;
    public float maxhealth = 100;
    public int hookManaCost = 20;
    public float manaRegenerationRate = 5f;
    private int currentMana;
    private float currentHealth;

    private bool hasKey = false;

    private float DamageOnProjectile = 15f;
    public float healthBoostOnPickup = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMana = maxMana;
        currentHealth = maxhealth;
    }

    void Update()
    {
        // Input for movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Rotate the player to face the direction of movement
        if (movement != Vector2.zero)
        {
            transform.up = movement;
        }

        // Melee attack
        if (Input.GetKeyDown(KeyCode.Space)) // Assuming space bar is the attack key
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E)) // Assuming E is the hook key
        {
            TryHook();
        }

        if (hookedEnemy != null)
        {
            PullEnemy();
        }
        // Regenerate Mana
        if (currentMana < maxMana)
        {
            currentMana += (int)(manaRegenerationRate * Time.deltaTime);
            currentMana = Mathf.Min(currentMana, maxMana);
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            // Here, you can add code to damage the enemy
            // For example, enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    void TryHook()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, hookRange, enemyLayers);
        if (hit.collider != null)
        {
            hookedEnemy = hit.collider.gameObject;
            Debug.Log("Hooked " + hookedEnemy.name);

            // Consume Mana
            currentMana -= hookManaCost;
        }
    }

    void PullEnemy()
    {
        // Pull the enemy towards the player
        hookedEnemy.transform.position = Vector2.MoveTowards(hookedEnemy.transform.position, transform.position, pullSpeed * Time.deltaTime);

        // Release the enemy if it gets close enough to the player
        if (Vector2.Distance(transform.position, hookedEnemy.transform.position) < 1f)
        {
            hookedEnemy = null;
        }
    }

    public void TakeDamage()
    {
        currentHealth -= DamageOnProjectile;
    }
    public void IncreaseHealth()
    {
        currentHealth += healthBoostOnPickup;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Key"))
        {
            hasKey = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("HealthPickup"))
        {
            IncreaseHealth();
        }
    }
    void OnDrawGizmosSelected()
    {
        // Existing Gizmos for attack range...
        //    // Display the attack range in editor
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Display the hook range in editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * hookRange);
    }
}
