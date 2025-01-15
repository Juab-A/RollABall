using UnityEditor;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidbody;
    [SerializeField] private float ballSpeed = 2f;
    [SerializeField] private float jumpHeight = 2f;

    private float raycastDistance = 0.6f;
    [SerializeField] private LayerMask groundLayer;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Handled by the Input Manager now
        // Vector2 inputVector = Vector2.zero;
        // if (Input.GetKey(KeyCode.W)) {
        //     inputVector += Vector2.up;
        // }
        // if (Input.GetKey(KeyCode.S)) {
        //     inputVector += Vector2.down;
        // }
        // if (Input.GetKey(KeyCode.A)) {
        //     inputVector += Vector2.left;
        // }
        // if (Input.GetKey(KeyCode.D)) {
        //     inputVector += Vector2.right;
        // }

        if (Input.GetKey(KeyCode.Space) && IsGrounded()) {
            Debug.Log("Should Jump");
            sphereRigidbody.AddForce(Vector3.up * jumpHeight);
        }
        
    }

    public  bool IsGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer);
        //Raycast that returns if the raycast has hit a gameobject of the Ground layer
        //centered around the Sphere's position, looking straight down, using the RaycastHit, the distance of raycast, detecting ground layer
    }

    public void moveBall(Vector2 input) {
        Vector3 inputXZPlane = new Vector3(input.x, 0, input.y);
        sphereRigidbody.AddForce(inputXZPlane * ballSpeed);
    }
}
