using NBitcoin;
using Nethereum.Hex.HexConvertors.Extensions;

namespace Haxion.Core.Models
{
    /// <summary>
    /// Base class for different curves' hd wallets
    /// Creates & keeps BIP39 seed either from a seed or from mnemonic & passpharese
    /// </summary>
    public abstract class HaxionWalletBase
    {
        public string BIP39Seed { get; private set; }

        public HaxionWalletBase(string seed)
        {
            if (string.IsNullOrEmpty(seed)) throw new NullReferenceException(nameof(seed));

            BIP39Seed = seed;
        }

        public HaxionWalletBase(string mnemonic, string passphrase)
        {
            if (string.IsNullOrEmpty(mnemonic)) throw new NullReferenceException(nameof(mnemonic));

            var mneumonic = new Mnemonic(mnemonic);
            BIP39Seed = mneumonic.DeriveSeed(passphrase).ToHex();
        }
    }
}
