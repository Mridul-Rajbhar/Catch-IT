using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCross : MonoBehaviour
{

    Vector3 scaleChange;
    public float change;
    public float max_size;
    public float min_size;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scaleChange = transform.localScale;
        if (scaleChange.x > max_size && scaleChange.y > max_size)
        {
            change = -change;
        }
        else if (scaleChange.x < min_size && scaleChange.y < min_size)
        {
            change = -change;
        }
        scaleChange.x = scaleChange.x + Time.deltaTime * change;
        scaleChange.y = scaleChange.y + Time.deltaTime * change;
        transform.localScale = scaleChange;
    }

}
