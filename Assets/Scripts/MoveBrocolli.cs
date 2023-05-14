using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBrocolli : MonoBehaviour
{
    
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 movement;
    float speed;
    float increase;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomStartPosition();
        movement = RandomStartDirection();
        speed = 3f;
        increase = .01f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > maxX){
            movement.x = -1;
            speed += increase;
        }
        if(transform.position.x < minX){
            movement.x = 1;
            speed += increase;
        }
        if(transform.position.y > maxY){
            movement.y = -1;
            speed += increase;
        }
        if(transform.position.y < minY){
            movement.y = 1;
            speed += increase;
        }
        if(speed > 18){
            speed = 18;
        }
        transform.Translate(movement * speed * Time.deltaTime);
    }

    Vector2 RandomStartPosition(){
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(0, maxY);
        return new Vector2(randomX, randomY);
    }

    Vector2 RandomStartDirection(){
        float x = 1f;
        float y = 1f;
        if(Random.Range(0, 2) == 0){
            x = -x;
        }
        if(Random.Range(0, 2) == 0){
            y = -y;
        }
        return new Vector2(x, y);
    }
}
