using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 1;
    public float playerJump = 1;
    private float horizDir;
    private float vertDir;
    private Rigidbody2D rb;
    private bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizDir = Input.GetAxisRaw("Horizontal");
        vertDir = Input.GetAxisRaw("Vertical");

        //transform.position += new Vector3(horizDir,vertDir,0) * Time.deltaTime * playerSpeed;
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizDir*playerSpeed, rb.velocity.y);
        if(jump && Input.GetButtonDown("Jump")){
            rb.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);
            jump = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        jump = true;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        jump = false;
    }

}
