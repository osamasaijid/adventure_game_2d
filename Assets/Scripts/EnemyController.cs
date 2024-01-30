using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float stopDistance = 3f; // Distance at which enemy stops approaching player
    public GameObject projectile;
    public float shootingInterval = 2f;

    private Transform player;
    private float nextShootTime;
    private float health = 100;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoveTowardsPlayer();

        if (Time.time >= nextShootTime)
        {
            ShootAtPlayer();
            nextShootTime = Time.time + shootingInterval;
        }
    }

    void MoveTowardsPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void ShootAtPlayer()
    {
        // Instantiate projectile and shoot it towards the player
        // This assumes you have a script attached to the projectile to handle its movement
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;
        bullet.GetComponent<Projectile>().SetDirection(direction);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
            Destroy(gameObject);
    }
}
