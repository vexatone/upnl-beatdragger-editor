public class NoteKind
{
    public NoteGroup Group { get; }
    public int ID { get; }

    public static readonly NoteKind Normal = new NoteKind(NoteGroup.Keyboard, 0);
    public static readonly NoteKind Crit = new NoteKind(NoteGroup.Mouse, 1);
    public static readonly NoteKind Hold = new NoteKind(NoteGroup.Keyboard, 2);
    public static readonly NoteKind Drag = new NoteKind(NoteGroup.Mouse, 3);
    public static readonly NoteKind Damage = new NoteKind(NoteGroup.Both, 4);
    
    private NoteKind(NoteGroup group, int id)
    {
        Group = group;
        ID = id;
    }

    // Some overrides
    public static explicit operator int(NoteKind noteKind) => noteKind.ID;
    public static bool operator ==(NoteKind noteKind1, NoteKind noteKind2) => noteKind1.ID == noteKind2.ID;
    public static bool operator !=(NoteKind noteKind1, NoteKind noteKind2) => noteKind1.ID != noteKind2.ID;

    public override int GetHashCode() => ID;
}