using Haxion.Core;
using Haxion.Core.Interfaces;
using Haxion.Core.Models;

namespace Haxion.Terra
{
    public class TerraWalletGenerator : IAddressGenerator
    {
        string DefaultHRP { get; set; } = "terra";

        string IAddressGenerator.GenerateAddress(byte[] pubKeyBytes)
        {
            return $"{GetBech32Address(pubKeyBytes, DefaultHRP)}";
        }

        private string GetBech32Address(byte[] pubKeyBytes, string hrp)
        {
            var addr = addressFromPublicKey(pubKeyBytes);
            return Bech32Engine.Encode(hrp, addr);
        }

        public string GenerateAddress(byte[] pubKeyBytes)
        {
            return $"{GetBech32Address(pubKeyBytes, DefaultHRP)}";
        }

        private byte[] addressFromPublicKey(byte[] pubKeyBytes)
        {
            if (pubKeyBytes.Length == 65)
            {
                throw new NotImplementedException();
            }

            if (pubKeyBytes.Length == 33)
            {
                var sha256 = NBitcoin.Crypto.Hashes.SHA256(pubKeyBytes);
                var ripesha = NBitcoin.Crypto.Hashes.RIPEMD160(sha256, sha256.Length);
                return ripesha;
            }

            throw new NotSupportedException();
        }
    }
}