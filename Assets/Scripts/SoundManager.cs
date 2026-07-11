using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources (Diisi Otomatis Oleh Script)")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip bgmClip;
    public AudioClip clickClip;
    public AudioClip hoverClip;

    [Header("Sliders")]
    public Slider sfxSlider; // Slider Atas (Volume Button)
    public Slider bgmSlider; // Slider Bawah (Volume Backsound)

    void Awake()
    {
        // Membuat musik tetap menyala sepanjang game (tidak hancur saat ganti scene)
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

        // OTOMATISASI: Mencari dan membuat AudioSource jika masih kosong (None)
        AudioSource[] sources = GetComponents<AudioSource>();
        
        if (bgmSource == null)
        {
            if (sources.Length > 0) bgmSource = sources[0];
            else bgmSource = gameObject.AddComponent<AudioSource>();
        }

        if (sfxSource == null)
        {
            if (sources.Length > 1) sfxSource = sources[1];
            else sfxSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        // Ambil setelan volume yang tersimpan, default ke 0.7 (70%)
        float savedBGM = PlayerPrefs.GetFloat("BGMVolume", 0.7f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", 0.7f);

        // Setup Backsound (BGM)
        if (bgmSource != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.volume = savedBGM;
            bgmSource.Play();
        }

        // Setup Efek Suara (SFX)
        if (sfxSource != null)
        {
            sfxSource.volume = savedSFX;
        }

        // Hubungkan ke Slider Atas (SFX)
        if (sfxSlider != null)
        {
            sfxSlider.minValue = 0f;
            sfxSlider.maxValue = 1f;
            sfxSlider.value = savedSFX;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }

        // Hubungkan ke Slider Bawah (BGM)
        if (bgmSlider != null)
        {
            bgmSlider.minValue = 0f;
            bgmSlider.maxValue = 1f;
            bgmSlider.value = savedBGM;
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        }
    }

    public void SetBGMVolume(float value)
    {
        if (bgmSource != null) bgmSource.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        if (sfxSource != null) sfxSource.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void PlayClick()
    {
        if (sfxSource != null && clickClip != null)
        {
            sfxSource.PlayOneShot(clickClip);
        }
    }

    public void PlayHover()
    {
        if (sfxSource != null && hoverClip != null)
        {
            sfxSource.PlayOneShot(hoverClip);
        }
    }
}