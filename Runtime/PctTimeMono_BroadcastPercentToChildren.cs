
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Eloi.TimeSync
{

    public class PctTimeMono_BroadcastPercentToChildren: MonoBehaviour, I_PercentHandler
{
    [Range(0f,1f)]
    public double m_lastPercentReceived;
    public bool m_useInactive = false;

    public List<I_PercentHandler> m_handlers = new List<I_PercentHandler>();

    public void Awake()
    {
        RefreshInterfaces();
    }

    private void RefreshInterfaces()
    {
        I_PercentHandler current = this;
        Transform[] objs = GetComponentsInChildren<Transform>(true);
        List<I_PercentHandler> handlers = new List<I_PercentHandler>();
        foreach (Transform t in objs)
        {

            if (t == transform) { continue; }
            I_PercentHandler[] handler = t.GetComponentsInChildren<I_PercentHandler>();
            foreach (I_PercentHandler h in handler)
            {
                handlers.Add(h);
            }
        }
        m_handlers = handlers.Distinct<I_PercentHandler>().ToList();
    }

    public void SetToPercent(double percent)
    {
        if (Application.isPlaying == false)
        {
            RefreshInterfaces();
        }
        m_lastPercentReceived = percent;
        foreach (I_PercentHandler h in m_handlers)
        {
            if(m_handlers == null)
            {
                continue;
            }
            h.SetToPercent(percent);
        }
    }
}
}