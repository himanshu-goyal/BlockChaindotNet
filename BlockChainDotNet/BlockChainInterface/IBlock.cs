using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainDotNet.BlockChainInterface
{
    public interface IBlock
    {
        //business related transaction data
        double itemPrice { get; set; }
        string itemId { get; set; }
        string itemName { get; set; }
        DateTime transactionDate { get; set; }
        PaymentType paymentType { get; set; }

        //block related key items called as blockheader
        int blockNumber { get; set; }
        DateTime createDate { get; set; }
        string blockHash { get; }
        string previousBlockHash { get; set; }
        IBlock NextBlock { get; set; }

        //Methods that class should implement.
        string CalculateBlockHash(string previousBlockHash);
        void setBlockHash(IBlock parent);
        
        bool isValidChain(string previousBlockHash, bool verbose);
    }
}
