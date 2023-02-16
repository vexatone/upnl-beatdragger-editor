using System;
using UnityEngine;

class TilePlacer : MonoBehaviour
{
    private NoteGroup _currentNote;
    private GameObject _notePreview;
    
    [SerializeField] private GameObject normalNotePrefab;
    [SerializeField] private GameObject critNotePrefab;
    [SerializeField] private GameObject flickNotePrefab;
    [SerializeField] private GameObject holdNotePrefab;
    [SerializeField] private GameObject dragNotePrefab;
    [SerializeField] private GameObject damageNotePrefab;

    [SerializeField] private SnapData snapDataContainer;

    public void PreviewNewNotes(Vector3 position)
    {
        var snappedX = HorizontalSnap(position.x, SnapMode.Note);
        if (!snappedX.HasValue)
        {
            Destroy(_notePreview);
            return;
        }

        if (_notePreview != null)
        {
            _notePreview.transform.position = new Vector3(snappedX.Value, position.y);
        }
        else
        {
            _notePreview = Instantiate(_currentNote switch
            {
                NoteGroup.Normal => normalNotePrefab,
                NoteGroup.Crit => critNotePrefab,
                NoteGroup.Flick => flickNotePrefab,
                NoteGroup.Hold => holdNotePrefab,
                NoteGroup.Drag => dragNotePrefab,
                NoteGroup.Damage => damageNotePrefab,
                _ => throw new ArgumentOutOfRangeException()
            }, new Vector3(snappedX.Value, position.y), Quaternion.identity);
            var noteColor = _notePreview.GetComponent<SpriteRenderer>().color;
            _notePreview.GetComponent<SpriteRenderer>().color = new Color(noteColor.r, noteColor.g, noteColor.b, 0.3f);
        }
    }

    public void DestroyPreviews()
    {
        Destroy(_notePreview);
    }
    
    /// <summary>
    /// Set notes at the given position. Note that the given position is automatically snapped in this function.
    /// </summary>
    /// <param name="position">Raw position where the note will be placed.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the current selected note is null or unknown type.</exception>
    public void SetNotes(Vector3 position)
    {
        // TODO: Convert position into timing
        // TODO: Create a note in the selected position
        // TODO: Register a data of note on LoadedNotesData
        
        // Temporary code: for prototype
        var snappedX = HorizontalSnap(position.x, SnapMode.Note);
        if (!snappedX.HasValue) return;

        // TODO: Edit Y position parameter after implementing vertical snap
        var notePosition = new Vector3(snappedX.Value, position.y);
        Instantiate(_currentNote switch
        {
            NoteGroup.Normal => normalNotePrefab,
            NoteGroup.Crit => critNotePrefab,
            NoteGroup.Flick => flickNotePrefab,
            NoteGroup.Hold => holdNotePrefab,
            NoteGroup.Drag => dragNotePrefab,
            NoteGroup.Damage => damageNotePrefab,
            _ => throw new ArgumentOutOfRangeException()
        }, notePosition, Quaternion.identity);
    }

    public void RemoveNotes(Vector3 position)
    {
        // TODO: Find a note with position
        // TODO: Get a note object and destroy it
        // TODO: Remove a corresponding data from LoadedNotesData
    }

    public void Zoom(float multiplier)
    {
        
    }

    /// <summary>
    /// Converts given horizontal position into snapped horizontal position following by Snap Mode.
    /// </summary>
    /// <param name="hPos">Raw Horizontal Position in float.</param>
    /// <param name="snapMode">Snap mode. Choose one between Border-oriented or Note-oriented.</param>
    /// <returns>Snapped position if the given horizontal position is in valid area. Null if not.</returns>
    private float? HorizontalSnap(float hPos, SnapMode snapMode)
    {
        if (snapMode == SnapMode.Border)
        {
            foreach (float pivot in snapDataContainer.borderPosData)
            {
                if (Math.Abs(hPos - pivot) <= 0.4f) return pivot;
            }

            return null;
        }
        else
        {
            foreach (float pivot in snapDataContainer.notePosData)
            {
                if (Math.Abs(hPos - pivot) <= 0.4f) return pivot;
            }

            return null;
        }
    }

    private float VerticalSnap(float vPos)
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        _currentNote = NoteGroup.Normal;
    }
}