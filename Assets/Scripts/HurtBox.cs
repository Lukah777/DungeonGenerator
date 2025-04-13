using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField] private float m_waitTime = 0.5f;
    private int m_dmg = 1;
    void Awake()
    {
        Destroy(gameObject, m_waitTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null && !collision.isTrigger)
        {
            HealthComp enemyScript = collision.gameObject.GetComponent<HealthComp>();
            if (enemyScript != null) 
            {
                enemyScript.UpdateHealth(-m_dmg);
            }
            Destroy(gameObject);
        }
    }

    public void SetDmg(int dmg)
    {
        m_dmg = dmg;
    }
}
