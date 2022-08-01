using Haxion.Core.BIP44.Models;
using Haxion.Core.Interfaces;
using Haxion.Core.Secp256;

namespace Haxion.Core.Secp256k1.Models
{
    public abstract class HaxionWallet<TWallet> : HaxionWalletSecpBase<TWallet>, IHaxionWallet<TWallet> where TWallet : Wallet, new()
    {
        public HaxionWallet(string mnemonic, string passphrase, CoinPath path) : base(mnemonic, passphrase, path)
        {

        }

        public HaxionWallet(string seed, CoinPath path) : base(seed, path)
        {

        }
    }
}
