using Haxion.Core.Models;
using NBitcoin.Crypto;

namespace Haxion.Core.Secp256k1.Models
{
    public class Secp256k1Signature : Signature
    {
        public bool TryGetECDSASignature(out ECDSASignature signature) => ECDSASignature.TryParseFromCompact(this.ToCompact(), out signature);

        public Secp256k1Signature(Signature signature)
        {
            this.R = signature.R;
            this.S = signature.S;
            this.RecId = signature.RecId;
        }
    }
}
