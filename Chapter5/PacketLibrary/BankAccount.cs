using System;
using System.Collections.Generic;
using System.Text;

namespace PacketLibrary
{
    public class BankAccount
    {
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public static decimal InterestRate; //shared member
    }
}
