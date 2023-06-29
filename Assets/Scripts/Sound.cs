using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EasyAudioSystem
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;
        [Range(0.1f, 3f)]
        public float pitch;
        public bool loop;
        [Space]
        public string tag;

        [HideInInspector]
        public AudioSource source;
    }
}