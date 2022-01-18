using UnityEngine;
using UnityEngine.SceneManagement;

public class Flappy : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float pushForce;
    bool isDead;
    bool start;
    MoveBackground[] moveBackgrounds;
    public MoveBackground movePipes;
    float pipesSpeed;
    Vector2 previousVelocity;

    Effects effects;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        moveBackgrounds = FindObjectsOfType<MoveBackground>();

        pipesSpeed = movePipes.moveSpeed;

        effects = FindObjectOfType<Effects>();
    }

    void Update()
    {
        if (!start)
        {
            movePipes.moveSpeed = 0;
        }
        else if (!isDead)
        {
            movePipes.moveSpeed = pipesSpeed;
        }

        if (Input.GetMouseButtonDown(0))
        {
            start = true;

            if (isDead)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                myRigidbody.velocity = Vector2.zero;
                myRigidbody.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("death") && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        for (int i = 0; i < moveBackgrounds.Length; i++)
        {
            moveBackgrounds[i].moveSpeed = 0;
        }

        effects.ApplyEffects();
    }
}
