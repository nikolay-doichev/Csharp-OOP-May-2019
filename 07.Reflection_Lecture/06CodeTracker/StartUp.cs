using System.Linq;

[Author("Ventsi")]
class StartUp
{
    [Author("Gosho")]
    static void Main(string[] args)
    {
        var tp = typeof(StartUp);

        var atributes = tp.CustomAttributes;

        foreach (var attr in atributes)
        {
            if (attr.AttributeType == typeof(AuthorAttribute))
            {
                var name = attr.ConstructorArguments.FirstOrDefault().Value;
                System.Console.WriteLine(name);
            }
        }
        var methods = tp.GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

        foreach (var method in methods)
        {
            var attributesMethods = method.CustomAttributes;

            foreach (var attr in attributesMethods)
            {
                if (attr.AttributeType == typeof(AuthorAttribute))
                {
                    var name = attr.ConstructorArguments.FirstOrDefault().Value;
                    System.Console.WriteLine(name);
                }
            }
        }
    }
}
