using System;
using UnityEngine;
using UnityEngine.Tilemaps;

class TilePlacer : MonoBehaviour
{
    public GameObject KeyboardNoteSpace { get; private set; }
    public GameObject MouseNoteSpace { get; private set; }

    private NoteKind _currentNote;
    
    /// <summary>
    /// Places or removes the note on the tile grid.
    /// </summary>
    /// <param name="position">Input position. Should be global position, not grid index.</param>
    /// <param name="placeMode">Place mode. By default it is set to be Place, but I recommend to give argument explicitly</param>
    /// <returns>true if placement is successfully performed; false if not</returns>
    /// <exception cref="NotImplementedException">This method is not fully implemented yet. So calling this method will throw NotImplementedException.</exception>
    public bool SetNotes(Vector3 position, PlaceMode? placeMode)
    {
        // Default Mode: Place
        placeMode ??= PlaceMode.Place;
        
        // Initializing Area
        var grid = GetComponent<Grid>();
        var cellPosition = grid.WorldToCell(position);
        var currentNoteSpace = _currentNote.Group switch
        {
            NoteGroup.Keyboard => KeyboardNoteSpace,
            NoteGroup.Mouse => MouseNoteSpace,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        // Determines if there is other notes at the chosen position.
        var existingTile = currentNoteSpace.GetComponent<Tilemap>().GetTile<Tile>(cellPosition);

        // Gets currently selected note.

        throw new NotImplementedException("This feature is not implemented yet.");
    }

    /// <summary>
    /// Moves the note on the tile grid.
    /// </summary>
    /// <param name="srcPos">Source position. Should be grid index.</param>
    /// <param name="destPos">Destination position. Should be grid index.</param>
    /// <returns>true if movement is successfully performed; false if not</returns>
    /// <exception cref="NotImplementedException">This method is not fully implemented yet.</exception>
    public bool MoveNotes(Vector3Int srcPos, Vector3Int destPos)
    {
        throw new NotImplementedException("This feature is not implemented yet.");
    }

    /// <summary>
    /// Zooms the tile grid.
    /// </summary>
    /// <param name="multiplier">Zoom multiplier. Should be positive number.</param>
    /// <returns>true if zoom is successfully performed; false if not</returns>
    [Obsolete("May not be used")]
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