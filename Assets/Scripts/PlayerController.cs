using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject m_healthBar;
    [SerializeField] private GameObject m_hurtBox;
    [SerializeField] private RoomTemplates m_roomTemplates;

    private Slider m_slider;
    private InventoryStats m_inventoryStats;
    private HealthComp m_healthComp;
    private Rigidbody m_rigidbody;

    private bool m_controllable = true;
    private bool m_enabled = false;
    private GameObject m_spawnedHurtBox;
    private int m_speed = 5;
    private float m_attackOffset = 1.1f;

    private void Awake()
    {
        m_roomTemplates.Reset();
        m_slider = m_healthBar.GetComponentInChildren<Slider>();
        m_inventoryStats = GetComponent<InventoryStats>();
        m_healthComp = GetComponent<HealthComp>();
        m_rigidbody = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        if (!m_enabled)
            return;
        if (!m_controllable)
        {
            if (m_spawnedHurtBox == null)
            {
                m_rigidbody.velocity = Vector3.zero;
                m_controllable = true;
            }
            return;
        }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 moveVect = new Vector3(horizontal, 0, vertical);
        float mod = m_inventoryStats.GetDex() + m_speed;
        m_rigidbody.velocity = moveVect * mod;

        m_slider.maxValue = m_healthComp.GetMaxHealth();
        m_slider.value = m_healthComp.GetCurrentHealth();        

        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);

        if (Input.GetKeyDown(KeyCode.Mouse0) && m_controllable)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            m_inventoryStats.UsePotion();
        }
    }

    private void Attack()
    {
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        int damageType = 0;
        Material weaponSprite = null;

        if (m_inventoryStats.GetWeapon() == Weapons.Sword)
        {
            damageType = m_inventoryStats.GetStr();
            weaponSprite = m_inventoryStats.GetWeaponSprite(Weapons.Sword);
        }
        else if (m_inventoryStats.GetWeapon() == Weapons.Bow)
        {
            damageType = m_inventoryStats.GetDex();
            weaponSprite = m_inventoryStats.GetWeaponSprite(Weapons.Bow);
        }
        else if (m_inventoryStats.GetWeapon() == Weapons.Wand)
        {
            damageType = m_inventoryStats.GetInt();
            weaponSprite = m_inventoryStats.GetWeaponSprite(Weapons.Wand);
        }
        else if (m_inventoryStats.GetWeapon() == Weapons.Staff)
        {
            damageType = m_inventoryStats.GetWis();
            weaponSprite = m_inventoryStats.GetWeaponSprite(Weapons.Staff);
        }
        else if (m_inventoryStats.GetWeapon() == Weapons.Bible)
        {
            damageType = m_inventoryStats.GetCha();
            weaponSprite = m_inventoryStats.GetWeaponSprite(Weapons.Bible);
        }

        m_rigidbody.velocity = Vector3.zero;
        Vector3 spawnPos = transform.forward * m_attackOffset + transform.position;
        Quaternion spawnRos = transform.rotation * new Quaternion(0,180,0,0);
        m_spawnedHurtBox = Instantiate(m_hurtBox, spawnPos, spawnRos);
        m_spawnedHurtBox.GetComponent<HurtBox>().SetDmg(damageType);
        m_spawnedHurtBox.GetComponent<Renderer>().material = weaponSprite;
        m_controllable = false;
    }

    public void SetEnabled(bool set)
    {
        m_enabled = set;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.GetComponent<Item>().UseItem(gameObject);
        }
    }
}
