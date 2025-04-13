using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private static int m_count = -1;

    private void Update()
    {
        if (m_count == 0)
            SceneManager.LoadScene(2);
    }

    public void UpdateCount(int count)
    { 
        if (m_count == -1)
            m_count = 0;
        m_count += count; 
    }
}
