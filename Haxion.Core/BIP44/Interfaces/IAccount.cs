using Haxion.Core.Interfaces;

namespace Haxion.Core.BIP44.Interfaces
{
    public interface IAccount<out TWallet> where TWallet : IWallet, new()
    {
        TWallet GetInternalWallet(uint addressIndex);
        TWallet GetExternalWallet(uint addressIndex);
        string GetWif();
    }
}
