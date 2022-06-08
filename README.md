# Programing Theory Mission
 
![image](https://user-images.githubusercontent.com/40847844/172690918-ee809a07-ce10-4cd7-b9f7-af70a3f22f2e.png)

- ## A link to the github showing multiple commits with messages and **at least two branches**
I ended up not remembering that I had to do branches and commit messages cause I didn't continue working on the project for like 3 days and forgot what I had to do, + I didn't even went to the mission to see what the mission was asking for :p.
![image](https://user-images.githubusercontent.com/40847844/172508221-89a5e8a9-3164-405e-86d3-3348feb1add7.png)
but I did make a branch to edit this readme file so that I didn't show like a bunch of commits on the main branch.
 
.. I took some time for me to realize that you can preview what you changed in github without having to save... but yeah, I could've just done that

![image](https://user-images.githubusercontent.com/40847844/172696495-62700031-9b72-4715-a486-e91745a814bf.png)


- ## Demonstration of inheritance
The project I made consisted of a player and 3 boxes that the player could spawn and use to traverse the map. I didn't realy think much about what to do to demonstrate inheritance, so I just made a box class and used it on all of the boxes 
![image](https://user-images.githubusercontent.com/40847844/172512424-c77cc2b1-b4df-42a0-b329-57a944bc256f.png)

- the normal box has the box.cs script atached to it
- the floaty box use the floatBox.cs wich is a child class of the box.cs 
- and the last one use the PlatformBox.cs, also a child class.

But the only thing I could come up with for these 3 boxes was that the parent class gets destroyed when it falls off the map so the child classes should also have the same behaviour.
 
[Box.cs](https://github.com/HENRI067/Programing-Theory/blob/main/Assets/Scripts/Box.cs)
```
public class Box : MonoBehaviour
{    
    private void Update() 
    {
        BoxUpdate();
    }
    protected void BoxUpdate()
    {
        if (transform.position.y < -50f) Destroy(this.gameObject);
    }
}

```
 [FloatBox.cs](https://github.com/HENRI067/Programing-Theory/blob/main/Assets/Scripts/floatBox.cs)
```
public class floatBox : Box
{
    [...]
     
    private IEnumerator Start()
    {
        [...] 
    }

    private void Update()
    {
        BoxUpdate();
        
        [...]
    }

}
```
yeah not the best example of inheritance but at least I learned how to do it(i think)._.

- ## Demonstration of polymorphism
I didn't find any ideas to show polymorphism in this ._.

 - ## Demonstration of encapsulation
I didn't find any place to use stuff like protected variables or { get; private set; } in my project, but there's probaly a few places in my codes that I could have showed more examples of encapsulation. I don't know if this counts as encapsulating code but on the [Movement.cs](https://github.com/HENRI067/Programing-Theory/blob/main/Assets/Scripts/Movement.cs) script I made I used a Header to better organize the variables on the inspector window and in the code itself.
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField] private float speed = 9f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private LayerMask jumplayermask;
    [SerializeField] private float downForce;
    [SerializeField] private float mouseSensitivity = 100f;
    private float camRotation;
    private float _speed;

    [Header("Components")]
    [SerializeField] private Camera Camera;
    [SerializeField] private Rigidbody Rigidbody;
    

[...]
```

- ## Demonstration of abstraction
I think I don't have any problem making abstract code, on the same script I mentioned above I made some methods that made it easy for me to create the movement I wanted
```
public class Movement : MonoBehaviour
{
    [...]
    
    private void Update()
    {
    
    
    
        //WASD
        Vector3 keyboardInput = GetInput("Keyboard");
        Rigidbody.velocity = new Vector3(speed * keyboardInput.x, Rigidbody.velocity.y, speed * keyboardInput.z);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        if (Rigidbody.velocity.y < 0 && Rigidbody.velocity.y > -4f && IsGrounded() == false) Rigidbody.AddForce(Vector3.down * downForce,ForceMode.Acceleration);

        //Mouse
        Vector2 mouseInput = GetInput("Mouse");
        transform.Rotate(Vector3.up * mouseInput.x);
        camRotation -= mouseInput.y; camRotation = Mathf.Clamp(camRotation, -85, 85);
        Camera.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);
    }

    //checks to see if there is a colider below the player     //ABSTRACTION
    public bool IsGrounded()
    {
        bool isGrounded = true;
        if (Physics.Raycast(transform.position + new Vector3(0.4f, 1, 0), Vector3.down, 1.1f) ||
            Physics.Raycast(transform.position + new Vector3(-0.4f, 1, 0), Vector3.down, 1.1f) ||
            Physics.Raycast(transform.position + new Vector3(0, 1, 0.4f), Vector3.down, 1.1f) ||
            Physics.Raycast(transform.position + new Vector3(0, 1, -0.4f), Vector3.down, 1.1f))
        {
            isGrounded = true;
        }
        else
        { isGrounded = false; }

        return isGrounded;
    }

    //Get "Keyboard" or "Mouse" Input                      //ABSTRACTION
    private Vector3 GetInput(string input)
    {
        Vector3 playerInput = new Vector3(0, 0, 0);
        _speed = speed;
        switch (input)
        {
            case "Keyboard":
                float keybH = Input.GetAxisRaw("Horizontal");
                float keybV = Input.GetAxisRaw("Vertical");
                playerInput = (keybH * transform.right + keybV * transform.forward).normalized;
                break;

            case "Mouse":
                float mousX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                float mousY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                playerInput = new Vector3(mousX, mousY, 0);
                break;

            default:
                Debug.LogError("The only valid strings for this methods are Mouse & Keyboard");
                break;
        }
        return playerInput;
    }


```
but apart from this script all of the other ones have a bunch of repetitive lines on them that I could have improved but decided not to cause I was taking too much time to finish this mission.
 
