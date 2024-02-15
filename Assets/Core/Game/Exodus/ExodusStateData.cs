using UnityEngine;

namespace Core.Game.Exodus {
    [System.Serializable]
    public class ExodusStateData {
        public ExodusID id;
        public AudioClip jingle;
        public string title;
        
        [TextArea] public string message;
        public Color messageColor = Color.white;
    }
}