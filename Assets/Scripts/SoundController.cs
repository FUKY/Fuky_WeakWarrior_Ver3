using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
    public AudioSource sound;
    public static SoundController instanceSound = null;

    void Awake()
    {
        if (instanceSound == null)
            instanceSound = this;
        else if (instanceSound != this)
            Destroy(gameObject);

        // Không bị destroy kh load lại scene
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip audio)
    {
        // audio.Play();
        sound.clip = audio;
        sound.Play();
    }
    public void StopSingle(AudioClip audio)
    {
        sound.clip = audio;
        sound.Stop();
    }
}
