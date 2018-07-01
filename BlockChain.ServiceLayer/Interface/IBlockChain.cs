using BlockChain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.ServiceLayer.Interface
{
    public interface IBlockChain
    {
        void AcceptBlock(IBlock block);
        void verifyChain();
    }
}
