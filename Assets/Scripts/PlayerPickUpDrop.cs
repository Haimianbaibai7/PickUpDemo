using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField]
    private Transform playerCameraTransform;
    [SerializeField]
    private Transform objectGrabPointTransform;
    [SerializeField]
    private LayerMask pickUpLayerMask;

    private ObjectGrabble curObjectGrabble;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(curObjectGrabble==null)
            {
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycasthit, pickUpDistance))
                {
                    Debug.Log(raycasthit.transform);
                    if (raycasthit.transform.TryGetComponent<ObjectGrabble>(out ObjectGrabble objectGrabble))
                    {
                        curObjectGrabble = objectGrabble;
                        objectGrabble.Grab(objectGrabPointTransform);
                    }


                }
            }
            else
            {
                curObjectGrabble.Drop();
                curObjectGrabble = null;
            }

            
        }
    }
}
