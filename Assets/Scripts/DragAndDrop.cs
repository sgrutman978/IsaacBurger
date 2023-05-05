using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col;
    Vector2 touchPosition;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        moveAllowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // if(transform.position.y)
             Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
            if(col == touchedCollider){
                moveAllowed = true;
            }
            
        }
        if(Input.GetMouseButton(0) && moveAllowed){
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(touchPosition.x, touchPosition.y);
        }
        if(Input.GetMouseButtonUp(0)){
            moveAllowed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Broccoli"){
            SceneManager.LoadScene("menuScene"); //SceneManager.GetActiveScene().buildIndex + 1
        }
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

    

