using BlockChainDotNet.BlockChainInterface;
using System;

namespace BlockChainDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockChain blockchain = new BlockChain();
            IBlock block1 = new Block(30.00, "111", "Mouse", DateTime.Now, PaymentType.Borrow, 1, null);
            IBlock block2 = new Block(50.00, "222", "KeyBoard", DateTime.Now, PaymentType.cash, 2, block1);
            IBlock block3 = new Block(300.00, "333", "HP Laptop", DateTime.Now, PaymentType.cash, 3, block2);

            blockchain.AcceptBlock(block1);
            blockchain.AcceptBlock(block2);
            blockchain.AcceptBlock(block3);

            //verify the chain

            blockchain.verifyChain();
            Console.WriteLine();
        }
    }
}
