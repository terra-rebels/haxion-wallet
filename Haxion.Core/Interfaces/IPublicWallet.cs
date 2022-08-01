using Haxion.Core.Models;

namespace Haxion.Core.Interfaces
{
    public interface IPublicWallet
    {
        string Address { get; }

        byte[] PublicKeyBytes { get; set; }

        bool Verify(byte[] message, Signature sig);
    }
}
