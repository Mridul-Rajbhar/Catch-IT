using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 position;
    public Rigidbody2D rb;
    public float force;
    private const float rotate = 3;
    // Start is called before the first frame update

    private void Awake()
    {
        position = gameObject.transform.position;
    }
    void Start()
    {
        if (position.x < 0 && position.y > 0)
            rb.AddForce(new Vector2(-force, force));
        else if (position.x < 0 && position.y < 0)
            rb.AddForce(new Vector2(-force, -force));
        else if (position.x > 0 && position.y > 0)
            rb.AddForce(new Vector2(force, force));
        else
            rb.AddForce(new Vector2(force,-force));

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotate);
    }
  

}
