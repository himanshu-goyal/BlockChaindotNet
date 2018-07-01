using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockChain.Entities.Enums;

namespace BlockChain.Entities.Interfaces
{
    public interface IBlock
    {

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
