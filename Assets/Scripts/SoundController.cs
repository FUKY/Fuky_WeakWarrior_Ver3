using UnityEngine;
using System.Collections;

public class SoundController : MonoSingleton<SoundController> {
    public AudioSource sound;
    public static SoundController instanceSound = null;

    public enum SoundType
    {
        //PLAYER
        PLAYER_SWING = 0,
        PLAYER_BREAK = 1,
        PLAYER_ATTACKED = 2,
        PLAYER_DEAD = 3,
        PLAYER_SKILL = 4,

        //ENEMY
        ENEMY_ATTACKED = 5,
        
        //BOSS
        BOSS_APPEAR = 6
    }

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
        sound.PlayOneShot(audio);
    }
    public void StopSingle(AudioClip audio)
    {
        sound.clip = audio;
        sound.Stop();
    }
}
