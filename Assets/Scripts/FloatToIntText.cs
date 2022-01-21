using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatToIntText : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    public void SetText(float value)
    {
        int intValue = Mathf.CeilToInt(value);
        m_Text.text = intValue.ToString();
    }
}
