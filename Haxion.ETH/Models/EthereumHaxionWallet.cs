using Haxion.Core.BIP44.Models;
using Haxion.Core.Interfaces;
using Haxion.Core.Secp256k1.Models;

namespace Haxion.ETH.Models
{
    public class EthereumHaxionWallet : HaxionWallet<EthereumWallet>, IHaxionWallet<EthereumWallet>
    {
        private static readonly CoinPath _path = M.BIP44.Ethereum;

        public EthereumHaxionWallet(string seed) : base(seed, _path)
        {
        }

        public EthereumHaxionWallet(string mnemonic, string passphrase) : base(mnemonic, passphrase, _path)
        {
        }
    }
}
