using BlockChain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Entities
{
    public class TransactionEntities
    {
        double itemPrice { get; set; }
        string itemId { get; set; }
        string itemName { get; set; }
        DateTime transactionDate { get; set; }
        TransactionType paymentType { get; set; }

        //block related key items called as blockheader
        int blockNumber { get; set; }
        DateTime createDate { get; set; }
        string blockHash { get; }
        string previousBlockHash { get; set; }
    }
}
