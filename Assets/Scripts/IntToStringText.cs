using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntToStringText : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    public void SetText(int value)
    {
        m_Text.text = value.ToString();
    }
}
