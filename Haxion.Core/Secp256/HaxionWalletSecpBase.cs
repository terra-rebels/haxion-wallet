using Haxion.Core.BIP44.Interfaces;
using Haxion.Core.BIP44.Models;
using Haxion.Core.Interfaces;
using Haxion.Core.Models;
using NBitcoin;

namespace Haxion.Core.Secp256
{
    /// <summary>
    /// Base class for Secp based HD wallets
    /// </summary>
    /// <typeparam name="TWallet"></typeparam>
    public abstract class HaxionWalletSecpBase<TWallet> : HaxionWalletBase, IHaxionWallet<TWallet> where TWallet : IWallet, new()
    {
        readonly ExtKey _masterKey;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="words">BIP39 Mnemonic</param>
        /// <param name="passphrase">BIP39 Passphrase (optional)</param>
        /// <param name="path">Derivation Path (e.g. m/44'/0')</param>
        /// <returns></returns>
        public HaxionWalletSecpBase(string words, string passphrase, CoinPath path) : base(words, passphrase)
        {
            var masterKeyPath = new KeyPath(path.ToString());
            _masterKey = new ExtKey(base.BIP39Seed).Derive(masterKeyPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seed">BIP39 Seed</param>
        /// <param name="path">Derivation Path (e.g. m/44'/0')</param>
        /// <returns></returns>
        public HaxionWalletSecpBase(string seed, CoinPath path) : base(seed)
        {
            var masterKeyPath = new KeyPath(path.ToString());
            _masterKey = new ExtKey(base.BIP39Seed).Derive(masterKeyPath);
        }

        /// <summary>
        /// Returns a wallet from only seed, no derivation 
        /// </summary>
        /// <returns></returns>
        TWallet IHaxionWallet<TWallet>.GetMasterWallet()
        {
            var masterKey = new ExtKey(base.BIP39Seed);

            var privateKey = masterKey.PrivateKey.ToBytes();
            return new TWallet()
            {
                PrivateKeyBytes = privateKey
            };
        }

        /// <summary>
        /// Returns the wallet at m/purpose'/coin_type'/{accountIndex}' (hardened)
        /// </summary>
        /// <param name="accountIndex"></param>
        /// <returns></returns>
        TWallet IHaxionWallet<TWallet>.GetAccountWallet(uint accountIndex)
        {
            var externalKeyPath = new KeyPath($"{accountIndex}'");
            var externalMasterKey = _masterKey.Derive(externalKeyPath);

            return new TWallet()
            {
                PrivateKeyBytes = externalMasterKey.PrivateKey.ToBytes()
            };
        }

        /// <summary>
        /// Returns the [accountIndex]th account to access wallets at m/purpose'/coin_type'/{accountIndex}'/[0/1]
        /// </summary>
        /// <param name="accountIndex"></param>
        /// <returns></returns>
        IAccount<TWallet> IHaxionWallet<TWallet>.GetAccount(uint accountIndex)
        {
            var externalKeyPath = new KeyPath($"{accountIndex}'");
            var masterKey = _masterKey.Derive(externalKeyPath);

            return new AccountSecpBase<TWallet>(masterKey);
        }

        /// <summary>
        /// Generates an account from master. Doesn't derive new path by accountIndexInfo
        /// </summary>
        /// <param name="accountMasterKey">Used to generate wallet</param>
        /// <param name="accountIndexInfo">Used only to store information</param>
        /// <returns></returns>
        [Obsolete("'accountIndexInfo' is not being used, used the overloads.")]
        public static IAccount<TWallet> GetAccountFromMasterKey(string accountMasterKey, uint accountIndexInfo)
        {
            IAccount<TWallet> accountHDWallet = new AccountSecpBase<TWallet>(accountMasterKey, accountIndexInfo);
            return accountHDWallet;
        }

        /// <summary>
        /// Generates an account from master for Mainnet.
        /// </summary>
        /// <param name="accountMasterKey">Used to generate wallet</param>
        /// <returns></returns>
        public static IAccount<TWallet> GetAccountFromMasterKey(string accountMasterKey)
        {
            IAccount<TWallet> accountHDWallet = new AccountSecpBase<TWallet>(accountMasterKey, Network.Main);
            return accountHDWallet;
        }

        /// <summary>
        /// Generates an account from master for network: [network].
        /// </summary>
        /// <param name="accountMasterKey">Used to generate wallet</param>
        /// <param name="network"></param>
        /// <returns></returns>
        public static IAccount<TWallet> GetAccountFromMasterKey(string accountMasterKey, Network network)
        {
            IAccount<TWallet> accountHDWallet = new AccountSecpBase<TWallet>(accountMasterKey, network);
            return accountHDWallet;
        }
    }
}
