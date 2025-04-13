using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI;
using Unity.AI.Navigation;
using UnityEngine;

public class FillRoom : MonoBehaviour
{
    [SerializeField] private GameObject m_wall;
    [SerializeField] private GameObject m_box;
    [SerializeField] private GameObject[] m_enemies;
    [SerializeField] private TextAsset[] m_roomLayouts;

    private Transform[] m_nodes;
    private int m_asciiOffset = 48;

    void Start()
    {
        EnemyManager enmeyManager = GetComponent<EnemyManager>();
        int rand = UnityEngine.Random.Range(0, m_roomLayouts.Length);
        string room = m_roomLayouts[rand].text;
        int t = 1;
        m_nodes = GetComponentsInChildren<Transform>();

        foreach (Char c in room)
        {
            int i = Convert.ToInt16(c) - m_asciiOffset;
            if (i == 1)
            {
                Instantiate(m_wall, m_nodes[t]);
            }
            else if (i == 2)
            {
                Instantiate(m_box, m_nodes[t]);
            }
            else if (i == 3)
            {
                Instantiate(m_enemies[0], m_nodes[t]);
                enmeyManager.UpdateCount(1);
            }
            else if (i == 4)
            {
                Instantiate(m_enemies[1], m_nodes[t]);
                enmeyManager.UpdateCount(1);
            }
            else if (i == 5)
            {
                Instantiate(m_enemies[2], m_nodes[t]);
                enmeyManager.UpdateCount(1);
            }
            else if (i == 6)
            {
                Instantiate(m_enemies[3], m_nodes[t]);
                enmeyManager.UpdateCount(1);
            }
            else if (i == 7)
            {
                Instantiate(m_enemies[4], m_nodes[t]);
                enmeyManager.UpdateCount(1);
            }
            else if (i == 8)
            {
                Instantiate(m_enemies[5], m_nodes[t]);
                enmeyManager.UpdateCount(1);
            }
            t++;
        }
    }
}
