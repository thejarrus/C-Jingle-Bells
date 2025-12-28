# 🎄 C# Console Jingle Bells

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-blue?style=for-the-badge)

**"Yılbaşı ağacını kurmadım, kodladım."**

Bu proje, C# Konsol uygulamasının sınırlarını zorlayarak; ritmik, senkronize ve nesne tabanlı (OOP) prensiplere sadık kalınarak hazırlanmış bir "Jingle Bells" görsel/işitsel şölenidir.

Sıradan `Console.WriteLine` projelerinden sıkılanlar için **Clean Code** ve **Müzik Teorisi** (BPM Matematiği) kullanılarak geliştirilmiştir.

---

## 🚀 Özellikler

* **🎵 BPM Tabanlı Ritim Motoru:** Rastgele bekleme süreleri (`Thread.Sleep`) yerine, şarkının BPM (Beats Per Minute) değerine göre hesaplanan matematiksel nota süreleri kullanıldı.
* **🚫 No Magic Numbers:** Frekanslar ve süreler `Enum` ve `Constant` yapılarıyla yönetildi. Kodun içinde anlamsız sayılar göremezsiniz.
* **⚡ Bloklayıcı Ses Yönetimi:** Kesintisiz (Legato) bir deneyim için `Console.Beep` fonksiyonunun bloklayıcı özelliği kullanılarak "Staccato" etkisi yok edildi.
* **✨ Flicker-Free Görsellik:** Konsol ekranındaki titremeyi (flickering) önlemek için özel render optimizasyonu yapıldı.
* **🏗️ Modüler Yapı:** Şarkının "Verse" ve "Nakarat" kısımları ayrı listelerde tutulup `LINQ` ile dinamik olarak birleştirildi.

---

## 🛠️ Kurulum ve Çalıştırma

Bu projeyi bilgisayarınızda çalıştırmak için .NET SDK yüklü olmalıdır.

1.  **Projeyi Klonlayın:**
    ```bash
    git clone [https://github.com/thejarrus/C-Jingle-Bells.git](https://github.com/thejarrus/C-Jingle-Bells.git)
    ```

2.  **Klasöre Gidin:**
    ```bash
    cd C-Jingle-Bells
    ```

3.  **Çalıştırın:**
    ```bash
    dotnet run
    ```

> **⚠️ ÖNEMLİ İPUCU:** En iyi görsel ve işitsel deneyim için kodu VS Code veya Visual Studio'nun entegre terminalinde değil, **Windows CMD (Komut İstemi)** veya **PowerShell** penceresinde çalıştırın.

---

## 🧠 Kodun Mimarisi

Sadece kopyala-yapıştır yapmadık, bir mimari kurduk:

```csharp
// Ritim Matematiği Örneği
const int BPM = 150; 
const int BeatDuration = 60000 / BPM; 

// Nota Frekansları (Hz)
enum Nota { 
    Sus = 0, 
    C = 261, D = 294, E = 329, ... 
}
