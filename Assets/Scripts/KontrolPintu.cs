using UnityEngine;

public class KontrolPintu : MonoBehaviour
{
    [Header("Pengaturan Pintu")]
    public GameObject visualPintu;    // Drag objek "Door Level" (pintu kayu) ke sini
    public Collider colliderPintu;     // Drag Box Collider fisik pada "Door Level" ke sini

    [Header("Pengaturan UI")]
    public GameObject panelPeringatan;  // Drag UI Teks/Panel Peringatan ke sini

    [Header("Referensi Script Misi")]
    public MisiKoleksiWaktu misiKoleksiWaktu; // Drag GameObject GameManager ke sini

    private void Start()
    {
        // Mencari otomatis di scene jika lupa di-drag di Inspector
        if (misiKoleksiWaktu == null)
        {
            misiKoleksiWaktu = FindObjectOfType<MisiKoleksiWaktu>();
        }

        if (panelPeringatan != null)
        {
            panelPeringatan.SetActive(false);
        }
    }

    private void Update()
    {
        // Terus periksa apakah di script MisiKoleksiWaktu pintu sudah dinyatakan boleh terbuka
        if (misiKoleksiWaktu != null && misiKoleksiWaktu.ApakahPintuTerbuka())
        {
            BukaPintuSecaraFisik();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Jika kunci belum cukup (pintu belum terbuka di script misi), munculkan peringatan
            if (misiKoleksiWaktu != null && !misiKoleksiWaktu.ApakahPintuTerbuka())
            {
                TampilkanPeringatan();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SembunyikanPeringatan();
        }
    }

    void BukaPintuSecaraFisik()
    {
        // Menghilangkan pintu kayu
        if (visualPintu != null && visualPintu.activeSelf) 
            visualPintu.SetActive(false);

        // Mematikan tabrakan fisik agar pemain bisa lewat masuk ke trigger pindah level
        if (colliderPintu != null && colliderPintu.enabled) 
            colliderPintu.enabled = false;

        SembunyikanPeringatan();
    }

    void TampilkanPeringatan()
    {
        if (panelPeringatan != null)
        {
            panelPeringatan.SetActive(true);
        }
    }

    void SembunyikanPeringatan()
    {
        if (panelPeringatan != null)
        {
            panelPeringatan.SetActive(false);
        }
    }
}