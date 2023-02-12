using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data Containers/Loaded Notes Data",fileName="LoadedNotesData",order=1)]
class LoadedNotesData : ScriptableObject
{
    [Serializable]
    public class NoteData
    {
        public NoteGroup type;
        public float timing;
        public int holdGroup;
        public bool isHoldEnd;
    }
    
    public List<NoteData> notes;
}