using Haxion.Core.Interfaces;
using NBitcoin;

namespace Haxion.NULS
{
    public class NulsWalletGenerator : IAddressGenerator
    {
        string IAddressGenerator.GenerateAddress(byte[] pubKeyBytes)
        {
            return GenerateAddress(new PubKey(pubKeyBytes));
        }

        private string GenerateAddress(PubKey pubKey)
        {
            return "";
        }
    }
}
