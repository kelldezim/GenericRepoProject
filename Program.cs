using System;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemAdded<Employee> itemAdded = new ItemAdded<Employee>(EmployeeAdded);
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext(), itemAdded);
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);


            Console.ReadKey();
        }

        private static void EmployeeAdded(Employee employee)
        {
            Console.WriteLine($"Employee added => {employee.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            Manager saraManager = new Manager { FirstName = "Sarah" };
            var saraMangerCopy = saraManager.Copy();
            if(saraMangerCopy != null)
            {
                saraMangerCopy.FirstName += "_Copy";
                managerRepository.Add(saraMangerCopy);
            }

            managerRepository.Add(saraManager);
            managerRepository.Add(new Manager { FirstName = "Henry" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(SqlRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with id 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee { FirstName = "Julia" },
                new Employee { FirstName = "Anna" },
                new Employee { FirstName = "Thomas" },
            };
            employeeRepository.AddBatch(employees);
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { Name = "PluralSight" },
                new Organization { Name = "Globomantics" },
                new Organization { Name = "Random" }
            };
            organizationRepository.AddBatch(organizations);
        }
    }
}
