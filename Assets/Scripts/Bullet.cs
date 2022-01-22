using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int m_NumberOfBounces = 1;
    [SerializeField] private float m_BulletForce = 10.0f;
    [Tag] public string m_PlayerTag;
    [Tag] public string m_MapTag;
    private Rigidbody2D m_Rigidbody2D;
    private GameState m_PlayerType;
    private Transform m_Target;

    public GameState PlayerType
    {
        get { return m_PlayerType; }
        set { m_PlayerType = value; }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.tag == m_PlayerTag)
        {            
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController.PlayerType != m_PlayerType)
            {
                Debug.Log("Hit enemy player!");
                playerController.Damage();
                Destroy(gameObject);
            }
        }   
        else if (collision.gameObject.tag == m_MapTag)
        {
            m_NumberOfBounces--;
            if (m_NumberOfBounces < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetTarget(Transform target)
    {
        Vector2 targetDirection = (target.position - transform.position).normalized;
        AddForce(targetDirection);
    }

    private void AddForce(Vector2 targetDirection)
    {
        m_Rigidbody2D.AddForce(targetDirection * m_BulletForce, ForceMode2D.Impulse);
    }

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.isKinematic = false;
        m_Rigidbody2D.angularDrag = 0.0f;
        m_Rigidbody2D.gravityScale = 0.0f;
    }
}
