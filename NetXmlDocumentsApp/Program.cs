using ExampleClassLibrary;
using System.Xml;

List<User> users = new List<User>()
{
    new User("Joe", 34, new Address(){ City = "Moscow", Street = "Tverskaya"}),
    new User("Tom", 41, new Address(){ City = "Orel", Street = "Lenina"}),
};

XmlDocument doc = new XmlDocument();
doc.Load("myusers.xml");

XmlElement root = doc.DocumentElement!;
if (root is not null)
{
    Console.WriteLine(root.Name);
    foreach (XmlNode node in root.ChildNodes)
    {
        Console.WriteLine($"\t{node.Name}");
        foreach (XmlAttribute attr in node.Attributes)
            Console.WriteLine($"\t\t{attr.Name} = {attr.Value}");
    }
}