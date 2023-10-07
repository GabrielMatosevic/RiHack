using UnityEngine;

namespace RH.Gameplay.Player
{

    public class RH_Player : MonoBehaviour
    {
        [SerializeField] private InventorySystem m_InventorySystem;

        [SerializeField] private float m_speed = 5f;

        // Start is called before the first frame update
        void Start()
        {
            m_InventorySystem = FindObjectOfType<InventorySystem>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.position =
                new Vector2(transform.position.x + m_speed * Time.deltaTime * Input.GetAxis("Horizontal"),
                            transform.position.y + m_speed * Time.deltaTime * Input.GetAxis("Vertical"));
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