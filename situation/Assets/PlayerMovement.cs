using UnityEngine;
using System.Collections;

public class PlayerMovement : Photon.MonoBehaviour
{

    public float speed;
    public int health;
    public bool isAlive;
    public Transform attack_orb;
    public Transform Jasper;
    public Transform Jasper1;
    public Transform Jasper2;
    void start()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {


        if (coll.gameObject.name == "Jasper")
        {

            health--;
            transform.position = Vector2.MoveTowards(transform.position, Jasper.position, speed * -10f);
            if (health <= 0)
            {
                isAlive = false;
                health = -1;
            }

        }
        else if (coll.gameObject.name == "Jasper 1")
        {

            health--;
            transform.position = Vector2.MoveTowards(transform.position, Jasper1.position, speed * -10f);
            if (health <= 0)
            {
                isAlive = false;
                health = -1;
            }

        }
        else if (coll.gameObject.name == "Jasper 2")
        {

            health--;
            transform.position = Vector2.MoveTowards(transform.position, Jasper2.position, speed * -10f);
            if (health <= 0)
            {
                isAlive = false;
                health = -1;
            }

        }
        else if (coll.gameObject.name == "healthCube")
        {
            health++;
            if (health > 0)
            {
                isAlive = true;
            }
            if (health > 10)
            {
                health = 10;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (photonView.isMine)
        {
                inputMovement();
            
        
        }
    }


        void inputMovement(){


            if (Input.GetKeyDown("space"))
            {
                Instantiate(attack_orb, transform.position, transform.rotation);


            }

            if (Input.GetKey(KeyCode.D))
            {
                //			transform.Translate (Vector2.right * speed);
                if (isAlive == true)
                {
                    transform.Rotate(Vector3.forward * -4);
                }


            }

            if (Input.GetKey(KeyCode.A))
            {
                //			transform.Translate (Vector2.right * -speed);

                transform.Rotate(Vector3.forward * 4);

                //			if (transform.localScale.x != -1) {
                //				Vector3 temp = transform.localScale;
                //				temp.x = (transform.localScale.x * -1f);
                //				transform.localScale = temp;
                //				
                //			}
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * speed);

                //			if (transform.localScale.y != 1) {
                //				Vector3 temp = transform.localScale;
                //				temp.y = (transform.localScale.y * -1f);
                //				transform.localScale = temp;
                //
                //			}
            }

            if (Input.GetKey(KeyCode.S))
            {

                transform.Translate(Vector2.up * -speed);

                //			if (transform.localScale.y != -1) {
                //				Vector3 temp = transform.localScale;
                //				temp.y = (transform.localScale.y * -1f);
                //				transform.localScale = temp;
                //
                //			}

            }

         }

    }


