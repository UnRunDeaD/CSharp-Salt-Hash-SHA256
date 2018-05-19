using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSaltHashSHA256
{
    class Program
    {
        static void Main(string[] args)
        {
            //first you create a Salt with a Length
            string salt = Crypto.CreateSalt(25);
            //second Step, Hash the Password with your Salt
            string hashpassword = Crypto.HashToSHA256("password", salt);

            //to Check if the Users enter is correct you need to Hash his Entry with the Salt and check the Equal of the saved and new createt Hash
        }
    }
}
