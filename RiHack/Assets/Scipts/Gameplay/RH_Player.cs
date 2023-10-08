using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace RH.Gameplay.Player
{

    public class RH_Player : MonoBehaviour
    {
        [SerializeField] private InventorySystem m_InventorySystem;
        [SerializeField] private FixedJoystick   m_FixedJoystick;
        [SerializeField] private Animator        m_PlayerAnimator;

        private bool isAnimationPlaying = false;

        [SerializeField] private int m_damage;
        [SerializeField] private int m_health;
        [SerializeField] private int m_strength;
        [SerializeField] private float m_speed;

        private string[] boolNames = { "isUp", "isDown", "isLeft", "isRight" };


        

        // Start is called before the first frame update
        void Start()
        {
            m_InventorySystem = GetComponent<InventorySystem>();
            m_PlayerAnimator  = GetComponent<Animator>();

            m_damage   = PlayerPrefs.GetInt("Damage");
            m_health   = PlayerPrefs.GetInt("Health");
            m_speed    = PlayerPrefs.GetInt("Speed") / 10f;
            m_strength = PlayerPrefs.GetInt("Strength");
        }

        private void Update()
        {
            float horizontalInput = m_FixedJoystick.Horizontal;
            float verticalInput   = m_FixedJoystick.Vertical;

            // Determine the direction based on joystick input
            int directionIndex = -1; // Initialize to an invalid index

            if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
            {
                // Horizontal input is stronger, so set left or right
                directionIndex = (horizontalInput > 0) ? 3 : 2;
            }
            else
            {
                // Vertical input is stronger, so set up or down
                directionIndex = (verticalInput > 0) ? 0 : 1;
            }

            // Set animator bools based on the direction
            for (int i = 0; i < boolNames.Length; i++)
            {
                m_PlayerAnimator.SetBool(boolNames[i], i == directionIndex);
            }

            // Check for attack input
            if (!Input.GetMouseButtonDown(0))
            {
                // Move the player based on joystick input
                transform.position += new Vector3(horizontalInput * m_speed * Time.deltaTime,
                                                  verticalInput * m_speed * Time.deltaTime, 0);

                // Set the "isRunning" animator bool based on joystick input
                m_PlayerAnimator.SetBool("isRunning",
                                         Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f);
            }
            else
            {
                // Trigger the attack animation
                m_PlayerAnimator.SetTrigger("isAttacking");
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Item"))
            {
                Item pickupItem = other.GetComponent<Item>();
                m_InventorySystem.Add(pickupItem);
                Destroy(other.gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            
            if (other.gameObject.CompareTag("Enemy") && isAnimationPlaying)
            {
                print("GAY P");
                other.gameObject.GetComponent<RH_EnemyAI>().DealDamage(m_damage + m_strength);
            }
        }
        

        protected internal void DealDamage(int amount)
        {
            m_health -= amount;
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
    }
}

