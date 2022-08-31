using Haxion.Core.Interfaces;
using Haxion.Core.Secp256k1.Models;
using Haxion.NULS;

namespace Haxion.Tron.Models
{
    public class NulsWallet : Wallet, IWallet
    {
        public NulsWallet() { }

        public NulsWallet(string privateKey) : base(privateKey) { }

        protected override IAddressGenerator GetAddressGenerator()
        {
            return new NulsWalletGenerator();
        }
    }

    public class NulsPublicWallet : PublicWallet, IPublicWallet
    {
        public NulsPublicWallet() { }

        public NulsPublicWallet(string publicKey) : base(publicKey) { }

        protected override IAddressGenerator GetAddressGenerator()
        {
            return new NulsWalletGenerator();
        }
    }
}
