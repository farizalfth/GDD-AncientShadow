🗿 Shadow of the Ancient Village 3D
![alt text](https://img.shields.io/badge/Unity-6.000.3.12f1-black.svg?style=for-the-badge&logo=unity)

![alt text](https://img.shields.io/badge/Platform-Windows%20%7C%20Android%20%7C%20iOS-blue.svg?style=for-the-badge)

![alt text](https://img.shields.io/badge/Status-In--Development-green.svg?style=for-the-badge)
Shadow of the Ancient Village 3D adalah game petualangan orang ketiga (Third-Person Adventure) yang membawa pemain menjelajahi sisa-sisa peradaban kuno yang hilang. Ungkap rahasia di balik reruntuhan, lalui jalur tersembunyi, dan rasakan atmosfer misterius di desa yang telah ditinggalkan berabad-abad lamanya.
✨ Fitur Utama
Hybrid Control System: Dukungan penuh untuk perangkat Mobile (Virtual Joystick & Touchpad) dan PC (Keyboard & Mouse).
Third-Person Mechanics: Sistem karakter yang responsif dengan kemampuan Jalan, Lari, Lompat, dan Sprint.
Slow Motion Mechanic: Fitur manipulasi waktu untuk membantu eksplorasi atau menghindari rintangan.
Immersive Environment: Pencahayaan atmosferik menggunakan SkySeries Freebie dan desain level berbasis Unity 3D Game Kit.
Dynamic Camera: Kamera yang mengikuti karakter secara halus dengan kontrol geser layar untuk perangkat mobile.
📱 Kontrol Game (Hybrid)
Aksi	PC (Keyboard/Mouse)	Mobile (UI Buttons)
Gerak	W, A, S, D	Virtual Joystick (Kiri)
Kamera	Mouse Movement	Touchpad Area (Kanan)
Lompat	Space	Jump Button
Lari / Run	Left Shift (Hold)	Run Button
Sprint	Shift + W	Sprint Button
Slow Motion	T	Slowmo Button
🛠️ Dibangun Dengan
Engine: Unity 6 (LTS 6000.3.12f1)
Language: C#
Framework: NaughtyCharacter Controller
Assets:
Unity 3D Game Kit
SkySeries Freebie
Mobile Joystick Pack
📁 Project Structure

Berikut adalah gambaran struktur folder utama dalam proyek ini:

```text
.
├── Assets/                 # Semua konten utama game
│   ├── 3DGamekit/          # Aset lingkungan dan karakter 3D
│   ├── Joystick Pack/      # Aset untuk sistem kontrol mobile
│   ├── UTS/                # Logika utama game (Scripts, Scenes, Defs)
│   │   ├── Scripts/        # PlayerInput, Controller, Touchpad logic
│   │   └── Scenes/         # Level game (Level 1, Menu, dll)
│   └── SkySeries Freebie/  # Aset langit dan pencahayaan
├── Packages/               # Manifest paket Unity
├── ProjectSettings/        # Pengaturan konfigurasi proyek Unity
├── .gitignore              # Daftar file yang diabaikan oleh Git
└── README.md               # Dokumentasi proyek
🚀 Memulai
Prasyarat
Unity Hub & Unity 6 (6000.3.12f1) atau versi yang lebih baru.
Git Installed.
Instalasi
Clone repositori ini:
code
Bash
git clone https://github.com/farizalfth/ShadowoftheAncientVillage3D.git
Buka Unity Hub dan klik Add > pilih folder proyek.
Tunggu Unity selesai mengimpor aset (mungkin butuh waktu karena 3D Game Kit cukup besar).
Buka scene utama: Assets/UTS/Scenes/Level1.unity.
Tekan Play untuk memulai petualangan.
🗺️ Rencana Pengembangan (Roadmap)

Integrasi Kontrol Mobile (Joystick & Touchpad).

Implementasi Fitur Slow Motion.

Sistem Musuh (AI Enemy).

Sistem Quest & Interaksi Dialog.

Mekanik Puzzle Lingkungan.

Inventory & Save/Load System.

Optimasi Performa untuk Mobile.
👨‍💻 Pengembang
Muhammad Fariz Alfattah
Game Design and Development Project
📝 Lisensi
Proyek ini dibuat untuk tujuan edukasi dan portofolio. Aset yang digunakan mengikuti lisensi masing-masing penyedia (Unity Asset Store).
Cara Menggunakan README ini:
Buka file README.md di Visual Studio Code atau di GitHub.
Copy-paste kode Markdown di atas.
Tips: Untuk bagian Screenshot, sebaiknya kamu tambahkan gambar game kamu nantinya di bawah bagian "Features" agar orang yang melihat GitHub kamu bisa langsung tahu visual game-nya.
Pesan commit saran saya: docs: update README with mobile controls and project overview