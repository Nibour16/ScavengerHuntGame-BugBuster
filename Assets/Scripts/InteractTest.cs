using UnityEngine;

public class InteractTest : UserInteraction
{
    protected override void Update()
    {
        if (Input.GetMouseButtonDown(0))    //if press left mouse button
            Act();
    }

    private void Act()
    {
        // Create a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if the ray hits an object with a collider
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            Interact(hit);
    }
}
