using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    //ENCAPSULATION
    [SerializeField] private AudioSource bombExplode;
    [SerializeField] private AudioSource sataliteExplosion;
    [SerializeField] private AudioSource shipExplode;
    [SerializeField] private AudioSource sataliteEscape;
    [SerializeField] private AudioSource music;

    private void Awake()
    {
        //ABSRACTION
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
