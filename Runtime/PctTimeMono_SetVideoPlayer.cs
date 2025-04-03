using System;
using UnityEngine;
namespace Eloi.TimeSync
{

    public class PctTimeMono_SetVideoPlayer : MonoBehaviour, I_PercentHandler
{

    public long m_frameAdjustementRange = 50;
    public UnityEngine.Video.VideoPlayer m_videoPlayer;

    [Range(0, 1)]
    public double m_givenPercent = 0f;
    [Range(0, 1)]
    public double m_videoPercent = 0f;
    public long m_shouldBeAtFrame = 0;
    public long m_totaleFrameCount = 0;

    public void Reset()
    {
        m_videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
    }
    public void Awake()
    {
        m_videoPlayer.Prepare();
    }

    public void SetToPercent(double percent)
    {
        m_givenPercent = percent;
        if (m_videoPlayer == null)
        {
            return;
        }
        m_totaleFrameCount = (long)m_videoPlayer.frameCount;
        m_shouldBeAtFrame = (long)(m_givenPercent * m_totaleFrameCount);
        m_videoPercent = (double)m_shouldBeAtFrame / m_totaleFrameCount;
        if (m_videoPlayer.frame < m_shouldBeAtFrame - m_frameAdjustementRange || m_videoPlayer.frame > m_shouldBeAtFrame + m_frameAdjustementRange)
        {
            m_videoPlayer.frame = m_shouldBeAtFrame;
            m_videoPlayer.Play();
            m_videoPlayer.Pause();
            m_videoPlayer.Play();
        }
    }
}
}
