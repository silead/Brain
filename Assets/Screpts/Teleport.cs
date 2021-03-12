using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    RaycastHit hitObj;
    bool isKinematic;


    bool b;
    private float _rayDistance = 10f;

    private void Start()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic == true)
        {
            isKinematic = true;
        }
    }
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, _rayDistance) && hit.transform.GetComponent<Outline>() != null)
        {
                hit.transform.GetComponent<Outline>().enabled = true;  
        }
        else
        {
            if (gameObject.transform.GetComponent<Outline>() != null)
            {
                gameObject.transform.GetComponent<Outline>().enabled = false;
            }
        }

        if (b == true)
        {
            Camera.main.transform.parent.transform.position = Vector3.MoveTowards(Camera.main.transform.parent.transform.position, gameObject.transform.position, Time.deltaTime * 30);
            //надо выключить 
            //Debug.Log(gameObject.transform.position - Camera.main.transform.parent.transform.position);
            if (gameObject.transform.position - Camera.main.transform.parent.transform.position == new Vector3(0, 0, 0))
            {
                b = false;
                Camera.main.transform.parent.rotation = new Quaternion(0, 0, 0, 0);
                Camera.main.transform.rotation = new Quaternion(0, 0, 0, 0);
                gameObject.transform.rotation = new Quaternion(0,0,0,0);
                Camera.main.transform.parent.GetComponent<CapsuleCollider>().enabled = true;
                Camera.main.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
                Camera.main.transform.parent.GetComponent<CapsuleCollider>().height = gameObject.GetComponent<CapsuleCollider>().height * gameObject.transform.localScale.y;
                Camera.main.transform.parent.GetComponent<CapsuleCollider>().radius = gameObject.GetComponent<CapsuleCollider>().radius * gameObject.transform.localScale.x;
                gameObject.transform.SetParent(Camera.main.transform.parent);
                Camera.main.transform.parent.GetChild(1).GetComponent<Rigidbody>().isKinematic = true;
                Collider[] colidermasiv = Camera.main.transform.parent.GetChild(1).GetComponents<Collider>();
                for (int i = 0; i < colidermasiv.Length; i++)
                {
                    colidermasiv[i].enabled = false;
                }
                // pojaluist Camera.main.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = false;
                Camera.main.transform.parent.GetChild(1).gameObject.layer = 4;
                for (int i = 0; i < Camera.main.transform.parent.GetChild(1).childCount; i++)
                {
                    Camera.main.transform.parent.GetChild(1).GetChild(i).gameObject.layer = 4;
                }
                _rayDistance = 10f;
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        
        if (Physics.Raycast(ray, out hit, _rayDistance))
        {
            _rayDistance = 0f;
            b = true;
            Camera.main.transform.parent.GetComponent<CapsuleCollider>().enabled = false;
            Camera.main.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
            Collider[] colliders = Camera.main.transform.parent.GetChild(1).GetComponents<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = true;
            }
            // не надо Camera.main.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
            if (Camera.main.transform.parent.GetChild(1).gameObject.GetComponent<Teleport>().isKinematic == false)
            {
                Camera.main.transform.parent.GetChild(1).gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            Camera.main.transform.parent.GetChild(1).gameObject.layer = 0;
            for (int i = 0; i < Camera.main.transform.parent.GetChild(1).childCount; i++)
            {
                Camera.main.transform.parent.GetChild(1).GetChild(i).gameObject.layer = 0;
            }
            Camera.main.transform.parent.GetChild(1).SetParent(null);

            //Camera.main.gameObject.transform.SetParent(gameObject.transform.GetChild(0));
        }
    }
}
