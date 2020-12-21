using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CubeMovement : MonoBehaviour
{
    // [Range(0f, 10f)] // Make the "Force Multiplier" field into a slider from 0-10
    public float ForceMultiplier = 1f;
    public float Lift = 0f;
    public float MinY = -10f;
    public Vector3 RespawnPosition = new Vector3(0, 3, 0);
    
    private Rigidbody rb;
    
    /// <summary>
    /// OnMove handles a movement input event.
    /// </summary>
    /// <param name="ctx">Input event information.</param>
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return; // Only accept input at the *beginning* of the key press
        
        // Read the value associated with the input event
        // What type are we supposed to use? This is set in the input settings
        var force2d = ctx.ReadValue<Vector2>();
        
        // Translate from 2D vector (x, y) to 3D vector (x, 0, y)
        // In Unity, Y is up
        var force3d = new Vector3(force2d.x, Lift, force2d.y);

        PushCube(force3d);
    }

    
    /// <summary>
    /// Without any arguments, PushCube pushes the cube in a random direction.
    /// </summary>
    public void PushCube()
    {
        // TODO: Use "Random.value" to get a random float in range [0, 1]
    }
    
    /// <summary>
    /// PushCube pushes the cube with a given force.
    /// </summary>
    /// <param name="force">Force to apply.</param>
    public void PushCube(Vector3 force)
    {
        var actualForce = ForceMultiplier * force;
        Debug.Log($"Added force of {actualForce}");
        rb.AddForce(actualForce, ForceMode.Impulse);
    }
    
    public Vector3 GetActualForce(Vector3 force) => ForceMultiplier * force; // Shorthand for simple functions!

    #region Unity Event Functions
    
    void Start()
    {
        // Get the Rigidbody component on this GameObject
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate happens on a fixed interval, while Update varies with framerate
    void FixedUpdate()
    {
        if (transform.position.y < MinY)
        {
            transform.position = RespawnPosition;
        }
    }
    
    #endregion
}
