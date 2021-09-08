using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private CircleCollider2D myCollider;
    private ContactPoint2D[] contactPoints;
    private Collider2D mycollision;

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CircleCollider2D>();
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionStay2D(Collision2D target)
    {
        if(GameController.instance.gamemode == false)
        {
            //Debug.Log(target.contacts.Length);
            if (target.gameObject == CircleFormation.instance.circlemain[CircleFormation.instance.i] && target.contacts.Length >= 1)
            {
                if (CircleFormation.instance.touch.phase != TouchPhase.Ended)
                {
                    CircleFormation.instance.flag1 = 2;
                    CircleFormation.instance.touch.phase = TouchPhase.Ended;
                }
            }
        }

        if (GameController.instance.gamemode == true)
        {
            if (target.gameObject == LevelPlayController.instance.circlemain[LevelPlayController.instance.j] && target.contacts.Length >= 1)
            {
                if (LevelPlayController.instance.touch.phase != TouchPhase.Ended)
                {
                    LevelPlayController.instance.flag1 = 2;
                    LevelPlayController.instance.touch.phase = TouchPhase.Ended;
                }
            }
        }
    }

}
