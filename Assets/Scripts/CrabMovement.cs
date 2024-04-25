using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    // Use this script as a base for making your new scripts for game functions

    // Start is called before the first frame update
    public int moveSpeed = 5;
    bool goLeft;   // flag for the direction crab is currently travelling 
    Vector3 dir;  // direction to travel
    
    // far left: x = -905, far right: x = -886

    void Start()
    {
        System.Random rnd = new System.Random();
        // place it at start position, at random x point between -886 and -905

        int startingX = rnd.Next(-886, -905);
        transform.position = new Vector3(startingX, transform.position.y, 0);

       // if (rnd.Next(0, 2) == 1)    // generate random num between 0 and 1
      //  {
            dir = Vector3.right;
      //  }
      //  else
     //   {
       //     dir = Vector3.left;
    //    }

      //  print("goLeft value: " + goLeft.ToString());
    }

    void Update()
    {
        transform.Translate(dir * Time.deltaTime * moveSpeed);

        if (transform.position.x <= -905)
        {
            dir = Vector3.left;
        }
        else if (transform.position.x >= -886)
        {
            dir = Vector3.right;
        }

    }
}
