using System;
using System.Collections.Generic;
using System.Threading;
class Program{
    class Film{
        public int ID_Film;
        public string Judul;
        public int Tahun;
        public string Genre;
        public string Durasi;
        public double Rating;
    }
    static int FilmTambah = 0;
    static List<Film> Daftar_Film = new List<Film>();
    static void TambahFilm(){
        int i = 0;
        while (i == 0){
        Console.Write("Masukkan Judul Film: ");
        string? judultambah = Console.ReadLine();
        Console.Write("Masukkan Tahun Penayangan Film: ");
        int tahuntambah = Convert.ToInt32(Console.ReadLine());
        Console.Write("Masukkan Genre Film: ");
        string? genretambah = Console.ReadLine();
        Console.Write("Masukkan Durasi Film: ");
        string? durasitambah = Console.ReadLine();
        int j = 0;
        double ratingtambah = 0;
        while (j == 0){
            Console.Write("Masukkan Rating Film (1 - 10): ");
            ratingtambah = Convert.ToDouble(Console.ReadLine());
            if (ratingtambah >= 1 && ratingtambah <= 10){
                j++;
            }
            else{
                Console.WriteLine("Mohon masukkan antara angka 1 - 10");
            }                        
        }
        Daftar_Film.Add(new Film{ID_Film = FilmTambah++, Judul = judultambah, Tahun = tahuntambah, Genre = genretambah, Durasi = durasitambah, Rating = ratingtambah});
        Console.Write("Apakah ingin menambahkan lagi? (y/n): ");
        string? tambahlagi = Console.ReadLine();
        bool tambah = tambahlagi.ToLower() == "y";
        if (tambah){
            i = 0;
        }
        else{
            i++;
            Console.Clear();
        }
        }
    }
    static void TampilFilm(){
        Console.WriteLine($"{"ID",-5}{"Judul",-40}{"Tahun",-10}{"Genre",-22}{"Durasi",-15}{"Rating",-10}");
        foreach (var film in Daftar_Film){
        Console.WriteLine($"{film.ID_Film,-5}{film.Judul,-40}{film.Tahun,-10}{film.Genre,-22}{film.Durasi,-15}{film.Rating,-10}");
        }
    }
    static void UpdateFilm(){
        TampilFilm();
        Console.Write("Masukkan ID Film Yang akan diubah: ");
        int? update = Convert.ToInt32(Console.ReadLine());

    Film filmtoupdate = Daftar_Film.Find(f => f.ID_Film == update);
    if (filmtoupdate == null){
        Console.WriteLine("ID "+ update +" tidak tersedia!.");
        Thread.Sleep(4000);
        return;
        
    }
    Console.WriteLine($"Film yang akan diupdate: {filmtoupdate.Judul}");
    Console.Write("Masukkan Judul Film Baru: ");
    string? judulbaru = Console.ReadLine();
    Console.Write("Masukkan Tahun Film: ");
    int tahunbaru = Convert.ToInt32(Console.ReadLine());
    Console.Write("Masukkan Genre Film Baru: ");
    string? genrebaru = Console.ReadLine();
    Console.Write("Masukkan Durasi Film Baru: ");
    string? durasibaru = Console.ReadLine();
    Console.Write("Masukkan Rating Film Baru: ");
    int j = 0;
        double ratingtambah = 0;
        while (j == 0){
            Console.Write("Masukkan Rating Film (1 - 10): ");
            ratingtambah = Convert.ToDouble(Console.ReadLine());
            if (ratingtambah >= 1 && ratingtambah <= 10){
                j++;
            }
            else{
                Console.WriteLine("Mohon masukkan antara angka 1 - 10");
            }                        
        }
        filmtoupdate.Judul = judulbaru;
        filmtoupdate.Tahun = tahunbaru;
        filmtoupdate.Genre = genrebaru;
        filmtoupdate.Durasi = durasibaru;
        filmtoupdate.Rating = ratingtambah;
        Console.WriteLine("Film telah diperbarui...");
        Console.Clear();
    }
    static void HapusFilm(){
        TampilFilm();
        Console.Write("Masukkan ID Film yang ingin dihapus: ");
        int? hapuspilih = Convert.ToInt32(Console.ReadLine());
        Film filmdihapus = Daftar_Film.Find(f => f.ID_Film == hapuspilih);
        if (filmdihapus == null){
            Console.WriteLine("ID "+hapuspilih+" Tidak Tersedia!");
            Thread.Sleep(4000);
            return;
        }
        Console.Write($"Film Yang Akan Dihapus {filmdihapus.Judul} (y/n): ");
        string? yakinhapus = Console.ReadLine();
        bool yakin = yakinhapus.ToLower() == "y";
        if (yakin){
            Console.WriteLine($"Sukses menghapus film {filmdihapus.Judul}!!");
            Daftar_Film.Remove(filmdihapus);
            Thread.Sleep(2000);
            Console.Clear();
        }
        else{
            Console.WriteLine("Gagal menghapus film!...");
            Console.Clear();
            return;
            }
        
    }
    static void Main(){
        Daftar_Film.Add(new Film{ID_Film = FilmTambah++, Judul = "The Adventures of Tintin", Tahun = 2011, Genre = "Comedy", Durasi = "2 Jam", Rating = 9.4});
        Daftar_Film.Add(new Film{ID_Film = FilmTambah++, Judul = "Uncharted", Tahun = 2022, Genre = "Action", Durasi = "1.56 Jam", Rating = 9.0});
        Daftar_Film.Add(new Film{ID_Film = FilmTambah++, Judul = "Oppenheimer", Tahun = 2023, Genre = "Action", Durasi = "3 Jam", Rating = 10});
        int j = 0;
        while (j == 0){
            
            Console.ForegroundColor = ConsoleColor.Blue; 
        Console.WriteLine("=================================");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan; 
        Console.WriteLine("=Aplikasi Manajemen Film Favorit=");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=================================");
        Console.ResetColor();
        Console.WriteLine("Tekan 1 Untuk Menambah Film Baru!");
        Console.WriteLine("Tekan 2 Untuk Melihat Daftar Film");
        Console.WriteLine("Tekan 3 Untuk Mengpdate Info Film");
        Console.WriteLine("Tekan 4 Untuk Menghapus Nama Film");
        Console.WriteLine("Tekan 5 Untuk keluar aplikasi....");
        Console.Write("Pilihanmu: ");
        int? pilihan = Convert.ToInt32(Console.ReadLine());
        switch (pilihan){
            case 1:
            TambahFilm();
            break;
            case 2:
            TampilFilm();
            Console.Write("Tekan tombol enter saja untuk melanjutkan.....");
            Console.ReadLine();
            break;
            case 3:
            UpdateFilm();
            break;
            case 4:
            HapusFilm();
            break;
            case 5:
            j++;
            Console.Clear();
            Console.WriteLine("Terima Kasih.... (enter untuk melanjutkan)");
            Console.ReadLine();
            break;
            default:
            Console.WriteLine("Masukkan angka 1- 5");
            break;

            
            
        }
       
        } 
    }
}