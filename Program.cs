// game
// Genre : Fighting
// karakter : nama, kesehatan

using System;
using System.Collections.Generic;

namespace KerangkaGame
{
    class Karakter
    {
        public int totalSenjata, power;

        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }

        // Posisi karakter
        public int posisiAwal { get; private set; }
        public int posisiSaatIni { get; private set; }

        // membuat constructor
        public Karakter(string nama, int kesehatan, int senjata, int posisiAwal)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;

            this.posisiAwal = posisiAwal;
            this.posisiSaatIni = posisiAwal;
        }

        public void Serang(Karakter target)
        {
            Console.WriteLine("MULAI SERANGAN");
            target.TerimaSerangan(this.senjata);
        }

        public void TerimaSerangan(int jumlahSerangan)
        {
            kesehatan -= jumlahSerangan;
            Console.WriteLine($"{nama} diserang dengan {jumlahSerangan}. Sisa kesehatan {kesehatan}");
        }

        public void PilihanPenyembuhan()
        {
            Console.WriteLine("Ada Pilihan Penyembuhan ");
            Console.WriteLine($"Sembuhkan {nama} ?");
        }
        public void Aksi(int posisi)
        {
            posisiSaatIni = posisi;

            Console.WriteLine($"{nama} berpindah dari posisi {posisiAwal} ke posisi {posisiSaatIni}");
        }

        public void getData()
        {
            Console.WriteLine($"Karakter : {nama}");
            Console.WriteLine($"Posisi awal : {posisiAwal}");
            Console.WriteLine($"Posisi saat ini : {posisiSaatIni}");
        }

        public void Healing(int tambahKesehatan)
        {
            kesehatan += tambahKesehatan;
            Console.WriteLine($"Disembuhkan {kesehatan}");
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            // player utama
            Karakter player1 = new Karakter("mira", 100, 10, 0);

            // musuh
            Karakter musuh = new Karakter("jikra", 100, 100, 10);

            // aksi perpindahan posisi
            player1.Aksi(5);

            // serangan
            player1.Serang(musuh);

            // penyembuhan
            musuh.Healing(20);

            // menampilkan data
            player1.getData();
        }
    }
}