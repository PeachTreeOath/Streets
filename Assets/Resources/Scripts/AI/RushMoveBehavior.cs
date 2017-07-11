using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushMoveBehavior : MonoBehaviour
{
    public float speed;

    private Transform target;
    private Rigidbody2D rBody;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            ChooseTarget();

            // Return if no targets found
            if (target == null) return;
        }

        float moveDistance = speed * Time.deltaTime;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, target.position, moveDistance);
        rBody.MovePosition(newPosition);
    }

    private void ChooseTarget()
    {
        target = AIDirector.instance.ChooseTarget(transform);
    }
}
