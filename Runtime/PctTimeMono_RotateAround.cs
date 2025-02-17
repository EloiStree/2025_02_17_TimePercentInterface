using System;
using UnityEngine;


public interface I_PercentHandler
{
    void SetToPercent(double percent);
}

public class PctTimeMono_RotateAround : MonoBehaviour, I_PercentHandler
{

    public Transform m_whatToMove;
    public float m_startAngle;
    public float m_angleByFullPercent = 360 * 20f;
    public float m_rightLocalRadiusX= 1f;
    public float m_forwardLocalRadiusZ = 1f;
    public float m_multiplicator=1f;
    public bool m_inverseRotation = false;

    [Range(0,1)]
    public double m_percent = 0f;

    public void Reset()
    {
        m_whatToMove = transform;
    }

    public void OnValidate()
    {
        SetToPercent(m_percent);
    }

    public void SetToPercent(double percent)
    {
        m_percent = percent;
        if (m_whatToMove == null)
        {
            return;
        }
        double angle = m_startAngle + m_angleByFullPercent*(m_inverseRotation?-1f:1f) * percent;
        double x = m_rightLocalRadiusX* m_multiplicator * Math.Cos(angle * Mathf.Deg2Rad);
        double z = m_forwardLocalRadiusZ* m_multiplicator * Math.Sin(angle * Mathf.Deg2Rad);
        m_whatToMove.localPosition = new Vector3((float)x, 0, (float)z);

    }
}
