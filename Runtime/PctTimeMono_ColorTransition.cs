using System;
using UnityEngine;
using UnityEngine.Events;


public class PctTimeMono_ColorTransition : MonoBehaviour, I_PercentHandler
{
    [Range(0, 1)]
    public float m_percent = 0f; // Changed to float for consistency
    public ColorFrame[] m_colorFrames;
    public UnityEvent<Color> m_onColorChanged;
    public Renderer[] m_renderers; // Renamed for clarity

    [System.Serializable]
    public class ColorFrame
    {
        [Range(0f, 1f)]
        public float m_percentTime;
        public Color m_colorAtThatPoint = new Color(1, 1, 1, 1);
    }

    public void SetToPercent(double givenPercent) // Changed from double to float
    {
        float percent = (float)givenPercent;
        m_percent = percent;
        if (m_colorFrames == null || m_colorFrames.Length <= 1)
        {
            return;
        }

        Color color = Color.white;

        for (int i = 0; i < m_colorFrames.Length; i++)
        {
            if (percent < m_colorFrames[i].m_percentTime)
            {
                if (i == 0)
                {
                    color = m_colorFrames[i].m_colorAtThatPoint;
                }
                else
                {
                    float percentBetween = (percent - m_colorFrames[i - 1].m_percentTime) /
                                           (m_colorFrames[i].m_percentTime - m_colorFrames[i - 1].m_percentTime);
                    color = Color.Lerp(m_colorFrames[i - 1].m_colorAtThatPoint, m_colorFrames[i].m_colorAtThatPoint, percentBetween);
                }
                break; // Instead of return, ensuring updates happen after loop
            }
        }

        // Ensure color is set to last frame if percent is beyond last defined frame
        if (percent >= m_colorFrames[m_colorFrames.Length - 1].m_percentTime)
        {
            color = m_colorFrames[m_colorFrames.Length - 1].m_colorAtThatPoint;
        }

        // Invoke color change event
        m_onColorChanged.Invoke(color);

        // Apply color to renderers
        if (m_renderers != null && Application.isPlaying)
        {
            foreach (Renderer renderer in m_renderers)
            {
                if (renderer != null)
                {
                    renderer.material.color = color;
                }
            }
        }
    }
}
