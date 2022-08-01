using Haxion.Core.Interfaces;
using Haxion.Core.Secp256k1.Models;

namespace Haxion.Terra.Models
{
    public class TerraWallet : Wallet, IWallet
    {
        public TerraWallet() { }

        public TerraWallet(string privateKey) : base(privateKey) { }

        protected override IAddressGenerator GetAddressGenerator()
        {
            return new TerraWalletGenerator();
        }

        public string GetAddress()
        {
            return new TerraWalletGenerator().GenerateAddress(base.PublicKey.ToBytes());
        }
    }
}
