using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace RH.Gameplay.Player
{

    public class RH_Player : MonoBehaviour
    {
        [SerializeField] private InventorySystem m_InventorySystem;
        [SerializeField] private Animator        m_PlayerAnimator;

        private bool isAnimationPlaying = false;

        [SerializeField] private int m_damage;
        [SerializeField] private int m_health;
        [SerializeField] private int m_strength;
        [SerializeField] private float m_speed;
        

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
            //PLACEHOLDER FOR PC
            // Define keycodes for the four directions
            KeyCode[] directionKeys = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };

            // Define corresponding bool variable names
            string[] boolNames = { "isUp", "isDown", "isLeft", "isRight" };

            bool isMoving = false;

            if (!Input.GetMouseButtonDown(0))
            {
                transform.position =
                    new Vector2(transform.position.x + m_speed * Time.deltaTime * Input.GetAxis("Horizontal"),
                                transform.position.y + m_speed * Time.deltaTime * Input.GetAxis("Vertical"));
            
                // Loop through the direction keys
                for (int i = 0; i < directionKeys.Length; i++)
                {
                    // Set the bool variable based on key press
                    bool isPressed = Input.GetKey(directionKeys[i]);

                    m_PlayerAnimator.SetBool(boolNames[i], isPressed);

                    if (isPressed)
                    {
                        isMoving = true;
                    }
                }
            }
            else
            {
                m_PlayerAnimator.SetTrigger("isAttacking");
            }
            
            m_PlayerAnimator.SetBool("isRunning", isMoving);

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

