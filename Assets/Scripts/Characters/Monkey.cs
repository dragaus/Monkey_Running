using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monkey : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    bool canJump = false;
    bool isAlive = true;

    Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAlive) return;

        if (Input.GetAxis("Jump") > 0 && canJump)
        {
            rigi.AddForce(Vector2.up * jumpForce);
            canJump = false;
        }

        var dir = Input.GetAxis("Horizontal");
        if (dir > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if(dir < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        transform.Translate(transform.right * speed * dir * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (rigi.velocity.y >= 0)
            {
                Debug.Log("El mono muere");
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnBecameInvisible()
    {
        StartCoroutine(KillTheMonkey());
    }

    IEnumerator KillTheMonkey()
    {
        yield return new WaitForSeconds(2f);
        isAlive = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }
}
