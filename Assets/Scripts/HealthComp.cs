using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComp : MonoBehaviour
{
    [SerializeField] private int m_health = 10;
    [SerializeField] private int m_healthMax = 10;
    [SerializeField] private int m_armor = 0;
    [SerializeField] private InventoryStats m_inventoryStats = null;
    
    public void UpdateCon()
    {
        if (m_inventoryStats != null)
        {
            m_health *= m_inventoryStats.GetCon();
            m_healthMax *= m_inventoryStats.GetCon();
        }
    }
    public int GetCurrentHealth()
    {
        return m_health;
    }
    public int GetMaxHealth()
    {
        return m_healthMax;
    }
    public void UpdateHealth(int healthChange)
    {
        if (healthChange < 0)
        {
            if (healthChange + m_armor > 0)
                healthChange = 0;
            else 
                healthChange += m_armor;
        }

        m_health += healthChange;

        if (m_health <= 0)
        {
            if (gameObject.GetComponent<PlayerController>() != null)
            {
                SceneManager.LoadScene(1);
            }
            else if (gameObject.GetComponent<EnemyController>() != null)
            {
                gameObject.GetComponent<EnemyController>().Die();
            }
        }
        else if (m_health > m_healthMax)
        {
            m_health = m_healthMax;
        }
    }

    public void SetArmor(int armor)
    {
        m_armor = armor;
    }
}
