using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Transform targetTransform;
    public Rigidbody2D targetRb;
    [SerializeField] private float speed = 5f;

    private Vector3 moveDir;
    private bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void StartMoving(Vector3 dir)
    {
        moveDir = dir;
        isMoving = true;
    }

    public void StopMoving()
    {
        moveDir = Vector3.zero;
        isMoving = false;
    }

    private void Move()
    {
        //targetTransform.position += new Vector3(moveDir.x, moveDir.y, 0) * speed * Time.deltaTime;
        targetRb.linearVelocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }
}
