using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rig;
    public Animator anim;

    public float speed;
    public float jumpForce;

    [SerializeField]
    private bool isJumping = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("Jumping", true);
            isJumping = true;

        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 6)
        {
            anim.SetBool("Jumping", false);
            isJumping = false;
        }
    }

}
