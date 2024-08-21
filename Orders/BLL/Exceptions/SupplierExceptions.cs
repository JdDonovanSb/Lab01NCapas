using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SupplierExceptions : Exception
    {
        private SupplierExceptions(string message) : base(message)
        {
        }

        public static void ThrowSupplierAlreadyExistsException(string companyName)
        {
            throw new SupplierExceptions($"A supplier with the name already exists {companyName}.");
        }

        public static void ThrowInvalidSupplierDataException(string message)
        {
            throw new SupplierExceptions(message);
        }

        public static void ThrowInvalidSupplierIdException(int id)
        {
            throw new SupplierExceptions($"The supplier with id {id} was not found or doesn't exist.");
        }
    }
}
