using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /************PLAYER(S)************/

    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f; 

    Vector2 playerMovement;
    Vector2 mouseMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        mouseMovement = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerMovement * moveSpeed * Time.fixedDeltaTime);
        Vector2 look = rb.position - mouseMovement;

        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg +90f;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rot;
    }
}

