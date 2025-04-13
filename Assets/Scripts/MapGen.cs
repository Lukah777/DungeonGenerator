using UnityEngine;

public class MapGen : MonoBehaviour
{
    public bool m_topExit;
    public bool m_bottomExit;
    public bool m_leftExit;
    public bool m_rightExit;

    public RoomTemplates m_roomTemplates;

    private int m_numRooms = 10;

    private enum Side { top, bottom, left, right}

    void Start()
    {
        // Cover Ends
        if (m_roomTemplates.m_rooms.Count > m_numRooms)
        {
            if (m_topExit)
            {
                EndCapGen(m_roomTemplates.m_endBottom, Side.top, m_roomTemplates.m_doorFillHorizontal, new Vector3(0, -1.5f, 13));
            }
            if (m_bottomExit)
            {
                EndCapGen(m_roomTemplates.m_endTop, Side.bottom, m_roomTemplates.m_doorFillHorizontal, new Vector3(0, -1.5f, -13));
            }
            if (m_leftExit)
            {
                EndCapGen(m_roomTemplates.m_endRight, Side.left, m_roomTemplates.m_doorFillVertical, new Vector3(-13, -1.5f, 0));
            }
            if (m_rightExit)
            {
                EndCapGen(m_roomTemplates.m_endLeft, Side.right, m_roomTemplates.m_doorFillVertical, new Vector3(13, -1.5f, 0));
            }
        }
        else 
        {
            // MapGen
            if (m_topExit)
            {
                GenRoom(m_roomTemplates.m_enterBottom, Side.top, m_roomTemplates.m_doorFillHorizontal, new Vector3(0, -1.5f, 13));
            }
            if (m_bottomExit)
            {
                GenRoom(m_roomTemplates.m_enterTop, Side.bottom, m_roomTemplates.m_doorFillHorizontal, new Vector3(0, -1.5f, -13));
            }
            if (m_leftExit)
            {
                GenRoom(m_roomTemplates.m_enterRight, Side.left, m_roomTemplates.m_doorFillVertical, new Vector3(-13, -1.5f, 0));
            }
            if (m_rightExit)
            {
                GenRoom(m_roomTemplates.m_enterLeft, Side.right, m_roomTemplates.m_doorFillVertical, new Vector3(13, -1.5f, 0));
            }
        }
        
    }

    private void EndCapGen(GameObject roomEndDir, Side exitSide, GameObject fill, Vector3 offset)
    {
        GameObject newRoom = Instantiate(roomEndDir, transform.position, roomEndDir.transform.rotation);
        for (int i = 0; i < m_roomTemplates.m_rooms.Count; i++)
        {
            if (m_roomTemplates.m_rooms[i].transform.position == newRoom.transform.position)
            {
                Destroy(newRoom);
                newRoom = null;
                MapGen[] gen = m_roomTemplates.m_rooms[i].GetComponentsInChildren<MapGen>();
                int count = 1;
                for (int j = 0; j < gen.Length; j++)
                {
                    if (exitSide == Side.top)
                    {
                        if (!gen[j].m_bottomExit)
                        {
                            count++;
                        }
                    }
                    if (exitSide == Side.bottom)
                    {
                        if (!gen[j].m_topExit)
                        {
                            count++;
                        }
                    }
                    if (exitSide == Side.right)
                    {
                        if (!gen[j].m_leftExit)
                        {
                            count++;
                        }
                    }
                    if (exitSide == Side.left)
                    {
                        if (!gen[j].m_rightExit)
                        {
                            count++;
                        }
                    }
                }
                if (count != gen.Length)
                {
                    Instantiate(fill, transform.position - offset, fill.transform.rotation);
                }
                break;
            }

        }
        if (newRoom != null)
        {
            m_roomTemplates.m_rooms.Add(newRoom);
        }
    }

    private void GenRoom(GameObject[] roomEnterDir, Side exitSide, GameObject fill, Vector3 offset)
    {
        int roomIndex = UnityEngine.Random.Range(0, roomEnterDir.Length - 1);
        GameObject newRoom = Instantiate(roomEnterDir[roomIndex], transform.position, roomEnterDir[roomIndex].transform.rotation);
        for (int i = 0; i < m_roomTemplates.m_rooms.Count; i++)
        {
            if (m_roomTemplates.m_rooms[i].transform.position == newRoom.transform.position)
            {
                Destroy(newRoom);
                newRoom = null;
                MapGen[] gen = m_roomTemplates.m_rooms[i].GetComponentsInChildren<MapGen>();
                int count = 1;
                for (int j = 0; j < gen.Length; j++)
                {
                    if (exitSide == Side.top)
                    {
                        if (!gen[j].m_bottomExit)
                        {
                            count++;
                        } 
                    }
                    if (exitSide == Side.bottom)
                    {
                        if (!gen[j].m_topExit)
                        {
                            count++;
                        }
                    }
                    if (exitSide == Side.right)
                    {
                        if (!gen[j].m_leftExit)
                        {
                            count++;
                        }
                    }
                    if (exitSide == Side.left)
                    {
                        if (!gen[j].m_rightExit)
                        {
                            count++;
                        }
                    }
                }
                if (count != gen.Length)
                {
                    Instantiate(fill, transform.position - offset, fill.transform.rotation);
                }
                break;
            }
        }
        if (newRoom != null)
        {
            m_roomTemplates.m_rooms.Add(newRoom);
        }
    }
}