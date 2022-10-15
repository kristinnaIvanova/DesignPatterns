using System;
using System.Collections.Generic;

/// <summary>
/// Клас 'Memento'
/// </summary>
public class Memento
{
    //поле
    private string state;

    //конструктор
    public Memento(string state)
    {
        this.state = state;
    }

    //метод за взимане на състоянието
    public string GetState()
    {
        return this.state;
    }
}

/// <summary>
/// Клас 'Originator'
/// </summary>
public class Originator
{
    //поле
    private string state;

    //метод за задаване на състояние
    public void SetState(string state)
    {
        this.state = state;
    }

    //метод за взимане на състоянието
    public string GetState()
    {
        return this.state;
    }

    //създава "спомен"
    public Memento SaveStateToMemento()
    {
        return new Memento(this.state);
    }

    // възстановява първоначалното състояние
    public void GetStateFromMemento(Memento memento)
    {
        this.state = memento.GetState();
    }
}

/// <summary>
/// Клас 'CareTaker'
/// </summary>
public class CareTaker
{
    //лист за съхранение на спомени
    private List<Memento> mementoList = new List<Memento>();


    //добавяне на спомен
    public void Add(Memento state)
    {
        mementoList.Add(state);
    }


    //взимане и връщане на конкретен спомен (ако искаме първия спомен, то подавания
    //индекс за параметър трябва да е 0 и т.н.)
    public Memento Get(int index)
    {
        return mementoList[index];
    }
}

/// <summary>
/// Клас 'MementoPatternDemo'
/// </summary>
public class MementoPatternDemo
{
    public static void Main()
    {
        //както написах в анализа - в този клас създаваме и работим
        //с обекти от класовете Originator и CareTaker, затова си ги декларираме
        Originator originator = new Originator();
        CareTaker careTaker = new CareTaker();

        //задаваме първо и трето състояние
        originator.SetState("Състояние #1");
        originator.SetState("Състояние #2");
        //запазваме/правим снимка на текущото състояние - в случая е състояние 2
        careTaker.Add(originator.SaveStateToMemento());

        //променяме състоянието на 3
        originator.SetState("Състояние #3");
        //него също го запазваме
        careTaker.Add(originator.SaveStateToMemento());

        //променяме състоянието на 4
        originator.SetState("Състояние #4");
        //извикваме текущото състояние
        Console.WriteLine("Текущо състояние: " + originator.GetState());

        //връщаме се 'назад във времето' и отпечатваме първото съхранено състояние
        //в случая е Състояние #2, защото Състояние #1 не го запазихме
        originator.GetStateFromMemento(careTaker.Get(0));
        Console.WriteLine("Първо запазено състояние: " + originator.GetState());

        //'докосваме' се до второто състояние
        originator.GetStateFromMemento(careTaker.Get(1));
        //отпечатваме второто състояние
        Console.WriteLine("Второ запазено състояние: " + originator.GetState());
    }
}
