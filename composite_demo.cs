using System;
using System.Collections.Generic;

/// <summary>
/// Абстрактен клас 'Component' за направата на отделен елемент
/// </summary>
abstract class Component
{
    //поле
    protected string name;

    //конструктор
    public Component(string name)
    {
        this.name = name;
    }

    //описание на абстрактни методи
    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
}

/// <summary>
/// Клас 'Composite' за структуриране на отделните елементи и добавяне на функционалност на структурата
/// </summary>
class Composite : Component
{
    //Списък за събиране на отделните компоненти в една структура
    private List<Component> _children = new List<Component>();

    //конструктор
    public Composite(string name)
      :base(name)
    {

    }


    //имплементиране на метод за добавяне на елемент
    public override void Add(Component component)
    {
        _children.Add(component);
    }

    //имплементиране на метод за премахване на елемент
    public override void Remove(Component component)
    {
        _children.Remove(component);
    }


    //имплементиране на метод за визуализиране на елементите на структурата
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);

        // Recursively display child nodes
        foreach (Component component in _children)
        {
            component.Display(depth + 2);
        }
    }
}

/// <summary>
/// Клас 'Leaf' - Листо, т.е. това е последния елемент за даден клон
/// </summary>
class Leaf : Component
{
    //конструктор
    public Leaf(string name)
      : base(name)
    {
    }
    //имплементиране на метод, но в случай с последния елемент на 'клона', ще върне съобщение
    //защото 'под листото няма нищо'
    public override void Add(Component c)
    {
        Console.WriteLine("Cannot add to a leaf");
    }
    //имплементиране на метод, но в случай с последния елемент на 'клона', ще върне съобщение
    //защото 'под листото няма нищо'
    public override void Remove(Component c)
    {
        Console.WriteLine("Cannot remove from a leaf");
    }
    //имплементиране на метод за визуализиране на 'листото'
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);
    }
}

class Program
{
    static void Main()
    {
        //създаване на 'корен' и добавяне на листа съм него
        Composite root = new Composite("Корен");
        root.Add(new Leaf("Листо A"));
        root.Add(new Leaf("Листо B"));

        //създаване на 'клон' и добавяне на листа съм него
        Composite comp = new Composite("Клон 1");
        comp.Add(new Leaf("Листо 1.1"));
        comp.Add(new Leaf("Листо 1.2"));

        //добавяне ан клона към корена
        root.Add(comp);
        //добавяне на листо към корена
        root.Add(new Leaf("Листо C"));

        //създаване на листо
        Leaf leaf = new Leaf("Листо D");

        //добавяне на листото към корена
        root.Add(leaf);
        //премахване на листото откорена
        root.Remove(leaf);

        //визуализиране на дървото
        root.Display(1);

        //изчакване на символ, за да не се скрие конзолата
        Console.ReadKey();

    }
}