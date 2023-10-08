using System;
using System.Collections;
using RH.Gameplay.Player;
using Unity.VisualScripting;
using UnityEngine;

public class RH_EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform waypoint1; // The first waypoint object
    [SerializeField] private Transform waypoint2; // The second waypoint object
    [SerializeField] private int       m_dealDamage = 25;
    [SerializeField] private int       m_health     = 150;
    [SerializeField] private float     moveSpeed    = 2.0f; // Speed at which the enemy moves

    private Transform      currentWaypoint;  // The current waypoint the enemy is moving towards
    private SpriteRenderer m_spriteRenderer; // Reference to the SpriteRenderer component

    [SerializeField] private GameObject m_playerReference;

    [SerializeField] private bool     m_isFollowingPlayer = false;
    [SerializeField] private Animator m_animator;

    private bool isAnimationPlaying = false;


    private void Start()
    {
        // Initialize the currentWaypoint to the first waypoint
        currentWaypoint  = waypoint2;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator       = GetComponent<Animator>();
        StartCoroutine(MoveToWaypoint());
    }


    private IEnumerator MoveToWaypoint()
    {
        while (true)
        {
            if (!isAnimationPlaying)
            {
                m_spriteRenderer.flipX = currentWaypoint == waypoint1 ? true : false;
                // Calculate the distance to the current waypoint
                float distance = Vector2.Distance(transform.position, currentWaypoint.position);

                // If the enemy is close enough to the waypoint, switch to the other waypoint
                if (distance < 0.1f)
                {
                    currentWaypoint = (currentWaypoint == waypoint2) ? waypoint1 : waypoint2;
                }

                // Move the enemy towards the current waypoint

                if (!m_isFollowingPlayer)
                {
                    transform.position =
                        Vector3.MoveTowards(transform.position, currentWaypoint.position,
                                            moveSpeed * Time.deltaTime);
                }
                else
                {
                    // Calculate a vector pointing from the enemy to the player
                    Vector3 toPlayer = m_playerReference.transform.position - transform.position;

                    // Calculate a vector representing the enemy's forward direction
                    Vector3 enemyForward = transform.right;

                    // Calculate the dot product of the two vectors
                    float dotProduct = Vector3.Dot(toPlayer, enemyForward);

                    // If the dot product is positive, the player is in front of the enemy
                    // If the dot product is negative, the player is behind the enemy
                    if (dotProduct < 0)
                    {
                        Debug.Log("Player is in front of the enemy.");
                        m_spriteRenderer.flipX = true;
                    }
                    else
                    {
                        Debug.Log("Player is behind the enemy.");
                        m_spriteRenderer.flipX = false;
                    }

                    distance = Vector2.Distance(transform.position, m_playerReference.transform.position);
                    if (distance < 1.5f)
                    {
                        m_animator.SetTrigger("isAttacking");
                    }

                    transform.position =
                        Vector3.MoveTowards(transform.position, m_playerReference.transform.position,
                                            (moveSpeed + 2) * Time.deltaTime);
                }
            }
            
            if (m_health <= 0) Destroy(gameObject);

            yield return null; // Yield to the next frame
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            m_playerReference   = other.gameObject;
            m_isFollowingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone.");
            m_isFollowingPlayer = false;
        }
    }

    void StartAnimation()
    {
        isAnimationPlaying = true;
        // Play the animation here
    }

    void AnimationComplete()
    {
        isAnimationPlaying = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && isAnimationPlaying)
        {
            print("GAY E");
            m_playerReference.GetComponent<RH_Player>().DealDamage(m_dealDamage);
        }
    }

    protected internal void DealDamage(int amount)
    {
        m_health -= amount;
    }
}