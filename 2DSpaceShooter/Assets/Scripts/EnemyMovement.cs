using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int speed=5;
    private bool down = true;
    private int movement = 1;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DirectionChanger());
        
    }


    IEnumerator DirectionChanger()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(0.5f);
            if (down)
            {
                down = false;
                movement = -1;
            }
            else
            {
                down = true;
                movement = 1;
            }
          
        }
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log("hussain");
        transform.Translate(Vector2.down * speed * Time.deltaTime *movement);
    }
}
