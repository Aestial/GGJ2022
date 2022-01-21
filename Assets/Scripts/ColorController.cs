using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorController : MonoBehaviour
{
    public Color blackColor; 
    public Color whiteColor;

    [Header("Positive Colors")]
    [SerializeField] private SpriteRenderer[] m_PositiveSprites;
    [SerializeField] private Image[] m_PositiveImages;
    [SerializeField] private TMP_Text[] m_PositiveTexts;

    [Header("Negative Colors")]

    [SerializeField] private Camera m_Camera;
    [SerializeField] private SpriteRenderer[] m_NegativeSprites;
    [SerializeField] private Image[] m_NegativeImages;
    [SerializeField] private TMP_Text[] m_NegativeTexts;

    public void SetColors(GameState state)
    {
        SetPositiveColors(state);
        SetNegativeColors(state);
    }

    private void SetPositiveColors(GameState state)
    {
        Color positiveColor = state == GameState.Black ? whiteColor : blackColor;

        foreach (SpriteRenderer sprite in m_PositiveSprites)
        {
            sprite.color = positiveColor;
        }

        foreach (Image image in m_PositiveImages)
        {
            image.color = positiveColor;
        }

        foreach (TMP_Text text in m_PositiveTexts)
        {
            text.color = positiveColor;
        }
    }

    private void SetNegativeColors(GameState state)
    {
        Color negativeColor = state == GameState.Black ? blackColor : whiteColor;

        m_Camera.backgroundColor = negativeColor;

        foreach (SpriteRenderer sprite in m_NegativeSprites)
        {
            sprite.color = negativeColor;
        }

        foreach (Image image in m_NegativeImages)
        {
            image.color = negativeColor;
        }

        foreach (TMP_Text text in m_NegativeTexts)
        {
            text.color = negativeColor;
        }
    }
}
