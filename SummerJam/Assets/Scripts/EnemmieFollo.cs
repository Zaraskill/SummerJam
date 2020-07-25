using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemmieFollo : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float scale;

    private void Start()
    {
        scale = Random.Range(3, 6);
        transform.localScale = new Vector3(scale, scale, 1);
        if (rb != null) return;
            rb = this.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }
}
