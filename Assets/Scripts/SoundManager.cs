using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource bombExplode;
    public AudioSource sataliteExplosion;
    public AudioSource shipExplode;
    public AudioSource sataliteEscape;
    public AudioSource music;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayMusic();
    }
    public void PlayBombExplode()
    {
        bombExplode.Play();
    }
    public void PlaySataliteExplosion()
    {
        sataliteExplosion.Play();
    }
    public void PlayShipExplode()
    {
        shipExplode.Play();
    }
    public void PlaySataliteEscape()
    {
        sataliteEscape.Play();
    }
    public void PlayMusic()
    {
        music.Play();
    }


}
