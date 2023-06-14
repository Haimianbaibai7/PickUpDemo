using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ChangeView : MonoBehaviour
{
    public CinemachineVirtualCamera m_Camera;
    public GameObject player;
    public GameObject MouseTarget;
    private bool isFirstPerson=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isFirstPerson)
            {
                ThirdPerson();
            }
            else
            {
                FirstPerson();
            }
        }
    }

    
    [ContextMenu("FirstPerson")]
    public void FirstPerson()
    {
        m_Camera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = 0;
        player.SetActive(false);
        isFirstPerson = true;
        MouseTarget.SetActive(true);
    }
    [ContextMenu("ThirdPerson")]
    public void ThirdPerson()
    {
        m_Camera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = 4;
        player.SetActive(true);
        isFirstPerson = false;
        MouseTarget.SetActive(false);
    }



}
