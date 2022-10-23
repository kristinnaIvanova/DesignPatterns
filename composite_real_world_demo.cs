using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/// <summary>
/// Клас 'File' за създаване на файлове и директории
/// </summary>
public class File
{
    //полета
    private int size;
    private string type;
    private List<File> subfiles;
    
    //конструктор
    public File(int size, string type)
    {
        this.size = size;
        this.type = type;
        this.subfiles = new List<File>();
    }
    //метод за взимане на типа
    public string GetType()
    {
        return this.type;
    }

    //метод за взимаме на размера на файла
    public int GetSize()
    {
        //проверка дали файлът съдътжа в себе си подфайлове
        if (this.subfiles.Count>0)
        {
            return this.subfiles.Sum(x => x.GetSize());
        }
        return this.size;
    }
    //метод за добавяне на файлове
    public void AddFile(File file)
    {
        this.subfiles.Add(file);
    }

    //метод за премахване на файлове
    public void RemoveFile(File file)
    {
        this.subfiles.Remove(file);
    }
    //метод за изпечатване на пълната информация за файла, ако той е папка
    public string GetSubfilesInfo()
    {
        StringBuilder info = new StringBuilder();
        if (this.subfiles.Count>0)
        {
            info.AppendLine($"Това е папка с размер {this.GetSize()}KB и съдържа следните файлове:");
            for (int i = 1; i <= this.subfiles.Count; i++)
            {
                info.AppendLine($"{i}. {subfiles[i - 1].ToString()}");
            }
        }
        return info.ToString();
    }
    //отпечатване информация за отделен файл
    public override string ToString()
    {
        return $"{this.type} с размер {this.GetSize()}KB";
    }
    
}
class Program
{
    static void Main()
    {
        //добавяне на обикновени файлове, т.е. не са папки/директории
        File txtFile = new File(100, "текстови файл");
        File pngFile = new File(200, "PNG изображение");
        File mp4File = new File(400, "MP4 видеофайл");

        //добавяне на папка с първоначален размер памет 0КВ, защото е празна
        File directory = new File(0, "Папка");

        //добавяне на файлове в папката
        directory.AddFile(txtFile);
        directory.AddFile(pngFile);
        directory.AddFile(mp4File);

        //отпечатване на информация за отделите файлове
        Console.WriteLine(txtFile.ToString());
        Console.WriteLine(pngFile.ToString());
        Console.WriteLine(mp4File.ToString());
  
        //отпечатване на информация за папката
        Console.WriteLine(directory.ToString());

        //отпчечатване на съдържанието на папката
        Console.WriteLine("\n"+directory.GetSubfilesInfo());

        //премахване на файл от папката
        directory.RemoveFile(pngFile);

        //отпчечатване на съдържанието на папката след премахване на файла
        Console.WriteLine(directory.GetSubfilesInfo());
    }
}