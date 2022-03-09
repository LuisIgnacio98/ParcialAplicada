using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float cooldown;
    [SerializeField] private float rangeOfAttack;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Parameters")]
    private int playerLives;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerLives = GameManager.vidaJugador;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInRange())
        {
            if (cooldownTimer >= cooldown)
            {
                cooldownTimer = 0;
                //print("I seee the enemy!!");
                anim.SetTrigger("Attack");
                playerLives -= damage;

            }
        }

    }

    private bool PlayerInRange()
    {
        RaycastHit2D collision =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * rangeOfAttack * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * rangeOfAttack, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.right, 0, playerLayer);

        return collision.collider != null;
    }
}