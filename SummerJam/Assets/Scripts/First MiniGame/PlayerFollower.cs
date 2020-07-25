using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFollower : MonoBehaviour
{
    public float speedMax;
    public float speedSlow;
    private float speedPlay;
    private Vector3 mouseInScreen;    
    
    // Start is called before the first frame update
    void Start()
    {
        speedPlay = speedMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstMiniGameManager.canStart)
        {
            mouseInScreen = Input.mousePosition;
            mouseInScreen.z = 10;
            Vector3 mousPos = Camera.main.ScreenToWorldPoint(mouseInScreen);

            Vector3 direction = mousPos - transform.position;

            transform.position = Vector3.Lerp(transform.position, mousPos, Time.deltaTime * speedPlay);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            speedPlay = speedSlow;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            speedPlay = speedMax;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Text")
        {
            FirstMiniGameManager.instance.GetName(collision.gameObject);
        }
    }
}
