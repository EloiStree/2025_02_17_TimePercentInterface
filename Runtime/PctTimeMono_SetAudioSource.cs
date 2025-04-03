using System;
using UnityEngine;
namespace Eloi.TimeSync
{

    public class PctTimeMono_SetAudioSource : MonoBehaviour, I_PercentHandler
{
    public AudioSource m_audioSource;
    public float m_outOfRangeInSeconds = 0.1f;

    [Range(0, 1)]
    public double m_givenPercent = 0f;
    [Range(0, 1)]
    public double m_audioPercent = 0f;
    public double m_shouldBeAtTime = 0;
    public double m_totalAudioDuration = 0;

    public void Reset()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public void Awake()
    {
        if (m_audioSource.clip != null)
        {
            m_totalAudioDuration = m_audioSource.clip.length;
        }
    }

    public void SetToPercent(double percent)
    {
        m_givenPercent = percent;
        if (m_audioSource == null || m_audioSource.clip == null)
        {
            return;
        }

        m_totalAudioDuration = m_audioSource.clip.length;
        m_shouldBeAtTime = m_givenPercent * m_totalAudioDuration;
        m_audioPercent = m_shouldBeAtTime / m_totalAudioDuration;

        if (Math.Abs(m_audioSource.time - m_shouldBeAtTime) > m_outOfRangeInSeconds)
        {
            m_audioSource.time = (float)m_shouldBeAtTime;
            m_audioSource.Play();
        }
    }
}
}