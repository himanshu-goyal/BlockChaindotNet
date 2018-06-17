using BlockChainDotNet.BlockChainInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainDotNet
{
    public class Block : IBlock
    {
        //transaction body
        public double itemPrice { get; set; }
        public string itemId { get; set; }
        public string itemName { get; set; }
        public DateTime transactionDate { get; set; }
        public PaymentType paymentType { get; set; }

        //Block header
        public int blockNumber { get; set; }
        public DateTime createDate { get; set; }
        public string blockHash { get; private set; }
        public string previousBlockHash { get; set; }
        public IBlock NextBlock { get; set; }

        public Block(double ItemPrice,
             string ItemId,
             string ItemName,
             DateTime TransactionDate,
             PaymentType PaymentType,
             int BlockNumber,
             IBlock Parent)
        {
            itemPrice = ItemPrice;
            itemId = ItemId;
            itemName = ItemName;
            transactionDate = TransactionDate;
            paymentType = PaymentType;
            blockNumber = BlockNumber;
            createDate = DateTime.Now;
            setBlockHash(Parent);
        }

        public string CalculateBlockHash(string previousBlockHash)
        {
            string transactionData = itemPrice + "/" + itemId + "/" + itemName + "/" + transactionDate + "/" + paymentType;
            string blockData = blockNumber + "=" + createDate.ToString() + "=" + previousBlockHash;
            string totalBlockdata = transactionData + "{}" + blockData;
            return Convert.ToBase64String(Hashing.Hashing.ComputeHashSha256(Encoding.UTF8.GetBytes(totalBlockdata)));
        }

        public void setBlockHash(IBlock parent)
        {
            throw new NotImplementedException();
        }
        public bool isValidChain(string previousBlockHash, bool verbose)
        {
            throw new NotImplementedException();
        }

    }
}
