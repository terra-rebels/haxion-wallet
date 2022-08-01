using Haxion.Core.Interfaces;
using Haxion.Core.Secp256k1.Models;

namespace Haxion.ETH.Models
{
    public class EthereumWallet : Wallet, IWallet
    {
        public EthereumWallet() { }

        public EthereumWallet(string privateKey) : base(privateKey) { }

        public new EthereumSignature Sign(byte[] message)
        {
            return new EthereumSignature(base.Sign(message));
        }

        protected override IAddressGenerator GetAddressGenerator()
        {
            return new EthWalletGenerator();
        }
    }
}
