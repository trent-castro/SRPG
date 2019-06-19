using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that holds information about the world.
/// </summary>
public static class GlobalInformation
{
    /// <summary>
    /// A float describing the amount of length a cursor must traverse before it completely covers a new tile.
    /// </summary>
    public const float TileDistance = 10.0f;
    /// <summary>
    /// A float describing how offset the cursor is from the environment to prevent z-fighting.
    /// </summary>
    public const float CursorHeightOffset = 0.1f;
}
