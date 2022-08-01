using Haxion.Core.BIP44.Interfaces;
using Haxion.Core.Interfaces;
using NBitcoin;

namespace Haxion.Core.Secp256
{
    public class AccountSecpBase<TWallet> : IAccount<TWallet> where TWallet : IWallet, new()
    {
        private readonly ExtKey _masterKey;
        private readonly ExtKey _externalChain;
        private readonly ExtKey _internalChain;

        /// <summary>
        /// Generate for 'Main' network by default. 
        /// If you want to generate for testnet or regtest, use the overload
        /// </summary>
        /// <param name="accountMasterKey"></param>
        /// <param name="accountIndex">Only for information, isn't being used for derivation</param>
        [Obsolete("Use 'AccountHaxionWalletSecpBase(string accountMasterKey, uint accountIndex, Network network)'")]
        public AccountSecpBase(string accountMasterKey, uint accountIndex)
        {
            BitcoinExtKey bitcoinExtKey = new BitcoinExtKey(accountMasterKey, Network.Main);
            _masterKey = bitcoinExtKey.ExtKey;

            var externalKeyPath = new KeyPath("0");
            _externalChain = _masterKey.Derive(externalKeyPath);

            var internalKeyPath = new KeyPath("1");
            _internalChain = _masterKey.Derive(internalKeyPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountMasterKey"></param>
        /// <param name="network"></param>
        public AccountSecpBase(string accountMasterKey, Network network)
        {
            BitcoinExtKey bitcoinExtKey = new BitcoinExtKey(accountMasterKey, network);
            _masterKey = bitcoinExtKey.ExtKey;

            var externalKeyPath = new KeyPath("0");
            _externalChain = _masterKey.Derive(externalKeyPath);

            var internalKeyPath = new KeyPath("1");
            _internalChain = _masterKey.Derive(internalKeyPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountMasterKey"></param>
        public AccountSecpBase(ExtKey accountMasterKey)
        {
            _masterKey = accountMasterKey;

            var externalKeyPath = new KeyPath("0");
            _externalChain = _masterKey.Derive(externalKeyPath);

            var internalKeyPath = new KeyPath("1");
            _internalChain = _masterKey.Derive(internalKeyPath);
        }

        TWallet IAccount<TWallet>.GetInternalWallet(uint addressIndex)
        {
            return GetWallet(addressIndex, isInternal: true);
        }

        TWallet IAccount<TWallet>.GetExternalWallet(uint addressIndex)
        {
            return GetWallet(addressIndex, isInternal: false);
        }

        private TWallet GetWallet(uint addressIndex, bool isInternal)
        {
            var extKey = isInternal ? _internalChain.Derive(addressIndex) : _externalChain.Derive(addressIndex);

            return new TWallet()
            {
                PrivateKeyBytes = extKey.PrivateKey.ToBytes()
            };
        }

        string IAccount<TWallet>.GetWif()
        {
            return this._masterKey.GetWif(Network.Main).ToWif();
        }
    }
}
