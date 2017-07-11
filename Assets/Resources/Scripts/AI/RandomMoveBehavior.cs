using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveBehavior : MonoBehaviour
{

    public float speed;
    public float moveRange;

    private Vector2 target;
    private Rigidbody2D rBody;
    private Vector2 moveCircleVector;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ChooseTarget();
    }

    // Update is called once per frame
    void Update()
    {
        float timeStep = Time.deltaTime * speed;
        rBody.velocity = moveCircleVector * timeStep;

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            ChooseTarget();
        }
    }

    private void ChooseTarget()
    {
        target = (Random.insideUnitCircle * moveRange) + (Vector2)transform.position;
        Vector2 direction = target - (Vector2)transform.position;
        moveCircleVector = Vector2.ClampMagnitude(direction, 1);
    }
}
