using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data Containers/Loaded Notes Data",fileName="LoadedNotesData",order=1)]
class LoadedNotesData : ScriptableObject
{
    [Serializable]
    public struct NoteData
    {
        public NoteGroup type;
        public float timing;
        public int leftEnd;
        public int rightEnd;
        public int holdGroup;
        public bool isHoldEnd;
        public bool isTimingChecked;
        public DragCurve dragCurveLeft;
        public DragCurve dragCurveRight;
    }
    
    public List<NoteData> notes;
}