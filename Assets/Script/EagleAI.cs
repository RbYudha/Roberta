using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EagleAI2 :EagleAI  cara inheritance 
public class EagleAI : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float flyLength;
    //[SerializeField] private float flyHeight;

    private Rigidbody2D RbEagle;

    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        RbEagle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (facingLeft)
        //{
        //    if (transform.position.x > leftCap)
        //    {
        //        if (facingLeft == true)
        //        {
        //            RbEagle.velocity = new Vector2(-5f, 0f);
        //        }

        //        if (transform.localScale.x != 1)
        //        {
        //            transform.localScale = new Vector3(1, 1, 1);
        //        }
        //    }
        //    else
        //    {
        //        facingLeft = false;
        //    }
        //}
        //else
        //{
        //    if (transform.position.x < rightCap)
        //    {
        //        if (facingLeft == false)
        //        {
        //            RbEagle.velocity = new Vector2(5f, 0f);
        //        }

        //        if (transform.localScale.x != -1)
        //        {
        //            transform.localScale = new Vector3(-1, 1, 1);
        //        }
        //    }
        //    else
        //    {
        //        facingLeft = true;
        //    }
        //}
    }
}
