using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Клас 'IPhone'
/// </summary>
public class Command
{
    //свойства - характеристики на модела
    public string Usage { get; set; }

    //конструктор
    public Command(string usage)
    {
        this.Usage = usage;
    }

    //извличане на всички детайли относно телефона
    public string GetDetails()
    {
       return this.Usage;
    }
}

/// <summary>
/// Клас 'Memento'
/// </summary>
public class Memento
{
    //свойство
    public Command _command { get; set; }

    //конструктор за създаване на спомен
    public Memento(Command newCommand)
    {
        this._command = newCommand;
    }

    //взимане на характеристиките на командата, за да ги пазим в спомена
    public string GetDetails()
    {
        return _command.GetDetails();
    }
}

/// <summary>
/// Клас 'Caretaker'
/// </summary>
public class Caretaker
{
    //стек от команди
    private Stack<Memento> commands = new Stack<Memento>();

    //добавяне на нова команда
    public void NewCommand(Memento m)
    {
        commands.Push(m);
        Console.WriteLine(m.GetDetails());
    }

    //взимане на последната команда
    public Memento LastCommand()
    {
        return commands.Peek();
    }

    //взимане на предишната команда
    public Memento UndoCommand()
    {
        Stack<Memento> copy = new Stack<Memento>((Stack<Memento>)this.commands);
        copy.Pop();
        return copy.Pop();
    }

    //връщане на команда
    public Memento RedoCommand()
    {
        return commands.Peek();
    }

    //извличане на всички команди
    public string CommandsList()
    {
        StringBuilder allCommands = new StringBuilder();
        Stack<Memento> copy = new Stack<Memento>((Stack<Memento>)this.commands);
        while (copy.Count!=0)
        {
            allCommands.AppendLine(copy.Pop().GetDetails());
        }
        return allCommands.ToString();
    }
}

/// <summary>
/// Клас 'Originator'
/// </summary>
public class Originator
{
    public Command _command;

    public Memento CreateMemento()
    {
        return new Memento(_command);
    }
    public void SetMemento(Memento memento)
    {
        _command = memento._command;
    }
    public string GetDetails()
    {
        return _command.GetDetails();
    }
}

/// <summary>
/// Клас 'Program'
/// </summary>
class Program
{
    static void Main()
    {
        //Команда 1
        Originator originator = new Originator();
        originator._command = new Command("Добавяне на нов слой");

        //създаване на History 
        Caretaker caretaker = new Caretaker();

        //добавяне командата в History-то
        caretaker.NewCommand(originator.CreateMemento());

        //Команда 2
        originator._command = new Command("Добавяне на правоъгълник");

        //добавяне командата в History-то
        caretaker.NewCommand(originator.CreateMemento());

        //Команда 3
        originator._command = new Command("Запълване на правоъгълника в синьо");

        //добавяне командата в History-то
        caretaker.NewCommand(originator.CreateMemento());

        Console.WriteLine("\nПоследна команда: " + caretaker.LastCommand().GetDetails());

        Console.WriteLine("\nВръщане една команда назад...");
        originator._command = caretaker.UndoCommand()._command;
        Console.WriteLine("Последна изпълнена команда: " + originator.GetDetails());

        Console.WriteLine("\nВръщане една команда напред...");
        originator._command = caretaker.RedoCommand()._command;
        Console.WriteLine("Последна изпълнена команда: " + originator.GetDetails());

        Console.WriteLine("\nОтпечатване на всички команди:\n" + caretaker.CommandsList());
        Console.ReadKey();
    }
}