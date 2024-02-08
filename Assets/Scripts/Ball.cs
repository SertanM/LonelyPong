using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour
{
    private float speed = 3;
    private Rigidbody2D myRG;
    private SpriteRenderer mySR;
    public Text scoreText;
    private int score = -1;
    // Start is called before the first frame update
    void Start()
    {
        myRG = this.gameObject.GetComponent<Rigidbody2D>();
        mySR = this.gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(Launch());
    }

    private IEnumerator Launch()
    {
        yield return new WaitForSeconds(2.0f);
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        myRG.velocity = new Vector2(speed * x, speed * y);
    }

    private void OnCollisionEnter2D()
    {
        colorpicker();
    }


    private void colorpicker()
    {
            switch (Random.Range(0, 6))
            {
                case 0:
                    if (!(mySR.color == Color.magenta))
                    {
                        mySR.color = Color.magenta;
                    }
                    else
                    {
                    colorpicker();
                    }
                    break;
                case 1:
                    if(!(mySR.color == Color.green))
                    {
                    mySR.color = Color.green;
                    }
                    else
                    {
                    colorpicker();
                    }
                    break;
                case 2:
                    if(!(mySR.color == Color.yellow))
                    {
                        mySR.color = Color.yellow;
                    }
                    else
                    {
                    colorpicker();
                    }
                    break;
                case 3:
                    if(!(mySR.color == Color.red))
                    {
                    mySR.color = Color.red;
                    }
                    else
                    {
                        colorpicker();
                    }
                        
                    break;
                case 4:
                    if(!(mySR.color == Color.blue))
                    {
                    mySR.color = Color.blue;
                    }
                    else
                    {
                    colorpicker() ;
                    }
                    
                    break;
                case 5:
                    if(!(mySR.color == Color.white))
                    {
                    mySR.color = Color.white;
                    }
                    else
                    {
                    colorpicker();
                    }
                    break;
            }
        }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Score"))
        {
            score += 1;
            scoreText.text = score.ToString(); 
        }
        else if (col.CompareTag("Death"))
        {
            StartCoroutine(Death());
        }
    }
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1.0f);
        myRG.velocity = new Vector2(0, 0);
        mySR.color = Color.white;
        this.gameObject.transform.position = new Vector3(0f,0f, 0f);
        score = -1;
        scoreText.text = "0";
        StartCoroutine(Launch());
    }
}
