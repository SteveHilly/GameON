using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds; // array for all the sounds

    public static AudioManager instance;

	// Use this for initialization
	void Awake () {
        // when there is no audiomanager in the scene, add the current instance to the scene
        if (instance == null)
            instance = this;
        // destroy the unwanted audiomanager if its duplicated
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // prevents sounds from cutting off when changing between scenes

		foreach (Sound s in sounds) // loop over each sound in the sounds array
        {
            // write all options to source
            s.source = gameObject.AddComponent<AudioSource>(); 
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}
	
	public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // find selected sound in the sounds array
        // exception prevention whenever a sound is not found (in case of typo)
        if (s == null)
            return;
        s.source.Play(); // play the selected sound
    }
}
