using Haxion.Core.BIP44.Models;
using Haxion.Core.Secp256k1.Models;

namespace Haxion.Tron.Models
{
    public class TronHaxionWallet : HaxionWallet<TronWallet>
    {
        private static readonly CoinPath _path = M.BIP44.CreateCoinPath(CoinType.Tron);

        public TronHaxionWallet(string mnemonic, string passphrase = "") : base(mnemonic, passphrase, _path) { }
    }
}
