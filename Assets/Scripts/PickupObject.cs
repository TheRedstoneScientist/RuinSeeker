using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    public float distance; //distance from the camera that the held object hovers
    public float smoothing; //smoothing modifier to the Lerp of the carried object

    GameObject mainCamera; //references the main camera of the player
    bool carrying; //true if the player is carrying something   
    GameObject carriedObject; //object the player is carrying

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (carrying)
        {
            carry(carriedObject);
            checkDrop();
        } else
        {
            pickup();
        }
	}

    void carry(GameObject obj)
    {
        obj.GetComponent<Transform>().position = Vector3.Lerp(obj.GetComponent<Transform>().position, mainCamera.GetComponent<Transform>().position + mainCamera.GetComponent<Transform>().forward * distance, Time.deltaTime * smoothing);
        obj.GetComponent<Transform>().rotation = Quaternion.identity;
    }

    void pickup()
    {
        if (Input.GetKeyDown("e"))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable pick = hit.collider.GetComponent<Pickupable>();
                if (pick != null)
                {
                    carrying = true;
                    carriedObject = pick.gameObject;
                    pick.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
    }

    void checkDrop()
    {
        if (Input.GetKeyDown("e"))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
        Debug.Log("Drop");
    }
}
