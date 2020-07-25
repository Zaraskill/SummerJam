using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMiniJeu2 : MonoBehaviour
{
    private Vector3 mouseInScreen;
    private bool isLock = false;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mouseInScreen = Input.mousePosition;
        mouseInScreen.z = 10;
        Vector3 mousPos = Camera.main.ScreenToWorldPoint(mouseInScreen);
        transform.position = mousPos;

        WaitUnlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetCursorLock();
    }

    private void WaitUnlock()
    {
        if (isLock)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SetCursorUnLock();
            }
        }
    }

    public void SetCursorLock()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        timer = .1f;
        isLock = true;
    }

    public void SetCursorUnLock()
    {
        Cursor.lockState = CursorLockMode.None;
        isLock = false;
    }
}
