using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSource;
    public AudioClip[] whooshSounds;
    public float upwardForce=10f, sidewardForce=5f;
    Vector2 left, right;
    public bool modeLeft = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            PlaySound();
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
                PlaySound();
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
        if (transform.position.y > 7)
        {
            transform.position=new Vector2(transform.position.x,7f);
        }
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(whooshSounds[Random.Range(0, whooshSounds.Length)]);
    }
    
}
