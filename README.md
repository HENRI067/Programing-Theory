# Programing Theory
 
![mission](https://user-images.githubusercontent.com/40847844/172507040-a3324ebd-79be-4b84-a85b-9dacb94bb2f2.jpg)

- ## A link to the github showing multiple commits with messages and **at least two branches**
I ended up not remembering that I had to do branches and commit messages cause I didn't continue working on the project for like 3 days and forgot what I had to do, + I didn't even went to the mission to see what the mission was asking for :p.
![image](https://user-images.githubusercontent.com/40847844/172508221-89a5e8a9-3164-405e-86d3-3348feb1add7.png)

- ## Demonstration of abstraction
I think I don't have any problem making abstract code and I think the player movement script that I wrote show a little bit of abstraction that I made for the code to look nicer
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
        **Vector3 keyboardInput = GetInput("Keyboard");**
        Rigidbody.velocity = new Vector3(speed * keyboardInput.x, Rigidbody.velocity.y, speed * keyboardInput.z);
        
        [...]
        
        //Mouse
        **Vector2 mouseInput = GetInput("Mouse");**
        transform.Rotate(Vector3.up * mouseInput.x);
        camRotation -= mouseInput.y; camRotation = Mathf.Clamp(camRotation, -85, 85);
        Camera.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);
    }
```
