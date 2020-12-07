using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLength;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask ground;

    private Collider2D collFrog;
    private Rigidbody2D RbFrog;

    private bool facingLeft = true;

    private void Start()
    {
        collFrog = GetComponent<Collider2D>();
        RbFrog = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                //make sure frog facing to the right direction
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                if (collFrog.IsTouchingLayers(ground))
                {
                    RbFrog.velocity = new Vector2(-jumpLength, jumpHeight);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        else {
            if (transform.position.x < rightCap)
            {
                //make sure frog facing to the right direction
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }

                if (collFrog.IsTouchingLayers(ground))
                {
                    RbFrog.velocity = new Vector2(jumpLength, jumpHeight);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }

}