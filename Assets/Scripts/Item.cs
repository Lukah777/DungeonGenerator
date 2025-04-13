using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string m_name;
    [SerializeField] private int m_statIncreseAmmount = 0;
    public void UseItem(GameObject user)
    {
        if (m_statIncreseAmmount == 0)
            user.GetComponent<InventoryStats>().AddItem(m_name);
        else 
            user.GetComponent<InventoryStats>().UpgradeStat(m_name, m_statIncreseAmmount);

        Destroy(gameObject);
    }
}
