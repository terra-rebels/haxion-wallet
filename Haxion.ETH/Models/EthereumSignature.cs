using Haxion.Core.Models;
using Haxion.Core.Secp256k1.Models;

namespace Haxion.ETH.Models
{
    public class EthereumSignature : Secp256k1Signature
    {
        byte[] SignatureBytes => Helper.Concat(this.R, this.S);
        string SignatureString => Helper.ToHexString(this.SignatureBytes);
        public string SignatureHex => "0x" + SignatureString + new[] { (byte)(RecId + 27) }.ToHexString();

        public EthereumSignature(Signature signature) : base(signature) { }
    }
}
