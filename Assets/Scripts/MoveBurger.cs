using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBurger : MonoBehaviour
{
    
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 startPosition;
    Vector2 movement;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        maxX = -minX;
        maxY = -minY;
        transform.position = RandomStartPosition();
        movement = RandomStartDirection();
        speed = .005f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > maxX || transform.position.x < minX){
            movement.x = -movement.x;
        }
        if(transform.position.y > maxY || transform.position.y < minY){
            movement.y = -movement.y;
        }
        transform.Translate(movement * speed);
    }

    Vector2 RandomStartPosition(){
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
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
