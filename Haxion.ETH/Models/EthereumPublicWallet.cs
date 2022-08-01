using Haxion.Core.Interfaces;
using Haxion.Core.Secp256k1.Models;

namespace Haxion.ETH.Models
{
    public class EthereumPublicWallet : PublicWallet, IPublicWallet
    {
        public EthereumPublicWallet() { }
        public EthereumPublicWallet(string publicKey) : base(publicKey: publicKey) { }
        public EthereumPublicWallet(byte[] publicKeyBytes) : base(publicKeyBytes: publicKeyBytes) { }

        protected override IAddressGenerator GetAddressGenerator()
        {
            return new EthWalletGenerator();
        }
    }
}
