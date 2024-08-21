using System;
using System.Collections.Generic;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL.Exceptions;

public class CustomerExceptions : Exception
{
    // you can more static methods here to throw other customer-related exceptions
    private CustomerExceptions(string message) : base(message)
    {
        //optional: Add constructor logic for logging or custom error handling
    }

    public static void ThrowCustomerAlreadyExistsException(string firstName, string lastName)
    {
        throw new CustomerExceptions($"A client with the name already exists{firstName} {lastName}.");
    }

    public static void ThrowInvalidCustomerDataException(string message)
    {
        throw new CustomerExceptions(message);
    }

    public static void ThrowInvalidCustomerIdException(int customerId)
    {
        throw new CustomerExceptions($"No customer found with ID {customerId}.");
    }

}