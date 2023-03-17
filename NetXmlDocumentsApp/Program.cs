using ExampleClassLibrary;

using System.Xml;


//List<User> users = new List<User>()
//{
//    new User("Joe", 34, new Address(){ City = "Moscow", Street = "Tverskaya"}),
//    new User("Tom", 41, new Address(){ City = "Orel", Street = "Lenina"}),
//};

var users = new List<User>();

XmlDocument doc = new XmlDocument();
doc.Load("myusers.xml");

XmlElement root = doc.DocumentElement!;

//if (root is not null)
//{
//    Console.WriteLine(root.Name);
//    foreach (XmlNode node in root.ChildNodes)
//    {
//        Console.WriteLine($"\t{node.Name}");
//        foreach (XmlAttribute attr in node.Attributes!)
//            Console.WriteLine($"\t\t{attr.Name} = {attr.Value}");
//        foreach (XmlNode subNode in node.ChildNodes)
//            Console.WriteLine($"\t\t{subNode.Name} : {subNode.InnerText}");
//    }
//}

if(root != null)
{
    foreach(XmlElement element in root)
    {
        User user = new User();
        foreach (XmlElement subElement in element)
        {
            switch (subElement.Name.ToLower())
            {
                case "name": user.Name = subElement.InnerText; break;
                case "age": user.Age = Int32.Parse(subElement.InnerText); break;
                case "address":
                    Address address = new();
                    foreach(XmlElement addrElement in  subElement)
                        switch(addrElement.Name.ToLower())
                        {
                            case "city": address.City = addrElement.InnerText; break;
                            case "street": address.Street = addrElement.InnerText; break;
                        }
                    user.Address = address;
                    break;
            }
        }
        users.Add(user);
    }
}

foreach(User user in users)
    Console.WriteLine($"Name: {user.Name} ({user.Age}), City: {user?.Address?.City}, Street: {user?.Address?.Street}");