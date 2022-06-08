# Programing Theory
 
![image](https://user-images.githubusercontent.com/40847844/172690918-ee809a07-ce10-4cd7-b9f7-af70a3f22f2e.png)

- ## A link to the github showing multiple commits with messages and **at least two branches**
I ended up not remembering that I had to do branches and commit messages cause I didn't continue working on the project for like 3 days and forgot what I had to do, + I didn't even went to the mission to see what the mission was asking for :p.
![image](https://user-images.githubusercontent.com/40847844/172508221-89a5e8a9-3164-405e-86d3-3348feb1add7.png)

 ****
- ##Demonstration of abstraction
I think I don't have any problem making abstract code and I think the player movement script that I wrote show a little bit of abstraction that I made for the code to look nice
```
//Get "Keyboard" or "Mouse" Input
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
```
```
    private void Update()
    {



        //WASD
        Vector3 keyboardInput = GetInput("Keyboard"); //Same method for getting mouse and keyboard input
        Rigidbody.velocity = new Vector3(speed * keyboardInput.x, Rigidbody.velocity.y, speed * keyboardInput.z);
        
        [...]
        
        //Mouse
        Vector2 mouseInput = GetInput("Mouse"); //Same method for getting mouse and keyboard input
        transform.Rotate(Vector3.up * mouseInput.x);
        camRotation -= mouseInput.y; camRotation = Mathf.Clamp(camRotation, -85, 85);
        Camera.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);
    }
```
but apart from this script all of the other ones have a bunch of repetitive lines on them that I could have improved but decided not to cause I was taking too much time to finish this mission.

****
- ##Demonstration of inheritance
The project I made consisted of a player and 3 boxes that the player could spawn and use to traverse the map. I didn't realy think much about what to do to demonstrate inheritance, so I just made a box class and used it on all of the boxes 
![image](https://user-images.githubusercontent.com/40847844/172512424-c77cc2b1-b4df-42a0-b329-57a944bc256f.png)

-the normal box has the box.cs script atached to it
-the floaty box use the floatBox.cs wich is a child class of the box.cs 
-and the last one use the PlatformBox.cs, also a child class.
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
 
 - ## Demonstration of encapsulation
 
