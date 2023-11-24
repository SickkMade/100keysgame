using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public bool grabPressed = false;

    private Ray ray;

    [SerializeField]
    private float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if(hit.collider.gameObject.GetComponent<Selected>() != null)
            {
                hit.collider.gameObject.GetComponent<Selected>().OnRaycastHit();
            }
        }
    }
}
