using Haxion.Core.Interfaces;
using Haxion.ETH.Models;
using NBitcoin;

namespace HaxionWalletExec
{
    class TerraWalletGenerationExecutable
    {
        // TODO NULS, NerveNetwork, Near, Chilliz, ZRX, Solana, Moonbeam, ThorChain
        public static void Main(string[] args)
        {
            Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
            IHaxionWallet<EthereumWallet> ethWallet = new EthereumHaxionWallet(mnemonic.ToString(), "");
            var address = ethWallet.GetAccount(0).GetExternalWallet(0);
        }
    }
}
