using System;
using System.Collections.Generic;
using System.Linq; // Listeleri birleştirmek için lazım
using System.Threading;

namespace YilbasiAgaci
{
    class Program
    {
        // YILBAŞI AĞACIMIZ (ASCII ART)
        static string[] tree = {
            "         * ",
            "        / \\        ",
            "       /o  \\       ",
            "      /  *  \\      ",
            "     / o   o \\     ",
            "    /   *   o \\    ",
            "   /   o   *   \\   ",
            "  / o    *  o  *\\  ",
            " /_______________\\ ",
            "       |___|       "
        };

        // NOTA FREKANSLARI (Hz) - Pes sesler eklendi
        enum Nota
        {
            Sus = 0,
            G_Low = 196, A_Low = 220, B_Low = 247, // Kalın sesler (Giriş için)
            C = 261, D = 294, E = 329, F = 349, G = 392, A = 440, B = 493,
            C_High = 523, D_High = 587, E_High = 659
        }

        static void Main(string[] args)
        {
            Console.Title = "🎄 C# Jingle Bells 🎄";
            Console.CursorVisible = false;

            // RİTİM AYARLARI (BPM MATEMATİĞİ)
            // Şarkıyı hızlandırmak veya yavaşlatmak için sadece bu sayıyı değiştirmen yeterli!
            const int BPM = 140;
            const int BeatDuration = 60000 / BPM; // Bir vuruşun milisaniye cinsinden süresi

            int Tam = BeatDuration * 4;
            int Yarim = BeatDuration * 2;
            int Ceyrek = BeatDuration;
            int Sekizlik = BeatDuration / 2;

            // 1. BÖLÜM: VERSE (Dashing through the snow...)
            var verse = new List<(Nota, int)>
            {
                (Nota.G_Low, Ceyrek), (Nota.E, Ceyrek), (Nota.D, Ceyrek), (Nota.C, Ceyrek), (Nota.G_Low, Yarim + Ceyrek), // Dashing through the snow
                (Nota.G_Low, Ceyrek), (Nota.G_Low, Ceyrek), (Nota.E, Ceyrek), (Nota.D, Ceyrek), (Nota.C, Ceyrek), (Nota.A_Low, Yarim + Ceyrek), // In a one horse open sleigh
                (Nota.A_Low, Ceyrek), (Nota.F, Ceyrek), (Nota.E, Ceyrek), (Nota.D, Ceyrek), (Nota.B_Low, Yarim + Ceyrek), // O'er the fields we go
                (Nota.G, Ceyrek), (Nota.G, Ceyrek), (Nota.F, Ceyrek), (Nota.D, Ceyrek), (Nota.E, Tam), // Laughing all the way
                
                (Nota.G_Low, Ceyrek), (Nota.E, Ceyrek), (Nota.D, Ceyrek), (Nota.C, Ceyrek), (Nota.G_Low, Yarim), // Bells on bobtail ring
                (Nota.G_Low, Ceyrek), (Nota.E, Ceyrek), (Nota.D, Ceyrek), (Nota.C, Ceyrek), (Nota.A_Low, Yarim + Ceyrek), // Making spirits bright
                (Nota.A_Low, Ceyrek), (Nota.F, Ceyrek), (Nota.E, Ceyrek), (Nota.D, Ceyrek), (Nota.G, Ceyrek), (Nota.G, Ceyrek), (Nota.G, Ceyrek), (Nota.G, Sekizlik), // What fun it is to ride and sing
                (Nota.A, Ceyrek), (Nota.G, Ceyrek), (Nota.F, Ceyrek), (Nota.D, Ceyrek), (Nota.C, Yarim), (Nota.G, Yarim) // A sleighing song tonight! (OH!)
            };

            // 2. BÖLÜM: CHORUS (Jingle Bells...)
            var nakarat = new List<(Nota, int)>
            {
                (Nota.E, Ceyrek), (Nota.E, Ceyrek), (Nota.E, Yarim), // Jin-gle Bells
                (Nota.E, Ceyrek), (Nota.E, Ceyrek), (Nota.E, Yarim), // Jin-gle Bells
                (Nota.E, Ceyrek), (Nota.G, Ceyrek), (Nota.C, Ceyrek + Sekizlik), (Nota.D, Sekizlik), (Nota.E, Tam), // Jin-gle All The Way
                
                (Nota.F, Ceyrek), (Nota.F, Ceyrek), (Nota.F, Ceyrek + Sekizlik), (Nota.F, Sekizlik), // Oh what fun
                (Nota.F, Ceyrek), (Nota.E, Ceyrek), (Nota.E, Ceyrek), (Nota.E, Sekizlik), (Nota.E, Sekizlik), // It is to ride
                (Nota.E, Ceyrek), (Nota.D, Ceyrek), (Nota.D, Ceyrek), (Nota.E, Ceyrek), (Nota.D, Yarim), (Nota.G, Yarim), // One horse open sleigh

                // Tekrar (Final Coşkusu)
                (Nota.E, Ceyrek), (Nota.E, Ceyrek), (Nota.E, Yarim),
                (Nota.E, Ceyrek), (Nota.E, Ceyrek), (Nota.E, Yarim),
                (Nota.E, Ceyrek), (Nota.G, Ceyrek), (Nota.C, Ceyrek + Sekizlik), (Nota.D, Sekizlik), (Nota.E, Tam),

                (Nota.F, Ceyrek), (Nota.F, Ceyrek), (Nota.F, Ceyrek + Sekizlik), (Nota.F, Sekizlik),
                (Nota.F, Ceyrek), (Nota.E, Ceyrek), (Nota.E, Ceyrek), (Nota.E, Sekizlik), (Nota.E, Sekizlik),
                (Nota.G, Ceyrek), (Nota.G, Ceyrek), (Nota.F, Ceyrek), (Nota.D, Ceyrek), (Nota.C, Tam) // Final C ile bitiş!
            };

            // İki listeyi birleştiriyoruz
            var tamSarki = verse.Concat(nakarat).ToList();

            // ÖN HAZIRLIK
            Console.WriteLine("Yılbaşı Konseri Başlıyor... 🎄");
            // Flicker'ı önlemek için ağaç stringini bir kere oluşturup hafızaya atıyoruz.
            string hazirAgac = string.Join("\n", tree);
            Thread.Sleep(1000);
            Console.Clear();

            // OYNATICI
            foreach (var (nota, sure) in tamSarki)
            {
                // Görsel Güncelleme
                RengiDegistir();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(hazirAgac);

                // Ses Çalma (Akıcı Mod)
                if (nota == Nota.Sus)
                {
                    Thread.Sleep(sure); // Sadece suslarda bekle
                }
                else
                {
                    // Beep zaten blokladığı için extra Sleep'e gerek yok.
                    // Süreyi tam kullanıyoruz, böylece ses hiç kesilmiyor.
                    Console.Beep((int)nota, sure);
                }

                // Çok çok kısa bir 'nefes' payı. 
                // Bunu koymazsak bazı hoparlörlerde sesler birbirine tamamen karışıp uğultu yapabilir.
                // 45 yerine 10 yaptık.
                Thread.Sleep(10);
            }

            // FİNAL
            Console.ResetColor();
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("Mutlu Yıllar! Code on. 💻🎅");
            Console.ReadLine();
        }

        static void RengiDegistir()
        {
            ConsoleColor[] parlakRenkler = {
                ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow,
                ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.White
            };
            Random rnd = new Random();
            Console.ForegroundColor = parlakRenkler[rnd.Next(parlakRenkler.Length)];
        }
    }
}
