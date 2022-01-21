using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private int m_HitsNumber = 1;
    [SerializeField] private float m_MovementSpeed = 1000.0f;
    private Rigidbody2D m_Rigidbody2D;
    private GameState m_PlayerOwner;
    private Transform m_Target;

    public GameState PlayerOwner
    {
        get { return m_PlayerOwner; }
        set { m_PlayerOwner = value; }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().PlayerType != m_PlayerOwner)
            {
                Debug.Log("Hit player!");
            }
        }   else if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Hit wall!");
            m_HitsNumber--;
            if (m_HitsNumber < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetTarget(Transform target)
    {
        Vector2 targetVelocity = (target.position - transform.position).normalized;
        Move(targetVelocity);
    }

    private void Move(Vector2 targetVelocity)
    {
        // Set rigidbody velocity. Multiply the target by deltaTime to make movement speed consistent across different framerates
        m_Rigidbody2D.velocity = (targetVelocity * m_MovementSpeed) * Time.deltaTime;
    }

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.isKinematic = false;
        m_Rigidbody2D.angularDrag = 0.0f;
        m_Rigidbody2D.gravityScale = 0.0f;
    }
}
