using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D PlayerRigidBody;
    public int ForceJump;
    public Animator Anime;
    public BoxCollider2D boxColider;

    public Transform GroundCheck;
    public bool grounded;
    public LayerMask WhatIsGround;

    public bool Slide;
    public float SlideTemp;
    private float TimeTemp;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Slide = false;
            PlayerRigidBody.AddForce(new Vector2(0, ForceJump));
        }
        if (Input.GetButtonDown("Slide") && grounded)
        {
            Slide = true;
            TimeTemp = 0;
        }

        if (Slide == true)
        {
            TimeTemp += Time.deltaTime;
            if (TimeTemp >= SlideTemp)
            {
                Slide = false;
            }
        }


        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, WhatIsGround);
        Anime.SetBool("Jump", !grounded);
        Anime.SetBool("Slide", Slide);
        if (Slide)
        {
            boxColider.size = new Vector2(0.55f, 0.41f);
            boxColider.offset = new Vector2(0, 0.34f);
        }
        else
        {
            boxColider.size = new Vector2(0.55f, 0.64f);
            boxColider.offset = new Vector2(0, 0.43f);
        }
    }
}
