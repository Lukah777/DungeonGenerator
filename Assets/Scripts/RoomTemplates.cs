using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoomTemplates", order = 1)]
public class RoomTemplates : ScriptableObject
{
    public GameObject[] m_enterBottom;
    public GameObject[] m_enterTop;
    public GameObject[] m_enterRight;
    public GameObject[] m_enterLeft;

    public GameObject m_endBottom;
    public GameObject m_endTop;
    public GameObject m_endRight;
    public GameObject m_endLeft;

    public GameObject m_doorFillHorizontal;
    public GameObject m_doorFillVertical;

    public List<GameObject> m_rooms;

    public void Reset()
    {
        m_rooms.Clear();
    }
}