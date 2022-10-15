using System;
using System.Collections.Generic;

/// <summary>
/// Клас 'IPhone'
/// </summary>
public class IPhone
{
    //свойства - характеристики на модела
    public string Model { get; set; }
    public string Processor { get; set; }    
    public string Size { get; set; }
    public double Price { get; set; }

    //конструктор
    public IPhone(string model, string processor, string size, double price)
    {
        this.Model = model;
        this.Processor = processor;
        this.Size = size;
        this.Price = price;
    }

    //извличане на всички детайли относно телефона
    public string GetDetails()
    {
        return $"IPhone {this.Model} [Процесор - {this.Processor}] [Памет - {this.Size}] [Цена - {this.Price}]";
    }
}

/// <summary>
/// Клас 'Memento'
/// </summary>
public class Memento
{
    //свойство
    public IPhone _iphone { get; set; }

    //конструктор за създаване на спомен
    public Memento(IPhone newIphone)
    {
        this._iphone = newIphone;
    }

    //взимане на характеристиките на телефон, за да ги пазим в спомена
    public string GetDetails()
    {
        return _iphone.GetDetails();
    }
}

/// <summary>
/// Клас 'Caretaker'
/// </summary>
public class Caretaker
{
    //списък с телефони
    private List<Memento> iphoneList = new List<Memento>();

    //добавяне на телефон в Телефонната банка
    public void AddMemento(Memento m)
    {
        iphoneList.Add(m);
        Console.WriteLine("Успешно добавихте Вашия телефон към Телефонната банка: " + m.GetDetails());
    }

    //взимане на конкретен телефон
    public Memento GetMemento(int index)
    {
        return iphoneList[index];
    }
}

/// <summary>
/// Клас 'Originator'
/// </summary>
public class Originator
{
    public IPhone _iphone;

    public Memento CreateMemento()
    {
        return new Memento(_iphone);
    }
    public void SetMemento(Memento memento)
    {
        _iphone = memento._iphone;
    }
    public string GetDetails()
    {
        return _iphone.GetDetails();
    }
}

/// <summary>
/// Клас 'Program'
/// </summary>
class Program
{
    static void Main()
    {
        //закупуване на нов телефон
        Originator originator = new Originator();
        originator._iphone = new IPhone("12 Pro", "Apple A15 Bionic", "128MB", 1200.0);

        //създаване на Телефонна банка
        Caretaker caretaker = new Caretaker();

        //добавяне на Iphone 12 Pro в банката
        caretaker.AddMemento(originator.CreateMemento());

        //закупуване на нов телефон
        originator._iphone = new IPhone("13 Pro", "Apple A21", "128MB", 1750.50);

        //добавяне на Iphone 13 Pro в банката
        caretaker.AddMemento(originator.CreateMemento());

        //закупуване на нов телефон
        originator._iphone = new IPhone("14 Pro", "Apple A35 Super", "258MB", 2200.90);

        Console.WriteLine("\nТекущ телефон: " + originator.GetDetails());
        Console.WriteLine("\nВръщане на първи модел...");
        originator._iphone = caretaker.GetMemento(0)._iphone;
        Console.WriteLine("\nТекущо състояние след връщане на първичния модел: " + originator.GetDetails());
        Console.ReadKey();
    }
}