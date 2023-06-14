using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectGrabble : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private Transform m_objectGrabPointTransform;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabTransform)
    {
        m_objectGrabPointTransform = grabTransform;
        m_Rigidbody.useGravity = false;
    }

    public void Drop()
    {
        m_objectGrabPointTransform = null;
        m_Rigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if(m_objectGrabPointTransform!=null)
        {
            float lerpSpeed = 20f;
            Vector3 newpositon= Vector3.Lerp(transform.position, m_objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            m_Rigidbody.MovePosition(newpositon);
        }
    }
}
