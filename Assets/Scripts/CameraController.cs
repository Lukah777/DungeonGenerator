using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 m_offset = new Vector3(0, 5, -5);
    [SerializeField] private Transform m_followTransform = null;

    private void Update()
    {
        if (m_followTransform != null)
        {

            this.transform.position = m_followTransform.position + m_followTransform.forward * -m_offset.x + m_followTransform.up * m_offset.y;

        }
    }
}
