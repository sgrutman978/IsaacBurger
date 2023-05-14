using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBurger : MonoBehaviour
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomStartPosition();
        gameObject.GetComponent<Renderer>().enabled = false;
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 RandomStartPosition(){
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    IEnumerator ExampleCoroutine()
    {
        float rand = Random.Range(1, 7);
        float rand2 = Random.Range(1, 7);
        transform.position = RandomStartPosition();
        yield return new WaitForSeconds(rand);
        gameObject.GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(rand2);
        gameObject.GetComponent<Renderer>().enabled = false;
        StartCoroutine(ExampleCoroutine());

    }
}
