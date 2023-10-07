using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace RH.Gameplay.Player
{

    public class RH_Player : MonoBehaviour
    {
        [SerializeField] private InventorySystem m_InventorySystem;
        [SerializeField] private float           m_speed = 5f;
        [SerializeField] private Animator        m_PlayerAnimator;

        // Start is called before the first frame update
        void Start()
        {
            m_InventorySystem = GetComponent<InventorySystem>();
            m_PlayerAnimator  = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.position =
                new Vector2(transform.position.x + m_speed * Time.deltaTime * Input.GetAxis("Horizontal"),
                            transform.position.y + m_speed * Time.deltaTime * Input.GetAxis("Vertical"));
        }

        private void FixedUpdate()
        {
            //PLACEHOLDER
            // Define keycodes for the four directions
            KeyCode[] directionKeys = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };

            // Define corresponding bool variable names
            string[] boolNames = { "isUp", "isDown", "isLeft", "isRight" };

            // Loop through the direction keys
            for (int i = 0; i < directionKeys.Length; i++)
            {
                // Set the bool variable based on key press
                bool isPressed = Input.GetKey(directionKeys[i]);
                
                m_PlayerAnimator.SetBool(boolNames[i], isPressed);
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
    }
}