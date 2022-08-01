using Haxion.Core.Interfaces;
using Haxion.Core.Secp256k1.Models;
using Haxion.TRON;

namespace Haxion.Tron.Models
{
    public class TronWallet : Wallet, IWallet
    {
        public TronWallet() { }

        public TronWallet(string privateKey) : base(privateKey) { }

        protected override IAddressGenerator GetAddressGenerator()
        {
            return new TronWalletGenerator();
        }
    }

    public class TronPublicWallet : PublicWallet, IPublicWallet
    {
        public TronPublicWallet() { }

        public TronPublicWallet(string publicKey) : base(publicKey) { }

        protected override IAddressGenerator GetAddressGenerator()
        {
            return new TronWalletGenerator();
        }
    }
}
