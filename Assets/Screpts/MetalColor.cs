using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalColor : MonoBehaviour
{
    Renderer material;
    float x, y, z;
    public float step = 0.1f;
    bool a, b, c, d, e, f;
    void Start()
    {
        material = gameObject.GetComponent<Renderer>();
        x = 1;
        y = 0;
        z = 0;
        a = true;
    }

    void FixedUpdate()
    {
        //a
        if (a == true)
        {
            y += step;
        }
        if (y >= 1 && a == true)
        {
            y = 1;
            a = false;
            b = true;
        }
        //b
        if (b == true)
        {
            x -= step;
        }
        if (x <= 0 && b == true)
        {
            x = 0;
            b = false;
            c = true;
        }
        //c
        if (c == true)
        {
            z += step;
        }
        if (z >= 1 && c == true)
        {
            z = 1;
            c = false;
            d = true;
        }
        //d
        if (d == true)
        {
            y -= step;
        }
        if (y <= 0 && d == true)
        {
            y = 0;
            d = false;
            e = true;
        }
        //e
        if (e == true)
        {
            x += step;
        }
        if (x >= 1 && e == true)
        {
            x = 1;
            e = false;
            f = true;
        }
        //f
        if (f == true)
        {
            z -= step;
        }
        if (z <= 0 && f == true)
        {
            z = 0;
            f = false;
            a = true;
        }
        material.material.color = new Color(x,y,z,1);
    }
}
