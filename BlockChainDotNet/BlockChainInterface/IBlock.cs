using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainDotNet.BlockChainInterface
{
    public interface IBlock
    {
        //business related data
        string itemPrice { get; set; }
        string itemId { get; set; }
        string itemName { get; set; }
        string transactionDate { get; set; }
        PaymentType paymentType { get; set; }

        //block related key items
        int blockNumber { get; set; }
        DateTime createDate { get; set; }
        string blockHash { get; set; }
        string previousBlockHash { get; set; }


        //Methods that each class should implement.
        string CalculateBlockHash(string previousBlockHash);
        void setBlockHash(IBlock parent);
        IBlock NextBlock { get; set; }
        bool isValidChain(string previousBlockHash, bool verbose);
    }
}
