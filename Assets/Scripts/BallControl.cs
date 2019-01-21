using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float upwardForce=10f, sidewardForce=5f;
    Vector2 left, right;
    public bool modeLeft = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        left = new Vector2(-sidewardForce, 1);
        right = new Vector2(sidewardForce, 1);
        if (Input.GetButtonDown("Jump"))
        {
            if (rb.velocity.magnitude > 0)
            {
                rb.velocity = Vector2.zero;
            }
            if (modeLeft)
            {
                rb.AddForce(left * upwardForce, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(right * upwardForce, ForceMode2D.Impulse);
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (rb.velocity.magnitude > 0)
                {
                    rb.velocity = Vector2.zero;
                }
                if (modeLeft)
                {
                    rb.AddForce(left * upwardForce, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(right * upwardForce, ForceMode2D.Impulse);
                }
            }
        }
        if (!modeLeft && transform.position.x > 3.5)
        {
            transform.position = new Vector2(transform.position.x - 7, transform.position.y);
        }
        if (modeLeft && transform.position.x < -3.5)
        {
            transform.position = new Vector2(transform.position.x + 7, transform.position.y);
        }
    }
    
}
