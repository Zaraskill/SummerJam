using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiniJeu2 : MonoBehaviour
{
    private Vector3 mouseInScreen;

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
    }
}
