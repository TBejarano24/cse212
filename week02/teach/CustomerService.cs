/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Normal execution. Add 10 customers to a max 10 customers queue and serve all 10 of them
        // Expected Result: 
        // Bob (1)  : idk1
        // Ed (2)  : idk2
        // Christie (3)  : idk3
        // Ado (4)  : idk4
        // Ham (5)  : idk5
        // Fabio (6)  : idk6
        // Sebastian (7)  : idk7
        // Ronald (8)  : idk8
        // Messi (9)  : idk9
        // Gurt (10)  : idk10
        Console.WriteLine("Test 1");

        int size = 10;
        var cs = new CustomerService(size);
        for (int i = 0; i < size; i++)
        {
            cs.AddNewCustomer();
        }
        for (int i = 0; i < size; i++)
        {
            cs.ServeCustomer();
            Console.WriteLine(cs);
        }


        // Defect(s) Found: ServeCustomer was deleting the item at index 0 before grabbing it, apparently provoking an ArgumentOutOfRangeException

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Overflow execution. Create a Customer service with max capacity of 10 and trying to add 11 customers, then serving 11 customers
        // Expected Result:
        // [Input]
        // Maximum Number of Customers in Queue.
        // Bob (1)  : idk1
        // Ed (2)  : idk2
        // Christie (3)  : idk3
        // Ado (4)  : idk4
        // Ham (5)  : idk5
        // Fabio (6)  : idk6
        // Sebastian (7)  : idk7
        // Ronald (8)  : idk8
        // Messi (9)  : idk9
        // Gurt (10)  : idk10
        // [return]
        Console.WriteLine("Test 2");

        var cs2 = new CustomerService(size);
        for (int i = 0; i < size + 1; i++)
        {
            cs2.AddNewCustomer();
        }
        for (int i = 0; i < size + 1; i++)
        {
            cs2.ServeCustomer();
            Console.WriteLine(cs2);
        }

        // Defect(s) Found: It allowed me to add customers beyond the max size
        // (After correction): Tried to serve customers when there were no more in queue

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No Customers in Queue.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}