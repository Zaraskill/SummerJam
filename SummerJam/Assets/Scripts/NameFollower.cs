using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameFollower : MonoBehaviour
{

    public float speed;

    private bool isActive = false;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);
        }        
    }

    public void FollowTarget(GameObject target)
    {
        this.target = target;
        isActive = true;
    }

    public void UnFollowTarget()
    {
        isActive = false;
        Destroy(this.gameObject);
    }
}
