using Haxion.Core.Interfaces;
using Haxion.Core.Models;
using NBitcoin;
using NBitcoin.Crypto;
using NBitcoin.DataEncoders;

namespace Haxion.Core.Secp256k1.Models
{
    public abstract class Wallet : IWallet
    {
        public Key PrivateKey;

        public PubKey PublicKey => PrivateKey.PubKey;

        public string Address => AddressGenerator.GenerateAddress(PublicKey.ToBytes());

        private byte[] privateKeyBytes;

        public byte[] PrivateKeyBytes
        {
            get
            {
                return privateKeyBytes;
            }
            set
            {
                var hexEncodeData = Encoders.Hex.EncodeData(value);
                PrivateKey = PrivateKeyParse(hexEncodeData);
                privateKeyBytes = value;
            }
        }

        public byte[] PublicKeyBytes => this.PublicKey.ToBytes();

        internal IAddressGenerator AddressGenerator { get; private set; }

        public Wallet()
        {
            AddressGenerator = GetAddressGenerator();
        }

        protected abstract IAddressGenerator GetAddressGenerator();

        public Wallet(string privateKey) : this()
        {
            PrivateKey = PrivateKeyParse(privateKey);
            PrivateKeyBytes = PrivateKey.ToBytes();
        }

        private static Key PrivateKeyParse(string privateKey)
        {
            byte[] privKeyPrefix = new byte[] { (128) };
            byte[] prefixedPrivKey = Helper.Concat(privKeyPrefix, Encoders.Hex.DecodeData(privateKey));

            byte[] privKeySuffix = new byte[] { (1) };
            byte[] suffixedPrivKey = Helper.Concat(prefixedPrivKey, privKeySuffix);

            Base58CheckEncoder base58Check = new Base58CheckEncoder();
            string privKeyEncoded = base58Check.EncodeData(suffixedPrivKey);
            return Key.Parse(privKeyEncoded, Network.Main);
        }
        Signature IWallet.Sign(byte[] message)
        {
            if (message.Length != 32) throw new ArgumentException(paramName: nameof(message), message: "Message should be 32 bytes");

            var compactSignature = PrivateKey.SignCompact(new uint256(message));

            var signature = new Signature
            {
                RecId = compactSignature.RecoveryId,
                R = new byte[32],
                S = new byte[32]
            };

            Array.Copy(compactSignature.Signature, sourceIndex: 0, destinationArray: signature.R, destinationIndex: 0, length: 32);
            Array.Copy(compactSignature.Signature, sourceIndex: 32, destinationArray: signature.S, destinationIndex: 0, length: 32);

            return signature;
        }

        bool IWallet.Verify(byte[] message, Signature sig)
        {
            ECDSASignature.TryParseFromCompact(sig.ToCompact(), out ECDSASignature signature);
            return PublicKey.Verify(new uint256(message), signature);
        }

        public Secp256k1Signature Sign(byte[] message)
        {
            return new Secp256k1Signature(((IWallet)this).Sign(message));
        }
    }
}
