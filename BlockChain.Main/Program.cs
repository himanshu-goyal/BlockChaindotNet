using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockChain.ServiceLayer;
using BlockChain.Entities;
using BlockChain.Entities.Enums;

namespace BlockChain.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockChain.ServiceLayer.BlockChain blockChain = new ServiceLayer.BlockChain();
            Block block1 = new Block(30.00, "111", "Mouse", DateTime.Now, TransactionType.Borrow, 1, null);
            Block block2 = new Block(50.00, "222", "KeyBoard", DateTime.Now, TransactionType.cash, 2, block1);
            Block block3 = new Block(300.00, "333", "HP Laptop", DateTime.Now, TransactionType.cash, 3, block2);

            blockChain.AcceptBlock(block1);
            blockChain.AcceptBlock(block2);
            blockChain.AcceptBlock(block3);

            //verify the chain

            blockChain.verifyChain();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
