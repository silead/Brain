using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    [SerializeField] private Image _stayPoint;
    [SerializeField] private Image _canPoint;

    private void Start()
    {
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.red);

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.transform.GetComponent<Teleport>() != null)
            {
                _stayPoint.enabled = false;
                _canPoint.enabled = true;
            }
            else
            {
                _stayPoint.enabled = true;
                _canPoint.enabled = false;
            }
        }
        else
        {
            _stayPoint.enabled = true;
            _canPoint.enabled = false;
        }
    }
}
