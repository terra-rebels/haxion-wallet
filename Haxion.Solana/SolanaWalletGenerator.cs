using Solnet.Wallet;
using Solnet.Wallet.Bip39;

namespace Haxion.Solana
{
    public class SolanaWalletGenerator
    {
        public Wallet GenerateWallet ()
        {
            var mnemonic = new Mnemonic(WordList.English, WordCount.TwentyFour);
            return new Wallet(mnemonic);
        }
    }
}