using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Podaj ścieżkę do folderu: ");
        string folderPath = Console.ReadLine();

        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("Podany folder nie istnieje.");
            return;
        }

        string[] bmpFiles = Directory.GetFiles(folderPath, "*.bmp");

        foreach (string bmpFile in bmpFiles)
        {
            try
            {
                string jpgFile = Path.ChangeExtension(bmpFile, ".jpg");

                using (Image image = Image.FromFile(bmpFile))
                {
                    image.Save(jpgFile, ImageFormat.Jpeg);
                }

                Console.WriteLine($"Przekonwertowano: {Path.GetFileName(bmpFile)} -> {Path.GetFileName(jpgFile)}");

                // Usuń oryginalny plik BMP (odkomentuj jeśli chcesz)
                File.Delete(bmpFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przy pliku {bmpFile}: {ex.Message}");
            }
        }

        Console.WriteLine("Gotowe.");
    }
}
