using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false; 
    }

    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos; 
    }

    /* 
    private Vector2 target; // position player needs to move towards 

    void Update()
    {
        // Getting the coordinates of the mousePos in game  
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mousePos); 

        //Check if user left clicks, and if they do get coordiantes of where they clicked 
        if (Input.GetMouseButtonDown(0))  // 0 = left mouse index 
        {
            target = new Vector2(mousePos.x, transform.position.y);
            target = new Vector2(transform.position.x, mousePos.y);
        }

        // Move the player towards the target coordinates 
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 5f);
    }

    */
}
