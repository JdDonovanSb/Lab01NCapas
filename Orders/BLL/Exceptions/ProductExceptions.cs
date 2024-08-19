using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductExceptions : Exception
    {
        private ProductExceptions(string message) : base(message)
        {
        }

        public static void ThrowProductAlreadyExistsException(string productName)
        {
            throw new ProductExceptions($"A product with the name already exists {productName}.");
        }

        public static void ThrowInvalidProductDataException(string message)
        {
            throw new ProductExceptions(message);
        }

        public static void ThrowInvalidProductIdException(int id)
        {
            throw new ProductExceptions($"The product with id {id} was not found or dont exist");
        }
    }
}
