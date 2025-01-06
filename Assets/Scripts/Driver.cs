using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float turnSpeed = 0.5f;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float destroyDelay = 0.2f;
    [SerializeField] Color32 noPizzaColor = new Color32(1, 1, 1, 255);
    [SerializeField] Color32 hasPizzaColor = new Color32(1, 1, 1, 255);

    [SerializeField] float slowSpeed = 1f;
    [SerializeField] float boostSpeed = 3f;


    private SpriteRenderer spriteRenderer;

    bool hasPizza;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; //-1 to 1

        transform.Rotate(0, 0, -steerAmount);

        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; //-1 to 1

        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Obstacle"))
        {
            moveSpeed = slowSpeed;
            Debug.Log("Hit the obstacle");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag( "Customer") && hasPizza)
        {
            Debug.Log("Pizza delivered!");
            hasPizza = false;
            spriteRenderer.color = noPizzaColor;
        }

        if (collider.gameObject.CompareTag("Pizza") && !hasPizza)
        {
            Debug.Log("Pizza collected!");
            hasPizza = true;
            Destroy(collider.gameObject, destroyDelay);
            spriteRenderer.color = hasPizzaColor;
        }


        if (collider.gameObject.CompareTag("SpeedBoost"))
        {
            Debug.Log("Speed boost collected!");
            moveSpeed = boostSpeed;
            Destroy(collider.gameObject, destroyDelay);
        }

    }
}