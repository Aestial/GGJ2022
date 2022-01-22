using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject m_BulletPrefab;
    [SerializeField] private Transform m_BulletSpawn;
    [SerializeField] private Transform m_Target;
    [SerializeField] private Transform m_TargetSpawn;
    [SerializeField] private float m_ShootInterval = 0.5f;    
    private bool m_IsEnabled;
    private GameState m_PlayerType;
    private PlayerMovement m_TargetMovement;
    private SpriteRenderer m_TargetRenderer;

    public void Enable()
    {
        m_IsEnabled = true;
        m_TargetMovement.Enable();
        m_TargetRenderer.enabled = true;

        m_Target.position = m_TargetSpawn.position;
        StartCoroutine(ShootCoroutine());
    }

    public void Disable()
    {
        m_IsEnabled = false;
        m_TargetMovement.Disable();
        m_TargetRenderer.enabled = false;
    }

    private IEnumerator ShootCoroutine()
    {
        while (m_IsEnabled)
        {
            yield return new WaitForSeconds(m_ShootInterval);
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(m_BulletPrefab, m_BulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().PlayerType = m_PlayerType;
        bullet.GetComponent<Bullet>().SetTarget(m_Target);
    }
    void Awake()
    {
        m_PlayerType = GetComponent<PlayerController>().PlayerType;
        m_TargetMovement = m_Target.GetComponent<PlayerMovement>();
        m_TargetRenderer = m_Target.GetComponent<SpriteRenderer>();        
        
    }
}
