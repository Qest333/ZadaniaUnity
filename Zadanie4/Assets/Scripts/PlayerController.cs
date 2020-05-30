using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 1;
    public float playerJump = 1;
    private float horizDir;
    private float vertDir;
    private int coll = 1;
    private Rigidbody2D rb;
    private float collSideX = 0;
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
        rb.velocity = new Vector2(horizDir*playerSpeed*coll, rb.velocity.y);
        if(coll == 0 && horizDir == collSideX){
            StartCoroutine(Frames(12));
        }
        if(jump && Input.GetButtonDown("Jump")){
            if(coll == 0 && horizDir == collSideX){
                coll = 1;
            }
            else if(coll == 0){
                return;
            }
            rb.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);
            jump = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform"){
            jump = true;
            foreach (ContactPoint2D hitPos in other.contacts){
                Debug.Log(hitPos.normal);
                if(hitPos.normal.x == 1 || hitPos.normal.x == -1){
                    coll = 0; 
                    collSideX = hitPos.normal.x;
                    rb.velocity = Vector2.zero;
                    rb.gravityScale = 0.20F;
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        rb.gravityScale = 1;
        coll = 1;
        jump = false;
    }

    public IEnumerator Frames(int frameCount)
    {
        while (frameCount > 0)
        {
            frameCount--;
            yield return null;
        }
        coll = 1;
    }
}
