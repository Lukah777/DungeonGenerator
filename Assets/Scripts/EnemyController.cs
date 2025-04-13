using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int m_range = 5;
    [SerializeField] private int m_dmg = 1;
    [SerializeField] private NavMeshAgent m_agent;
    [SerializeField] private GameObject[] m_items;
    [SerializeField] private int[] m_dropRate;
    [SerializeField] private int m_randRange = 45;
    private GameObject m_player;

    private void Update()
    {
        if (m_player != null && Vector3.Distance(m_player.transform.position, transform.position) <= m_range)
        {
            m_agent.destination = m_player.transform.position;
        }            
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_player = collision.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthComp playerScript = collision.gameObject.GetComponent<HealthComp>();
            if (playerScript != null)
            {
                playerScript.UpdateHealth(-m_dmg);
            }
        }
    }

    public void Die()
    {
        GetComponentInParent<EnemyManager>().UpdateCount(-1);
        int rand = Random.Range(1, m_randRange);
        if (rand <= m_dropRate[0]) 
        {
            Instantiate(m_items[0], transform.position, transform.rotation);
        }
        else if (rand <= m_dropRate[1])
        {
            Instantiate(m_items[1], transform.position, transform.rotation);
        }
        else if (rand <= m_dropRate[2])
        {
            Instantiate(m_items[2], transform.position, transform.rotation);
        }
        else if (rand <= m_dropRate[3])
        {
            Instantiate(m_items[3], transform.position, transform.rotation);
        }
        else if (rand <= m_dropRate[4])
        {
            if (m_items[4] != null)
                Instantiate(m_items[4], transform.position, transform.rotation);
        }
       

        Destroy(gameObject);
    }
}