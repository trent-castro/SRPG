using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    [Header("Debug Mode")]
    [SerializeField]
    [Tooltip("Enables Debug Mode.")]
    private bool m_debugMode = false;

    [Header("Configuration")]
    [Tooltip("The speed at which the cursor approaches it's new location")]
    [SerializeField] [Range(0.0f, 1.0f)]
    private float cursorMovementSpeed = 0.01f;

    // Private internal data members
    /// <summary>
    /// A vector2 describing the current location on the grid that the cursor is at.
    /// </summary>
    private Vector2 m_tilePosition = Vector2.zero;
    
    /// <summary>
    /// [DEBUG MODE] Records a message if debug mode is enabled.
    /// </summary>
    /// <param name="debugLog">The message to record</param>
    private void DebugLog(string debugLog)
    {
        if (m_debugMode)
        {
            Debug.Log(debugLog);
        }
    }

    private void DebugPositions()
    {
        DebugLog("Current Actual Position: [" + transform.position.ToString() + "].");
        DebugLog("Current Tile Position: [" + m_tilePosition.ToString() + "].");
    }

    // Update is called once per frame
    void Update()
    {
        DebugPositions();
        HandleKeyboardInput();
        HandleVisualMovement();
    }

    private void HandleKeyboardInput()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            m_tilePosition.y += 1;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            m_tilePosition.y -= 1;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            m_tilePosition.x -= 1;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            m_tilePosition.x += 1;
        }
    }

    private void HandleVisualMovement()
    {
        Vector2 currentPosition = new Vector2(Mathf.Abs(transform.position.x / GlobalInformation.TileDistance),
            Mathf.Abs(transform.position.z / GlobalInformation.TileDistance));
        if(currentPosition != m_tilePosition)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(m_tilePosition.x * GlobalInformation.TileDistance,
                GlobalInformation.CursorHeightOffset, m_tilePosition.y * GlobalInformation.TileDistance), cursorMovementSpeed);
        }
    }
}
