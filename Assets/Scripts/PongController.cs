using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{
    private Rigidbody2D myRG;
    private int variable;
    private SpriteRenderer mySR;
    // Start is called before the first frame update
    void Start()
    {
        myRG = transform.GetChild(0).GetComponent<Rigidbody2D>();
        mySR = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mySR.color = Color.grey;
            myRG.velocity = new Vector2(0f, 0f);
            myRG = (myRG == transform.GetChild(0).GetComponent<Rigidbody2D>() ? transform.GetChild(1).GetComponent<Rigidbody2D>() : transform.GetChild(0).GetComponent<Rigidbody2D>());
            mySR = (mySR == transform.GetChild(0).GetComponent<SpriteRenderer>() ? transform.GetChild(1).GetComponent<SpriteRenderer>() : transform.GetChild(0).GetComponent<SpriteRenderer>());
            mySR.color = Color.white;
        }
        myRG.velocity = new Vector2(0f, ((Input.GetKey(KeyCode.W)) ? 10f : ((Input.GetKey(KeyCode.S) ? -10f : 0f))));

    }
    
    
}
