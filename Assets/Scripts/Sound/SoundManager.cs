using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource PlayerFootSteps;
    public AudioSource SoundEffect;
    public AudioSource SoundMusic;
    public SoundType[] Sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(global::Sounds.BackgroundMusic);
    }

    public void PlayMusic(Sounds Sound)
    {
        AudioClip Clip = GetSoundClip(Sound);
        if (Clip != null)
        {
            SoundMusic.clip = Clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.LogError("Background music not found");
        }
    }

    public void Play(Sounds Sound)
    {
        AudioClip Clip = GetSoundClip(Sound);
        if(Clip != null)
        {
            SoundEffect.PlayOneShot(Clip);
        }
        else
        {
            Debug.LogError("Sound not found: " + Sound);
        }
    }

    private AudioClip GetSoundClip(Sounds Sound)
    {
        SoundType item = Array.Find(Sounds, x => x.SoundsType == Sound);
        if(item != null)
        {
            return item.SoundClip;
        }
        else
        {
            Debug.LogError("Sound not found: " + Sound);
            return null;
        }
    }
}

[Serializable]
public class SoundType
{
    public Sounds SoundsType;
    public AudioClip SoundClip;
}

public enum Sounds
{
    None,
    BackgroundMusic,
    ButtonClick,
    PlayerMove,
    PlayerJump,
    PlayerDeath,
    EnemyDeath,
}
