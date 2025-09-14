using UnityEngine;
using UnityEngine.InputSystem; // Add this for the new Input System

public class Basket : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Use the new Input System to get mouse position
        Vector3 mousePos2D = Mouse.current.position.ReadValue();

        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert to 3D world position
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {   
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
        }
    }
}
