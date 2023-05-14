using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    bool moveAllowed2;
    Collider2D col;
    Vector2 touchPosition;
    public Text scoreLabel;
    int score;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        moveAllowed = false;
        InvokeRepeating("Timer", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0)){
            // touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // if(transform.position.y)
             Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
            if(col == touchedCollider){
                moveAllowed = true;
            }
        }
        float posx = touchPosition.x;
        float posy = touchPosition.y;
        moveAllowed2 = true;
        if(touchPosition.x > maxX){
            // moveAllowed2 = false;
            posx = maxX;
        }
        if(touchPosition.x < minX){
            // moveAllowed2 = false;
            posx = minX;
        }
        if(touchPosition.y > maxY){
            // moveAllowed2 = false;
            posy = maxY;
        }
        if(touchPosition.y < minY){
            // moveAllowed2 = false;
            posy = minY;
        }
        if(Input.GetMouseButton(0) && moveAllowed && moveAllowed2){
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(posx, posy);
        }else{
            moveAllowed2 = true;
        }
        if(Input.GetMouseButtonUp(0)){
            moveAllowed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Broccoli"){
            SceneManager.LoadScene("menuScene"); //SceneManager.GetActiveScene().buildIndex + 1
        }
        if(collision.tag == "Burger"){
            score += 5;
            scoreLabel.text = score.ToString();
            collision.GetComponent<Renderer>().enabled = false;
        }
    }

    private void Timer(){
        score += 1;
        scoreLabel.text = score.ToString();
    }
}

        // if(Input.touchCount > 0){
        //     Touch touch = Input.GetTouch(0);
        //     Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //     if(touch.phase == TouchPhase.Began){
        //         Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
        //         if(col == touchedCollider){
        //             moveAllowed = true;
        //         }
        //     }
        //     if(touch.phase == TouchPhase.Moved){
        //         if(moveAllowed){
        //             transform.position = new Vector2(touchPosition.x, touchPosition.y);
        //         }
        //     }
        //     if(touch.phase == TouchPhase.Ended){
        //         moveAllowed = false;
        //     }
        // }

    

