using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;
    public float slowDownFactor = 1f;
    public bool hasPickedUpObject = false; // Flag for pickup status
    public bool canMove = false; // New flag to control movement

    public GameObject wallToDeactivate; // Reference to the wall GameObject

    void Update()
    {
        if (canMove) // Only allow movement if canMove is true
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * slowDownFactor * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, moveAmount, 0);
        }
    }

    public void DeactivateWall()
    {
        if (wallToDeactivate != null)
        {
            wallToDeactivate.SetActive(false); // Deactivate the wall
        }
    }

    // Call this method to enable the car's movement
    public void EnableMovement()
    {
        canMove = true;
    }

    // Call this method to disable the car's movement
    public void DisableMovement()
    {
        canMove = false;
    }
}



