using UnityEngine;
namespace Eloi.TimeSync
{

    public class PctTimeToolMono_SetColorToRenderer : MonoBehaviour
{

    public Renderer[] m_rendererToAffect;
    public Material[] m_materialsToAffect;

    public void PushColor(Color color) {

        if (Application.isPlaying) {
            foreach (var renderer in m_rendererToAffect)
            {
                if(renderer == null)
                    continue;
                renderer.material.color = color;
            }
        }
        foreach (var material in m_materialsToAffect)
        {
            if (material == null)
                continue;
            material.color = color;
        }
    }
}
}