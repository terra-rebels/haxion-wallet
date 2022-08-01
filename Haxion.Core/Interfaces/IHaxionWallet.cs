using Haxion.Core.BIP44.Interfaces;

namespace Haxion.Core.Interfaces
{
    public interface IHaxionWallet<out TWallet> where TWallet : IWallet, new()
    {
        /// <summary>
        /// Returns a wallet from only seed, no derivation 
        /// </summary>
        /// <returns></returns>
        TWallet GetMasterWallet();

        /// <summary>
        /// Returns the wallet at m/purpose'/coin_type'/{accountIndex}' (hardened)
        /// </summary>
        /// <param name="accountIndex"></param>
        /// <returns></returns>
        TWallet GetAccountWallet(uint accountIndex);

        /// <summary>
        /// Returns the account to access wallets at m/purpose'/coin_type'/{accountIndex}'/[0/1]
        /// 
        /// This level splits the key space into independent user identities, so the wallet never mixes the coins across different accounts.
        /// Users can use these accounts to organize the funds in the same fashion as bank accounts; for donation purposes (where all addresses are considered public), for saving purposes, for common expenses etc.
        /// Accounts are numbered from index 0 in sequentially increasing manner. This number is used as child index in BIP32 derivation.
        /// https://github.com/bitcoin/bips/blob/master/bip-0044.mediawiki#account
        /// </summary>
        /// <param name="accountIndex"></param>
        /// <returns></returns>
        IAccount<TWallet> GetAccount(uint accountIndex);
    }
}
