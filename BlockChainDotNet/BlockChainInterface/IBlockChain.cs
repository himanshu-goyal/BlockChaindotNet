using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainDotNet.BlockChainInterface
{
    public interface IBlockChain
    {
        void AcceptBlock(IBlock block);
        void verifyChain();
    }
}
