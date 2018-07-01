using BlockChain.Entities.Enums;
using BlockChain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockChain.Hashing;

namespace BlockChain.Entities
{
    public class Block : IBlock
    {

        public double itemPrice { get; set; }
        public string itemId { get; set; }
        public string itemName { get; set; }
        public DateTime transactionDate { get; set; }
        public TransactionType paymentType { get; set; }

        public int blockNumber { get; set; }
        public DateTime createDate { get; set; }
        public string blockHash { get; set; }
        public string previousBlockHash { get; set; }

        public IBlock NextBlock { get; set; }

        public Block(double ItemPrice,
         string ItemId,
         string ItemName,
         DateTime TransactionDate,
         TransactionType PaymentType,
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
            if (parent != null)
            {
                previousBlockHash = blockHash;
                NextBlock = this;
            }
            else
            {
                // Previous block is the genesis block.
                previousBlockHash = null;
            }

            blockHash = CalculateBlockHash(previousBlockHash);
        }

        public bool isValidChain(string preBlockHash, bool verbose)
        {
            bool isValid = true;

            // Is this a valid block and transaction
            string newBlockHash = CalculateBlockHash(preBlockHash);
            if (newBlockHash != blockHash)
            {
                isValid = false;
            }
            else
            {
                // Does the previous block hash match the latest previous block hash
                isValid |= preBlockHash == previousBlockHash;
            }

            PrintVerificationMessage(verbose, isValid);

            // Check the next block by passing in our newly calculated blockhash. This will be compared to the previous
            // hash in the next block. They should match for the chain to be valid.
            if (NextBlock != null)
            {
                return NextBlock.isValidChain(newBlockHash, verbose);
            }

            return isValid;
        }

        private void PrintVerificationMessage(bool verbose, bool isValid)
        {
            if (verbose)
            {
                if (!isValid)
                {
                    Console.WriteLine("Block Number " + blockNumber + " : FAILED VERIFICATION");
                }
                else
                {
                    Console.WriteLine("Block Number " + blockNumber + " : PASS VERIFICATION");
                }
            }
        }

    }
}
