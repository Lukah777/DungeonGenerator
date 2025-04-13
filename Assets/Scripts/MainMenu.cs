using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.AI.Navigation;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_gameName;
    [SerializeField] private GameObject m_mainMenu;
    [SerializeField] private GameObject m_charSelect;
    [SerializeField] private GameObject m_classSelect;

    [SerializeField] private Material[] m_races;

    [SerializeField] private GameObject m_player;
    [SerializeField] private NavMeshSurface m_navSurface;

    private void Awake()
    {
        m_gameName.GetComponent<TextMeshProUGUI>().SetText("Dungeon Game");
    }

    public void Play()
    {
        m_mainMenu.SetActive(false);
        m_charSelect.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Human()
    {
        m_player.GetComponent<Renderer>().material = m_races[0];
        ClassMenu();
    }
    public void Dwarf()
    {
        m_player.GetComponent<Renderer>().material = m_races[1];
        m_player.GetComponent<InventoryStats>().UpgradeStat("Con", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Wis", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Dex", -1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Cha", -1);
        ClassMenu();
    }
    public void Elf()
    {
        m_player.GetComponent<Renderer>().material = m_races[2];
        m_player.GetComponent<InventoryStats>().UpgradeStat("Dex", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Cha", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Con", -1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Cha", -1);
        ClassMenu();
    }
    public void Gnome()
    {
        m_player.GetComponent<Renderer>().material = m_races[3];
        m_player.GetComponent<InventoryStats>().UpgradeStat("Dex", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Int", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Cha", -1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Con", -1);
        ClassMenu();
    }
    public void Tabaxi()
    {
        m_player.GetComponent<Renderer>().material = m_races[4];
        m_player.GetComponent<InventoryStats>().UpgradeStat("Dex", +3);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Int", -1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Wis", -1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Con", -1);
        ClassMenu();
    }
    public void Kenku()
    {
        m_player.GetComponent<Renderer>().material = m_races[5];
        m_player.GetComponent<InventoryStats>().UpgradeStat("Dex", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Wis", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Str", -1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Con", -1);
        ClassMenu();
    }
    public void DragonBorn()
    {
        m_player.GetComponent<Renderer>().material = m_races[6];
        m_player.GetComponent<InventoryStats>().UpgradeStat("Con", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Str", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Cha", -1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Dex", -1);
        ClassMenu();
    }
    public void Troll()
    {
        m_player.GetComponent<Renderer>().material = m_races[7];
        m_player.GetComponent<InventoryStats>().UpgradeStat("Dex", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Con", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Str", +1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Int", -1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Wis", -1);
        m_player.GetComponent<InventoryStats>().UpgradeStat("Cha", -1);
        ClassMenu();
    }
    private void ClassMenu()
    {
        m_charSelect.SetActive(false); 
    }

    public void Sword()
    {
        m_player.GetComponent<InventoryStats>().AddItem("Sword");
        StartGame();
    }
    public void Bow()
    {
        m_player.GetComponent<InventoryStats>().AddItem("Bow");
        StartGame();
    }
    public void Wand()
    {
        m_player.GetComponent<InventoryStats>().AddItem("Wand");
        StartGame();
    }
    public void Staff()
    {
        m_player.GetComponent<InventoryStats>().AddItem("Staff");
        StartGame();
    }
    public void Bible()
    {
        m_player.GetComponent<InventoryStats>().AddItem("Bible");
        StartGame();
    }
    private void StartGame()
    {
        m_classSelect.SetActive(false);
        m_player.GetComponent<PlayerController>().SetEnabled(true);
        m_navSurface.BuildNavMesh();
    }
}
