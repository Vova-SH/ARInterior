using UnityEngine;

public class MenuStackScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Panels;

    private int m_CurrentIndex = 0;

    private void Awake()
    {
        if(m_Panels.Length < 1)
        {
            Debug.LogError("Panels counts less 1. Add more panels.");
        }

        for(int i = 0; i < m_Panels.Length; i++)
        {
            m_Panels[i].SetActive(i == m_CurrentIndex);
        }
    }

    public void NextPanel()
    {
        if (m_CurrentIndex + 1 >= m_Panels.Length) return;
        m_Panels[m_CurrentIndex].SetActive(false);
        m_Panels[++m_CurrentIndex].SetActive(true);
    }
    
    public void PrevPanel()
    {
        if (m_CurrentIndex - 1 < 0) return;
        m_Panels[m_CurrentIndex].SetActive(false);
        m_Panels[--m_CurrentIndex].SetActive(true);
    }
}