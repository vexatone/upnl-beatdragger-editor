using System;
using UnityEngine;

class TilePlacer : MonoBehaviour
{
    public GameObject KeyboardNoteSpace { get; private set; }
    public GameObject MouseNoteSpace { get; private set; }
    
    public bool SetNotes(int timing, int hPosition)
    {
        // TODO: Implement note setting logic.
        throw new NotImplementedException("This feature is not implemented yet.");
    }

    public bool RemoveNotes(int timing, int hPosition)
    {
        // TODO: Implement note removal logic.
        throw new NotImplementedException("This feature is not implemented yet.");
    }
    
    /// <summary>
    /// Zooms the tile grid.
    /// </summary>
    /// <param name="multiplier">Zoom multiplier. Should be positive number.</param>
    /// <returns>true if zoom is successfully performed; false if not</returns>
    public bool Zoom(float multiplier)
    {
        if (multiplier > 0)
        {
            var grid = GetComponentInParent<Grid>();
            var newSize = new Vector3(0.8f, 0.5f * multiplier, 0f);
            grid.cellSize = newSize;
            return true;
        }

        Debug.LogErrorFormat("Multiplier should be positive, but {0} is given.", multiplier);
        return false;
    }

    private void Start()
    {
        KeyboardNoteSpace = GameObject.FindGameObjectWithTag("KeyboardNote");
        MouseNoteSpace = GameObject.FindGameObjectWithTag("MouseNote");
    }
}