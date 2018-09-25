using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    private Rigidbody2D rb;
    private bool faceRight = true;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed / 2 * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = speed * 2;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = speed / 2;

        //прыжок
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 6000);
        }

        if (moveX > 0 && !faceRight)
            Flip();
        else if (moveX < 0 && faceRight)
            Flip();
	}
    void Flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
