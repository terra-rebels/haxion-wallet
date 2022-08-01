using Haxion.Core.Models;

namespace Haxion.Core.Interfaces
{
    public interface IWallet
    {
        string Address { get; }

        Signature Sign(byte[] message);

        byte[] PrivateKeyBytes { get; set; }

        byte[] PublicKeyBytes { get; }

        bool Verify(byte[] message, Signature sig);
    }
}
