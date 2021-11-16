using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sp;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            animationUser(1);
            sp.flipX = false;
        }
        else if(Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            animationUser(1);
            sp.flipX = true;
        }
        
        else 
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animationUser(0);
        }   


        if(Input.GetKey("w"))
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, speed);
        }
        else if(Input.GetKey("s"))
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, -speed);
        }
        else
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, 0);
        }

        if(Input.GetKey("f"))
        {
            speed = 0;
            animationUser(2);
            StartCoroutine(muerte());
        }
    }

    void animationUser(int n)
    {
        anim.SetInteger("State", n);
    }


    IEnumerator muerte()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("EP3Level");
    }
}
