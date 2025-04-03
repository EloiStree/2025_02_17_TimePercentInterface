using UnityEngine;
namespace Eloi.TimeSync
{

    public class PctTimeToolMono_ReloadScene : MonoBehaviour
{

    public bool m_useSceneName;
    public string m_sceneToLoad="SceneName";
    public bool m_useSceneIndex;
    public int m_sceneIndex= 0;

    public void LoadSceneFromIndex(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
    public void LoadSceneFromName(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
    public void LoadCurrentSceen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void LoadSceneFromInspector()
    {
        if (m_useSceneName)
        {
            LoadSceneFromName(m_sceneToLoad);
        }
        else if (m_useSceneIndex)
        {
            LoadSceneFromIndex(m_sceneIndex);
        }
        
    }
}
}
