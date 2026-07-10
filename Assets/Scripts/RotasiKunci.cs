using UnityEngine;

public class RotasiKunci : MonoBehaviour
{
    [Header("Pengaturan Rotasi")]
    public float kecepatanRotasi = 100f; // Kecepatan putaran kunci

    [Header("Efek Mengambang (Naik-Turun)")]
    public bool gunakanEfekMengambang = true;
    public float tinggiMengambang = 0.2f;  // Seberapa tinggi kunci naik-turun
    public float kecepatanMengambang = 2.5f; // Seberapa cepat kunci naik-turun

    private Vector3 posisiAwal;

    void Start()
    {
        // Menyimpan posisi awal koordinat kunci
        posisiAwal = transform.position;
    }

    void Update()
    {
        // 1. Efek Putar (Rotasi pada sumbu Y)
        transform.Rotate(0f, kecepatanRotasi * Time.deltaTime, 0f, Space.World);

        // 2. Efek Mengambang (Naik-Turun secara lembut menggunakan rumus Sinus)
        if (gunakanEfekMengambang)
        {
            float yBaru = posisiAwal.y + Mathf.Sin(Time.time * kecepatanMengambang) * tinggiMengambang;
            transform.position = new Vector3(transform.position.x, yBaru, transform.position.z);
        }
    }
}