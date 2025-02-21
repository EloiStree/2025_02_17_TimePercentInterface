using UnityEngine;
using UnityEngine.Events;

public class UIPctTimeMono_PercentState : MonoBehaviour
{
    [Range(0,1)]
    public float m_lastPercent;
    public string m_textFormat = "{0}%";
    public UnityEvent<float> m_onPercentRelayed;
    public UnityEvent<string> m_onTextRelayed;
    public UnityEvent<string> m_onText100PercentRelayed;

    public bool m_useOnValidate = true;
    public void SetToPercent(float percent)
    {
        m_lastPercent = percent;
        m_onPercentRelayed.Invoke(percent);
        m_onTextRelayed.Invoke(string.Format(m_textFormat, percent ));
        m_onText100PercentRelayed.Invoke(string.Format(m_textFormat, percent * 100));
    }

    private void OnValidate()
    {
        if (m_useOnValidate)
        {
            SetToPercent(m_lastPercent);

        }
    }
}
