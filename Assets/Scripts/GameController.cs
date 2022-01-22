using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private float m_BeginDelay = 1.0f;
    [SerializeField] private float m_TurnTime = 5.0f;
    [SerializeField] private UnityEvent<GameState> m_OnTurnChange;
    [SerializeField] private UnityEvent<float> m_OnTurnTick;
    [SerializeField] private UnityEvent<int> m_OnBlackScoreChange;
    [SerializeField] private UnityEvent<int> m_OnWhiteScoreChange;
    private GameState m_GameState;
    private float m_TurnTimer;

    private int m_BlackPlayerScore = 0;
    private int m_WhitePlayerScore = 0;

    public void Damage(GameState playerType)
    {
        if (playerType == GameState.Black)
        {
            m_BlackPlayerScore++;
            m_OnBlackScoreChange.Invoke(m_BlackPlayerScore);
        }
        else
        {
            m_WhitePlayerScore++;
            m_OnWhiteScoreChange.Invoke(m_WhitePlayerScore);
        }
        
    }

    void Start()
    {
        StartCoroutine(BeginCoroutine());
    }

    private void SwitchTurn(GameState state)
    {
        m_OnTurnChange.Invoke(state);
        Debug.Log("Turn changed to " + state);
        m_GameState = state;
        StartCoroutine(TickCoroutine());
    }
    private void ToggleTurn()
    {
        if (m_GameState == GameState.Black)
        {
            SwitchTurn(GameState.White);
        } else 
        {
            SwitchTurn(GameState.Black);
        }
    }

    private IEnumerator BeginCoroutine()
    {
        yield return new WaitForSeconds(m_BeginDelay);
        SwitchTurn(GameState.Black);
    }
    private IEnumerator TickCoroutine()
    {
        m_TurnTimer = m_TurnTime;
        while (m_TurnTimer > 0.0f)
        {
            m_TurnTimer -= Time.deltaTime;
            m_OnTurnTick.Invoke(m_TurnTimer);
            yield return null;
        }
        yield return null;
        ToggleTurn();        
    }
}
