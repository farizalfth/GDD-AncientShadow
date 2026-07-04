using UnityEngine;
using UnityEngine.InputSystem; // Tambahkan ini agar sistem baru terbaca

public class SlowMotionController : MonoBehaviour
{
    public float slowMoScale = 0.3f;
    public GameObject slowMoUI;
    private bool isSlowMo = false;

    void Start()
    {
        if (slowMoUI != null) slowMoUI.SetActive(false);
    }

    void Update()
    {
        // Kode sistem baru untuk mendeteksi tombol T ditekan
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            if (!isSlowMo)
                ActivateSlowMo();
            else
                DeactivateSlowMo();
        }
    }

    void ActivateSlowMo()
    {
        Time.timeScale = slowMoScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale; 
        isSlowMo = true;
        if (slowMoUI != null) slowMoUI.SetActive(true);
    }

    void DeactivateSlowMo()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
        isSlowMo = false;
        if (slowMoUI != null) slowMoUI.SetActive(false);
    }
}