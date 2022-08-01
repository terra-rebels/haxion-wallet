using Haxion.Core.BIP44.Models;
using Haxion.Core.Secp256k1.Models;

namespace Haxion.Terra.Models
{
    public class TerraHaxionWallet : HaxionWallet<TerraWallet>
    {
        private static readonly CoinPath _path = M.BIP44.CreateCoinPath(CoinType.Terra);

        public TerraHaxionWallet(string mnemonic, string passphrase = "") : base(mnemonic, passphrase, _path) { }
    }
}
