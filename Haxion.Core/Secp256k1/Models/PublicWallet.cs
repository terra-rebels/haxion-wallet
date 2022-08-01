using Haxion.Core.Interfaces;
using Haxion.Core.Models;
using NBitcoin;
using NBitcoin.Crypto;

namespace Haxion.Core.Secp256k1.Models
{
    public abstract class PublicWallet : IPublicWallet
    {
        PubKey _publicKey;
        readonly IAddressGenerator _addressGenerator;

        private byte[] _publicKeyBytes;

        public byte[] PublicKeyBytes
        {
            get
            {
                return _publicKeyBytes;
            }
            set
            {
                PubKey.TryCreatePubKey(value, out _publicKey);
                _publicKeyBytes = value;
            }
        }

        string IPublicWallet.Address => _addressGenerator.GenerateAddress(_publicKey.ToBytes());

        public PublicWallet()
        {
            _addressGenerator = GetAddressGenerator();
        }

        public PublicWallet(string publicKey) : this()
        {
            _publicKey = new PubKey(publicKey);
            _publicKeyBytes = _publicKey.ToBytes();

            _addressGenerator = GetAddressGenerator();
        }

        public PublicWallet(byte[] publicKeyBytes)
        {
            PubKey.TryCreatePubKey(publicKeyBytes, out _publicKey);
            _publicKeyBytes = publicKeyBytes;

            _addressGenerator = GetAddressGenerator();
        }

        bool IPublicWallet.Verify(byte[] message, Signature sig)
        {
            ECDSASignature.TryParseFromCompact(sig.ToCompact(), out ECDSASignature signature);
            return _publicKey.Verify(new uint256(message), signature);
        }

        protected abstract IAddressGenerator GetAddressGenerator();
    }
}
