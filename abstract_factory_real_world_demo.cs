using System;

/// <summary>
/// Създаване на интефейс за Фабрика за продукти
/// </summary>
interface ProductFactory
{
    //абстрактните методи, които ще ги има и в конкретните фабрики
    //и с които ще създаваме различни видове продукти
    public abstract CosmeticProduct CreateHairProduct();
    public abstract CosmeticProduct CreateSkinProduct();
    public abstract CosmeticProduct CreateFaceProduct();
}


/// <summary>
/// Създаване на фабрика за продукти с био състав
/// </summary>
class BioFactory : ProductFactory
{
    //задължително имплементираме методите от интерфейса
    public CosmeticProduct CreateHairProduct()
    {
        //създаваме продукт за коса с био продукти
        return new HairProduct("продуктът е направен с био продукти");
    }
    public CosmeticProduct CreateSkinProduct()
    {
        //създаваме продукт за кожа с био продукти
        return new SkinProduct("продуктът е направен с био продукти");
    }
    public CosmeticProduct CreateFaceProduct()
    {
        //създаваме продукт за лице с био продукти
        return new FaceProduct("продуктът е направен с био продукти");
    }
}

/// <summary>
/// Създаване на фабрика за продукти с рециклируема опаковка
/// </summary>
class RecycablePackagingFactory : ProductFactory
{
    //задължително имплементираме методите от интерфейса
    public CosmeticProduct CreateHairProduct()
    {
        //създаваме продукт за коса с рециклируема опаковка
        return new HairProduct("продуктът е с рециклируема опаковка");
    }
    public CosmeticProduct CreateSkinProduct()
    {
        //създаваме продукт за кожа с рециклируема опаковка
        return new SkinProduct("продуктът е с рециклируема опаковка");
    }
    public CosmeticProduct CreateFaceProduct()
    {
        //създаваме продукт за лице с рециклируема опаковка
        return new FaceProduct("продуктът е с рециклируема опаковка");
    }
}
/// <summary>
/// Създаване на фабрика за продукти, които не са тествани върху животни
/// </summary>
class NoTestOnAnimalsFactory : ProductFactory
{
    //задължително имплементираме методите от интерфейса
    public CosmeticProduct CreateHairProduct()
    {
        //създаваме продукт за коса, който не е бил тестван върху животни
        return new HairProduct("продуктът не е тестван върху животни");
    }
    public CosmeticProduct CreateSkinProduct()
    {
        //създаваме продукт за кожа, който не е бил тестван върху животни
        return new SkinProduct("продуктът не е тестван върху животни");
    }
    public CosmeticProduct CreateFaceProduct()
    {
        //създаваме продукт за лице, който не е бил тестван върху животни
        return new FaceProduct("продуктът не е тестван върху животни");
    }
}

/// <summary>
/// Създаване на абстрактен клас за продукти
/// </summary>
abstract class CosmeticProduct
{
    //свойство за предназначението на продукта
    private string Usage { get; set; }

    //свойство за вида на продукта
    private string Type { get; set; }
    public CosmeticProduct(string usage, string type)
    {
        this.Usage = usage;
        this.Type = type;    
    }
    public override string ToString()
    {
        return $"Продуктът е за {this.Usage} и {this.Type}";
    }
}

/// <summary>
/// Създаваме клас за продукт за коса
/// </summary>
class HairProduct : CosmeticProduct
{
    public HairProduct(string type) : base("КОСА", type)
    { 
    }
}

/// <summary>
/// Създаваме клас за продукт за кожа
/// </summary>
class SkinProduct : CosmeticProduct
{
    public SkinProduct(string type) : base("КОЖА", type)
    {
    }
}

/// <summary>
/// Създаваме клас за продукт за лице
/// </summary>
class FaceProduct : CosmeticProduct
{
    public FaceProduct(string type) : base("ЛИЦЕ", type)
    {
    }
}

/// <summary>
/// Създаваме специален клас, с който ще работи клиента
/// </summary>
class Client
{
    //скрити полета - различни продукти
    private CosmeticProduct _HairProduct;
    private CosmeticProduct _SkinProduct;
    private CosmeticProduct _FaceProduct;

    //конструктор за създаване на фабрика с продукти
    public Client(ProductFactory factory)
    {
        _HairProduct = factory.CreateHairProduct();
        _SkinProduct = factory.CreateSkinProduct();
        _FaceProduct = factory.CreateFaceProduct();
    }

    //метод за изкарване информация за продуктите от фабрика
    public void ShowInfo()
    {
        Console.WriteLine(_HairProduct);
        Console.WriteLine(_SkinProduct);
        Console.WriteLine(_FaceProduct);
    }
}
class Program
{
    static void Main()
    {
        // създаваме фабрика за БИО продукти
        Console.WriteLine("Първи вид продукти");        
        ProductFactory factoryBIO = new BioFactory();
        Client client1 = new Client(factoryBIO);
        client1.ShowInfo();

        //създавеме фабрика за продукти с рециклируема опаковка
        Console.WriteLine("\nВтори вид продукти");        
        ProductFactory factoryRecycablePackage = new RecycablePackagingFactory();
        Client client2 = new Client(factoryRecycablePackage);
        client2.ShowInfo();

        //създавеме фабрика за продукти, които не са били тествани върху животни
        Console.WriteLine("\nТрети вид продукти");
        ProductFactory factoryNoTestsOnAnimals = new NoTestOnAnimalsFactory();
        Client client3 = new Client(factoryNoTestsOnAnimals);
        client3.ShowInfo();

        //изчакване въвеждане на символ, за да не се скрие конзолата
        Console.ReadKey();
    }
}