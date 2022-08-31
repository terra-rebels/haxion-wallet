using Haxion.Core.BIP44.Models;
using Haxion.Core.Secp256k1.Models;

namespace Haxion.Tron.Models
{
    public class NulsHaxionWallet : HaxionWallet<NulsWallet>
    {
        private static readonly CoinPath _path = M.BIP44.CreateCoinPath(CoinType.Nuls);

        public NulsHaxionWallet(string mnemonic, string passphrase = "") : base(mnemonic, passphrase, _path) { }
    }
}
