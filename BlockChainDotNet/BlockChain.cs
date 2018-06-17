using BlockChainDotNet.BlockChainInterface;
using System;
using System.Collections.Generic;

namespace BlockChainDotNet
{
    public class BlockChain: IBlockChain
    {
        public IBlock CurrentBlock { get; private set; }
        public IBlock HeadBlock { get; private set; }

        public List<IBlock> Blocks { get; }

        public BlockChain()
        {
            Blocks = new List<IBlock>();
        }

        public void AcceptBlock(IBlock block)
        {
            // This is the first block, so make it the genesis block.
            if (HeadBlock == null)
            {
                HeadBlock = block;
                HeadBlock.previousBlockHash = null;
            }

            CurrentBlock = block;
            Blocks.Add(block);
        }

        public void verifyChain()
        {
            if (HeadBlock == null)
            {
                throw new InvalidOperationException("Genesis block not set.");
            }

            bool isValid = HeadBlock.isValidChain(null, true);

            if (isValid)
            {
                Console.WriteLine("Blockchain integrity intact.");
            }
            else
            {
                Console.WriteLine("Blockchain integrity NOT intact.");
            }
        }

    }
}