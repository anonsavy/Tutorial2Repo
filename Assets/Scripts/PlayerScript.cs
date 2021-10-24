using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
private Rigidbody2D rd2d;
private bool facingRight = true;
public AudioSource musicSource; 
public AudioClip musicClip; 
public AudioClip sfxClip; 
public float speed;
Animator anim; 

public GameObject Player; 


public Text score;
public Text win; 
public Text life; 
private int scoreValue = 0;
private int lifeValue = 3; 

// Start is called before the first frame update
void Start()
{
rd2d = GetComponent<Rigidbody2D>();
score.text = scoreValue.ToString();
musicSource.clip = musicClip;
musicSource.Play(); 
anim = GetComponent<Animator>(); 

life.text = lifeValue.ToString(); 

win.text = "";
life.text = "3";

}

void Update() 
{
    if (Input.GetKeyDown(KeyCode.D))
{
    anim.SetInteger("State", 1);
}

if (Input.GetKeyDown(KeyCode.A))
{
    anim.SetInteger("State", 1);
}

if (Input.GetKeyUp(KeyCode.D))
{
    anim.SetInteger("State", 0);
}

if (Input.GetKeyUp(KeyCode.A))
{
    anim.SetInteger("State", 0);
}

if (Input.GetKeyDown(KeyCode.D))
{
    anim.SetInteger("State", 1);
}

if (Input.GetKeyDown(KeyCode.W))
{
    anim.SetInteger("State", 2);
    
}


}

void Flip()
   {
     facingRight = !facingRight;
     Vector2 Scaler = transform.localScale;
     Scaler.x = Scaler.x * -1;
     transform.localScale = Scaler;
   }

// Update is called once per frame
void FixedUpdate()
{
float hozMovement = Input.GetAxis("Horizontal");
float vertMovement = Input.GetAxis("Vertical");
rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

if (facingRight == false && hozMovement > 0)
   {
     Flip();
   }
else if (facingRight == true && hozMovement < 0)
   {
     Flip();
   }

if (Input.GetKey("escape"))
{
Application.Quit();
}


}

private void OnCollisionEnter2D(Collision2D collision)
{
if (collision.collider.tag == "Coin")
{
scoreValue += 1;
score.text = scoreValue.ToString();
Destroy(collision.collider.gameObject);
}

if (collision.collider.tag == "Bad")
{
lifeValue = lifeValue - 1; 
life.text = lifeValue.ToString();
Destroy(collision.collider.gameObject);
}

if (scoreValue == 8)
{
    win.text = "You win.. Sam Vera";
    musicSource.clip = sfxClip; 
    musicSource.Play(); 
    scoreValue = scoreValue + 1; 
}

if (collision.collider.tag == "Ground")
    {
        anim.SetInteger("State", 0);
    }



if (lifeValue == 0)
{
    win.text = "You Lose";
}

if (scoreValue == 4)
{
   transform.position = new Vector3(47.0f, 0.0f);
}

if (lifeValue == 0)
        {
            Player.gameObject.SetActive(false); 
        }
        else
        {
             Player.gameObject.SetActive(true); 
        }

}


private void OnCollisionStay2D(Collision2D collision)
{
if (collision.collider.tag == "Ground")
{
if (Input.GetKey(KeyCode.W))
{
rd2d.AddForce(new Vector2(0, 2), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors. You can also create a public variable for it and then edit it in the inspector.
}
}
}
}