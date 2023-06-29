using System;
using UnityEngine;

namespace EasyAudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public Sound[] sounds;

        public static Action<string> PlayAudio;
        public static Action<string> StopAudio;
        public static Action<string> StopAllAudioWithTag;
        public static Action StopAllAudio;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            //DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }

            // Play soundtrack
            Play(Array.Find(sounds, sound => sound.name == "Soundtrack").name);
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }

        public void Stop(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Stop();
        }

        public void StopAll()
        {
            foreach (Sound s in sounds)
            {
                s.source.Stop();
            }
        }

        public void StopAllWithTag(string tag)
        {
            foreach (Sound s in sounds)
            {
                if (s.tag == tag)
                {
                    s.source.Stop();
                }
            }
        }

        private void OnEnable()
        {
            PlayAudio += Play;
            StopAudio += Stop;
            StopAllAudio += StopAll;
            StopAllAudioWithTag += StopAllWithTag;
        }
        private void OnDisable()
        {
            PlayAudio -= Play;
            StopAudio -= Stop;
            StopAllAudio -= StopAll;
            StopAllAudioWithTag -= StopAllWithTag;
        }
    }
}