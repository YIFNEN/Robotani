using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("배경음악")]
    public AudioClip bgmClip;

    [Header("효과음")]
    public AudioClip shootSFX;
    public AudioClip explosionSFX;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        bgmSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        bgmSource.loop = true;
        bgmSource.volume = 0.4f;
        sfxSource.playOnAwake = false;
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM()
    {
        if (bgmClip != null)
        { 
            bgmSource.clip = bgmClip;
            bgmSource.Play();
        }
    }

    public void PlayShoot()
    {
        PlaySFX(shootSFX);
    }

    public void PlayExplosion()
    {
        PlaySFX(explosionSFX);
    }
}
