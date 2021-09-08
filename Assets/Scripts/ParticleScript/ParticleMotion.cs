using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMotion : MonoBehaviour {

    public static ParticleMotion instance;
    public Rigidbody2D myRigidbody2D;
    public CircleCollider2D myCircleCollider;
    public float velX, velY;
    public int flag1=0;

    void Awake () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();

        if (instance == null)
            instance = this;

        float randomX = Random.Range(-1,1);

        if (randomX >= 0)
            velX = Random.Range(0.5f, 1);
        else
            velX = Random.Range(-1, -0.5f);

        float randomY = Random.Range(-1, 1);

        if (randomY >= 0)
            velY = Random.Range(0.5f,1);
        else
            velY = Random.Range(-1, -0.5f);
    }

    void Start()
    {
       
    }

    void FixedUpdate () {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        float forceX = 0, forceY = 0;
        float speedX = Mathf.Abs(myRigidbody2D.velocity.x);
        float speedY = Mathf.Abs(myRigidbody2D.velocity.y);

        if(speedX == 0 || speedY == 0)
        {
            float randomX = Random.Range(-1, 1);

            if (randomX >= 0)
                velX = Random.Range(0.5f, 1);
            else
                velX = Random.Range(-1, -0.5f);

            float randomY = Random.Range(-1, 1);

            if (randomY >= 0)
                velY = Random.Range(0.5f, 1);
            else
                velY = Random.Range(-1, -0.5f);

            forceX = velX;
            forceY = velY;
        }

        if(speedX <= 1)
        {
            forceX = velX;
        }

        if (speedY <= 1)
        {
            forceY = velY;
        }
        
        if(speedX >= 7.0f || speedY >= 7.0f)
        {
            Vector3 temp = myRigidbody2D.velocity;
            temp.x = velX;
            temp.y = velY;
            myRigidbody2D.velocity = temp;
        }

        myRigidbody2D.AddForce(new Vector2(Mathf.Min(forceX,1.5f), Mathf.Min(forceY,1.5f)));
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "horizontalcolliders")
            velY = -velY;

        if (target.gameObject.tag == "verticalcolliders")
            velX = -velX;

        if(GameController.instance.gamemode == false)
        {
            if (target.gameObject == CircleFormation.instance.circlemain[CircleFormation.instance.i])
            {
                if (CircleFormation.instance.touch.phase != TouchPhase.Ended)
                {
                    CircleFormation.instance.flag = 1;
                    target.gameObject.SetActive(false);
                    CircleFormation.instance.currarea = 0;
                    CircleFormation.instance.touch.phase = TouchPhase.Ended;
                }
            }
        }

        if (GameController.instance.gamemode == true)
        {
            if (target.gameObject == LevelPlayController.instance.circlemain[LevelPlayController.instance.j])
            {
                if (LevelPlayController.instance.touch.phase != TouchPhase.Ended)
                {
                    LevelPlayController.instance.flag = 1;
                    target.gameObject.SetActive(false);
                    LevelPlayController.instance.currarea = 0;
                    LevelPlayController.instance.touch.phase = TouchPhase.Ended;
                }
            }
        }
        
    }



}
