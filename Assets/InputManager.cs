using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector += Vector2.right;
        }

        OnMove?.Invoke(inputVector);
        //Send this unity event (OnMove) which is taking the Vector2 inputVector to every frame
        //It "Invokes" this
        //The ? in front of OnMove assures that there is a listener component for the event, if not the compiler will create one
        //Forget the ? and you'll get a Null Reference Exception
    }
}
