using System;

/// <summary>
/// Създаване на интефейс за Абстрактна фабрика/Фабриката на фабрики
/// </summary>
interface AbstractFactory
{
    //абстрактните методи, които ще ги има и в конкретните фабрики
    //и с които ще създаваме продукти
    public abstract AbstractProductA CreateProductA();
    public abstract AbstractProductB CreateProductB();
}


/// <summary>
/// Създаване на клас, имплементиращ интерфейса, първата Конкретна фабрика
/// </summary>
class ConcreteFactory1 : AbstractFactory
{
    //задължително имплементираме методите от интерфейса
    public AbstractProductA CreateProductA()
    {
        //създаваме един вид конкретен продукт
        return new ProductA1();
    }
    public AbstractProductB CreateProductB()
    {
        //създаваме втори вид конкретен продукт
        return new ProductB1();
    }
}

/// <summary>
/// Създаване на клас, имплементиращ интерфейса, другата Конкретна фабрика
/// </summary>
class ConcreteFactory2 : AbstractFactory
{
    //задължително имплементираме методите от интерфейса
    public AbstractProductA CreateProductA()
    {
        //създаваме трети вид конкретен продукт
        return new ProductA2();
    }
    public AbstractProductB CreateProductB()
    {
        //създаваме четвърти вид конкретен продукт
        return new ProductB2();
    }
}

/// <summary>
/// Създаване на абстрактен клас за първата вид Абстрактен продукт
/// </summary>
abstract class AbstractProductA
{
}

/// <summary>
/// Създаване на абстрактен клас за другия вид Абстрактен продукт
/// </summary>
abstract class AbstractProductB
{
    //създаваме метод, с който ще докажем за Демото връзката между
    //продуктите на отделните конкретни фабрики
    public abstract void Interact(AbstractProductA a);
}


/// <summary>
/// Създаваме клас за конкретен продукт от вид А
/// </summary>
class ProductA1 : AbstractProductA
{
}

/// <summary>
/// Създаваме клас за конкретен продукт от вид B
/// </summary>
class ProductB1 : AbstractProductB
{
    //дописваме метода, с който ще докажем за Демото връзката между
    //продуктите на отделните конкретни фабрики
    public override void Interact(AbstractProductA a)
    {
        Console.WriteLine(this.GetType().Name +
          " се произвежда в една фабрика заедно с " + a.GetType().Name);
    }
}

/// <summary>
/// Създаваме клас за друг вид конкретен продукт от вид А
/// </summary>
class ProductA2 : AbstractProductA
{
}

/// <summary>
/// Създаваме клас за друг вид конкретен продукт от вид B
/// </summary>
class ProductB2 : AbstractProductB
{
    //дописваме метода, с който ще докажем за Демото връзката между
    //продуктите на отделните конкретни фабрики
    public override void Interact(AbstractProductA a)
    {
        Console.WriteLine(this.GetType().Name +
          " се произвежда в една фабрика заедно с " + a.GetType().Name);
    }
}

/// <summary>
/// Създаваме специален клас, с който ще работи клиента
/// </summary>
class Client
{
    //скрити полета - абстрактни продукти
    private AbstractProductA _abstractProductA;
    private AbstractProductB _abstractProductB;

    //конструктор
    public Client(AbstractFactory factory)
    {
        _abstractProductB = factory.CreateProductB();
        _abstractProductA = factory.CreateProductA();
    }

    //метод за доказателството за връзката
    public void Run()
    {
        _abstractProductB.Interact(_abstractProductA);
    }
}
class Program
{
    static void Main()
    {
        //създавеме първата конкретна фабрика и
        //пускаме метода-доказателство за връзката между конкретните му обекти
        AbstractFactory factory1 = new ConcreteFactory1();
        Client client1 = new Client(factory1);
        client1.Run();

        //създавеме втората конкретна фабрика и
        //пускаме метода-доказателство за връзката между конкретните му обекти
        AbstractFactory factory2 = new ConcreteFactory2();
        Client client2 = new Client(factory2);
        client2.Run();

        //изчакване въвеждане на символ, за да не се скрие конзолата
        Console.ReadKey();
    }
}