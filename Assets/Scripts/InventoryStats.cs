using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Weapons { None, Sword, Bow, Wand, Staff, Bible}
public enum Armor { None, Cloth, Leather, Iron }

public class InventoryStats : MonoBehaviour
{
    [SerializeField] private int m_strength = 10;
    [SerializeField] private int m_dexterity = 10;
    [SerializeField] private int m_constitution = 10;
    [SerializeField] private int m_intelegence = 10;
    [SerializeField] private int m_wisdom = 10;
    [SerializeField] private int m_charisma = 10;

    [SerializeField] private int m_potions = 0;

    [SerializeField] private Weapons m_weapon;
    [SerializeField] private Armor m_armor;
    [SerializeField] private GameObject m_visibleArmor;

    [SerializeField] private GameObject[] m_items;

    [SerializeField] private HealthComp m_healthComp;

    [SerializeField] private TMP_Text m_PotionText;
    [SerializeField] private TMP_Text[] m_stats;

    private int m_potionAmmount = 25;
    private float m_dropOffset = 1.25f;

    private void Update()
    {
        m_stats[0].text = "Strength: " + m_strength;
        m_stats[1].text = "Dexterity: " + m_dexterity;
        m_stats[2].text = "Constitution: " + m_constitution;
        m_stats[3].text = "Intelegence: " + m_intelegence;
        m_stats[4].text = "Wisdom: " + m_wisdom;
        m_stats[5].text = "Charisma: " + m_charisma;

        m_PotionText.text = "Potions: " + m_potions;
    }

    public void UpgradeStat(string stat, int amount)
    {
        if (stat == "Str")
            m_strength += amount;
        else if (stat == "Dex")
            m_dexterity += amount;
        else if (stat == "Con")
        {
            m_constitution += amount;
            m_healthComp.UpdateCon();
        }
        else if (stat == "Int")
            m_intelegence += amount;
        else if (stat == "Wis")
            m_wisdom += amount;
        else if (stat == "Cha")
            m_charisma += amount;
    }
    public void AddItem(string item)
    {
        if (item == "Sword")
        {
            if (m_weapon != Weapons.None)
            {
                DropItem(m_weapon.ToString());
            }
            m_weapon = Weapons.Sword;

        }
        else if (item == "Bow")
        {
            if (m_weapon != Weapons.None)
            {
                DropItem(m_weapon.ToString());
            }
            m_weapon = Weapons.Bow;

        }
        else if (item == "Wand")
        {
            if (m_weapon != Weapons.None)
            {
                DropItem(m_weapon.ToString());
            }
            m_weapon = Weapons.Wand;

        }
        else if (item == "Staff")
        {
            if (m_weapon != Weapons.None)
            {
                DropItem(m_weapon.ToString());
            }
            m_weapon = Weapons.Staff;

        }
        else if (item == "Bible")
        {
            if (m_weapon != Weapons.None)
            {
                DropItem(m_weapon.ToString());
            }
            m_weapon = Weapons.Bible;

        }
        else if (item == "Cloth")
        {
            if (m_armor != Armor.None)
            {
                DropItem(m_armor.ToString());

            }
            m_armor = Armor.Cloth;
            m_healthComp.SetArmor(1);
            m_visibleArmor.GetComponent<Renderer>().material = m_items[5].GetComponent<Renderer>().sharedMaterial;
        }
        else if (item == "Leather")
        {
            if (m_armor != Armor.None)
            {
                DropItem(m_armor.ToString());
            }
            m_armor = Armor.Leather;
            m_healthComp.SetArmor(2);
            m_visibleArmor.GetComponent<Renderer>().material = m_items[6].GetComponent<Renderer>().sharedMaterial;
        }
        else if (item == "Iron")
        {
            if (m_armor != Armor.None)
            {
                DropItem(m_armor.ToString());
            }
            m_armor = Armor.Iron;
            m_healthComp.SetArmor(3);
            m_visibleArmor.GetComponent<Renderer>().material = m_items[7].GetComponent<Renderer>().sharedMaterial;
        }
        else if (item == "Potion")
        {
            m_potions++;
        }
    }

    private void DropItem(string item)
    {
        Vector3 spawnPos = transform.right * m_dropOffset + transform.position;

        if (item == "Sword")
        {
            Instantiate(m_items[0], spawnPos, transform.rotation);
        }
        else if (item == "Bow")
        {
            Instantiate(m_items[1], spawnPos, transform.rotation);
        }
        else if (item == "Wand")
        {
            Instantiate(m_items[2], spawnPos, transform.rotation);
        }
        else if (item == "Staff")
        {
            Instantiate(m_items[3], spawnPos, transform.rotation);
        }
        else if (item == "Bible")
        {
            Instantiate(m_items[4], spawnPos, transform.rotation);
        }
        else if (item == "Cloth")
        {
            Instantiate(m_items[5], spawnPos, transform.rotation);
        }
        else if (item == "Leather")
        {
            Instantiate(m_items[6], spawnPos, transform.rotation);
        }
        else if (item == "Iron")
        {
            Instantiate(m_items[7], spawnPos, transform.rotation);
        }
    }

    public int GetStr() { return m_strength; }
    public int GetDex()
    {
        if (m_armor == Armor.Iron)
            if (m_dexterity - 3 > 0)
                return m_dexterity - 3;
            else
                return 1;
        else
            return m_dexterity;
    }

    public int GetCon() { return m_constitution; }
    public int GetInt() 
    {
        if (m_armor == Armor.Cloth)
            return m_intelegence + 1;
        else
            return m_intelegence; 
    }
    public int GetWis()
    {
        if (m_armor == Armor.Cloth)
            return m_wisdom + 1;
        else
            return m_wisdom;
    }
    public int GetCha()
    {
        if (m_armor == Armor.Cloth)
            return m_charisma + 1;
        else
            return m_charisma;
    }
    public Weapons GetWeapon() { return m_weapon; }
    public Armor GetArmor() { return m_armor; }
    public Material GetWeaponSprite(Weapons weapon) 
    {
        if (weapon == Weapons.Sword)
        {
            return m_items[0].GetComponent<Renderer>().sharedMaterial;
        }
        else if (weapon == Weapons.Bow)
        {
            return m_items[1].GetComponent<Renderer>().sharedMaterial;
        }
        else if (weapon == Weapons.Wand)
        {
            return m_items[2].GetComponent<Renderer>().sharedMaterial;
        }
        else if (weapon == Weapons.Staff)
        {
            return m_items[3].GetComponent<Renderer>().sharedMaterial;
        }
        else if (weapon == Weapons.Bible)
        {
            return m_items[4].GetComponent<Renderer>().sharedMaterial;
        }
        return null;
    }

    public void UsePotion()
    {
        if (m_potions > 0)
        {
            m_potions--;
            m_healthComp.UpdateHealth(m_potionAmmount * m_constitution);
        }
    }
}
