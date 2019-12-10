using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SFXGroup", menuName = "Sound/SFX Group")]
public class SFXGroup : ScriptableObject
{
    [System.Serializable]
    public class SFXGroupItem
    {
        public string name;
        public AudioClip audioClip;
    }

    public List<SFXGroupItem> clips = new List<SFXGroupItem>();

    public AudioClip GetClip(string name)
    {
        return clips.FirstOrDefault(x => x.name.ToLower() == name.ToLower())?.audioClip;
    }
}
