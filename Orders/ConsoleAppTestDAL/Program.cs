// See https://aka.ms/new-console-template for more information
using DAL;
using DAL.Models;
using System.Linq.Expressions;


//CreateAsync().GetAwaiter().GetResult();
//RetreiveAsync().GetAwaiter().GetResult();
UpdateAsync().GetAwaiter().GetResult();
static async Task CreateAsync()
{
    //Add Customer
    Customer customer = new Customer(){
        FirstName = "Andres",
        LastName = "Espinosa",
        City = "Bogota",
        Country = "Colombia",
        Phone = "12345678900"
    };
    
    using(var repository = RepositoryFactory.CreateRepository())
    {
        try
        {
            var createCustomer = await repository.CreateAsync(customer);
            Console.WriteLine($"Add Customer: {createCustomer.LastName} {createCustomer.FirstName}");
        }
        catch ( Exception ex )
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

static async Task RetreiveAsync ()
{
    using (var repository = RepositoryFactory.CreateRepository()) 
    {
        try
        {
            Expression<Func<Customer, bool>> criteria = c => c.FirstName == "Andres" && c.LastName == "Espinosa";
            var customer = await repository.RetreiveAsync(criteria);
            if (customer == null)
            {
                Console.WriteLine($"Retrived Customer: {customer.FirstName} \t{customer.LastName} \tCity: {customer.City} \tCountry: {customer.Country}");
            }
            else
            {
                Console.WriteLine("Customer not exist");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

static async Task UpdateAsync ()
{
    //Supuesto existe el objeto a modificar

    using (var repository = RepositoryFactory.CreateRepository())
    {
        var customerToUpdate = await repository.RetreiveAsync<Customer>(Customer => Customer.Id == 78);
        if (customerToUpdate != null)
        {
            customerToUpdate.FirstName = "Liu";
            customerToUpdate.LastName = "Wong";
            customerToUpdate.City = "Toronto";
            customerToUpdate.Country = "Canáda";
            customerToUpdate.Phone = "+1437 321456987";
        }
        try
        {
            bool updated = await repository.UpdateAsync(customerToUpdate);
            if (updated)
            {
                Console.WriteLine("The customer has been update succesfully!");
            }
            else
            {
                Console.WriteLine("Customer update failed");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}