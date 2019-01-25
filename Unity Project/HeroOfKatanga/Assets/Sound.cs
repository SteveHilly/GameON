using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public string name; // used for naming the sound

    public AudioClip clip; // used for an audiofile

    [Range(0f, 1f)]
    public float volume; // volume of the sound
    [Range(.1f, 3f)]
    public float pitch; // pitch of the sound

    [HideInInspector]
    public AudioSource source;

    public bool loop; // used for option to loop

}
