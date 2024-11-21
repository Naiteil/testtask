namespace HashApp
{
    public class Program
    {
        private static readonly ContactDirectory _directory = new ContactDirectory();

        public static void Main(string[] args)
        {
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Edit");
            Console.WriteLine("3 - Remove");
            Console.WriteLine("4 - Find by Name");
            Console.WriteLine("5 - All");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Choose: ");
                string input = Console.ReadLine();
                if (input == "e")
                {
                    return;
                }

                switch (input)
                {
                    case "1":
                        Add();
                        break;
                    case "2":
                        Edit();
                        break;
                    case "3":
                        Remove();
                        break;
                    case "4":
                        FindByName();
                        break;
                    case "5":
                        All();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

                Console.WriteLine();
            }
        }

        public static void Add()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            _directory.AddContact(name, phone);
        }

        public static void Edit()
        {
            Console.Write("Old Name: ");
            string oldName = Console.ReadLine();
            Console.Write("New Name: ");
            string name = Console.ReadLine();
            Console.Write("New Phone: ");
            string phone = Console.ReadLine();

            _directory.EditContact(oldName, name, phone);
        }

        public static void Remove()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            _directory.RemoveContact(name);
        }

        public static void FindByName()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Contact contact = _directory.FindByName(name);
            if (contact is null)
            {
                Console.WriteLine("Not found");
                return;
            }

            Console.WriteLine(contact.Display());
        }

        public static void All()
        {
            List<Contact> contacts = _directory.GetContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts");
                return;
            }

            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.Display());
            }
        }
    }

    public class Contact
    {
        public Contact(string fullName, string phone)
        {
            FullName = fullName;
            Phone = phone;
        }

        public string FullName { get; }

        public string Phone { get; }

        public string Display()
        {
            return $"{FullName}: {Phone}";
        }
    }
    public class ContactDirectory
    {
        private readonly Dictionary<int, List<Contact>> _directory;

        public ContactDirectory()
        {
            _directory = new Dictionary<int, List<Contact>>();
        }

        private int GenerateHashKey(string fullName)
        {
            int hash = 0;
            foreach (char c in fullName)
            {
                hash += c;
            }
            return hash;
        }

        public void AddContact(string fullName, string phone)
        {
            int hashKey = GenerateHashKey(fullName);
            if (!_directory.ContainsKey(hashKey))
            {
                _directory[hashKey] = new List<Contact>();
            }

            _directory[hashKey].Add(new Contact(fullName, phone));
        }

        public void RemoveContact(string fullName)
        {
            int hashKey = GenerateHashKey(fullName);
            if (!_directory.ContainsKey(hashKey))
            {
                return;
            }

            _directory[hashKey].RemoveAll(c => c.FullName == fullName);
            if (_directory[hashKey].Count == 0)
            {
                _directory.Remove(hashKey);
            }
        }

        public void EditContact(string oldFullName, string newFullName, string newPhone)
        {
            int oldHashKey = GenerateHashKey(oldFullName);
            if (!_directory.ContainsKey(oldHashKey))
            {
                return;
            }

            Contact contact = _directory[oldHashKey].FirstOrDefault(c => c.FullName == oldFullName);
            if (contact is null)
            {
                return;
            }

            RemoveContact(contact.FullName);
            AddContact(newFullName, newPhone);
        }

        public Contact FindByName(string fullName)
        {
            int hashKey = GenerateHashKey(fullName);
            if (!_directory.ContainsKey(hashKey))
            {
                return null;
            }

            Contact contact = _directory[hashKey].FirstOrDefault(c => c.FullName == fullName);
            if (contact is null)
            {
                return null;
            }

            return contact;
        }

        public List<Contact> GetContacts()
        {
            return _directory.SelectMany(d => d.Value).ToList();
        }
    }
}