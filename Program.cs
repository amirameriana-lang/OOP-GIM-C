// Game
// Genre : Fighting
// Karakter : nama, kesehatan, senjata

using System;

namespace GameFighting
{
    class Karakter
    {
        // Property
        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }

        // Constructor
        public Karakter(string nama, int kesehatan, int senjata)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
        }

        // Method menyerang
        public void SeranganKe(Karakter lawan)
        {
            Console.WriteLine();
            Console.WriteLine("SERANGAN");

            lawan.KenaSerang(this.senjata);
        }

        // Method menerima serangan
        public void KenaSerang(int damage)
        {
            kesehatan -= damage;

            if (kesehatan < 0)
            {
                kesehatan = 0;
            }

            Console.WriteLine($"{nama} menerima {damage} damage");
            Console.WriteLine($"Kesehatan {nama}: {kesehatan}");
        }

        // Method penyembuhan
        public void Pulihkan(int jumlah)
        {
            kesehatan += jumlah;

            if (kesehatan > 100)
            {
                kesehatan = 100;
            }

            Console.WriteLine();
            Console.WriteLine($"{nama} memulihkan kesehatan");
            Console.WriteLine($"Kesehatan sekarang: {kesehatan}");
        }

        // Menampilkan data karakter
        public void LihatData()
        {
            Console.WriteLine();
            Console.WriteLine("DATA KARAKTER");
            Console.WriteLine($"Nama      : {nama}");
            Console.WriteLine($"Kesehatan : {kesehatan}");
            Console.WriteLine($"Senjata   : {senjata}");
        }

        // Method untuk memilih cara perpindahan
        public void Gerak(int posisiAwal)
        {
            int posisi = posisiAwal;

            Console.WriteLine();
            Console.WriteLine("PILIH CARA BERGERAK");
            Console.WriteLine("1. Tombol Keyboard");
            Console.WriteLine("2. Input Angka");
            Console.Write("Pilihanmu (1/2): ");

            string pilihan = Console.ReadLine();

            // Mode keyboard
            if (pilihan == "1")
            {
                Console.WriteLine();
                Console.WriteLine("MODE KEYBOARD");
                Console.WriteLine("Panah Kanan : maju 2");
                Console.WriteLine("Panah Kiri  : mundur 1");
                Console.WriteLine("ESC         : keluar");
                Console.WriteLine($"Posisi awal: {posisi}");

                bool bermain = true;

                while (bermain)
                {
                    ConsoleKeyInfo tombol = Console.ReadKey(true);

                    switch (tombol.Key)
                    {
                        case ConsoleKey.RightArrow:
                            posisi += 2;
                            Console.WriteLine($"Posisi: {posisi}");
                            break;

                        case ConsoleKey.LeftArrow:
                            if (posisi > 0)
                            {
                                posisi -= 1;
                            }

                            Console.WriteLine($"Posisi: {posisi}");
                            break;

                        case ConsoleKey.Escape:
                            bermain = false;
                            Console.WriteLine("Mode permainan selesai.");
                            break;
                    }
                }
            }

            // Mode input angka
            else if (pilihan == "2")
            {
                Console.WriteLine();
                Console.WriteLine("MODE INPUT ANGKA");

                bool bermain = true;

                while (bermain)
                {
                    Console.Write("Masukkan posisi baru (0 untuk keluar): ");

                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int posisiBaru))
                    {
                        Console.WriteLine("Input harus berupa angka.");
                        continue;
                    }

                    if (posisiBaru == 0)
                    {
                        bermain = false;
                        Console.WriteLine("Mode permainan selesai.");
                        continue;
                    }

                    if (posisiBaru < 0)
                    {
                        Console.WriteLine("Posisi tidak boleh negatif.");
                        continue;
                    }

                    posisi = posisiBaru;

                    Console.WriteLine($"Posisi sekarang: {posisi}");
                }
            }

            else
            {
                Console.WriteLine("Pilihan tidak tersedia.");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Membuat karakter
            Karakter pemain = new Karakter("Amira", 100, 25);
            Karakter lawan = new Karakter("Jikroo", 100, 15);

            // Menampilkan data awal
            Console.WriteLine("===== GAME FIGHTING =====");

            pemain.LihatData();
            lawan.LihatData();

            // Pertarungan
            pemain.SeranganKe(lawan);

            lawan.SeranganKe(pemain);

            // Healing
            pemain.Pulihkan(15);

            // Memilih cara bergerak
            pemain.Gerak(0);

            Console.WriteLine();
            Console.WriteLine("Program selesai.");
        }
    }
}