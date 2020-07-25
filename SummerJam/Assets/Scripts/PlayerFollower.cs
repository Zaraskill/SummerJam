using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFollower : MonoBehaviour
{
    public float speed;
    public float timer;

    public TextMeshProUGUI textMesh;
    private Vector3 mouseInScreen;
    private float timerLeft;
    private bool isFollowed = false;
    private NameFollower follower;
    
    // Start is called before the first frame update
    void Start()
    {
        timerLeft = timer;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();

        mouseInScreen = Input.mousePosition;
        mouseInScreen.z = 10;
        Vector3 mousPos = Camera.main.ScreenToWorldPoint(mouseInScreen);

        Vector3 direction = mousPos - transform.position;

        transform.position = Vector3.Lerp(transform.position, mousPos, Time.deltaTime * speed);

    }

    private void UpdateTime()
    {
        timerLeft -= Time.deltaTime;
        textMesh.text = timerLeft.ToString("00.00");
        if(timerLeft <= 0f)
        {
            //END MINIGAME
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Text" && !isFollowed)
        {
            isFollowed = true;
            follower = collision.GetComponent<NameFollower>();
            follower.FollowTarget(this.gameObject);
        }
        else if(collision.tag == "Finish" && isFollowed)
        {
            isFollowed = false;
            follower.UnFollowTarget();

        }
    }
}
