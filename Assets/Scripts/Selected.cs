using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void OnRaycastHit()
    {
        rend.material.color = Color.yellow;
    }

    public void OnRaycastDeselect()
    {
        rend.material.color = originalColor;
    }
}
