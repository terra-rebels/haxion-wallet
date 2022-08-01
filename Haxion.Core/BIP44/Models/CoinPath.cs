namespace Haxion.Core.BIP44.Models
{
    public class CoinPath
    {
        private readonly string _path;

        public CoinPath(PurposeNumber purpose, CoinType coinType)
        {
            _path = $"m/{(ushort)purpose}'/{(uint)coinType}'";
        }

        public override string ToString() => _path;
    }

    public static class M
    {
        public static Purpose BIP44 => Purpose.Create(PurposeNumber.BIP44);
        public static Purpose BIP49 => Purpose.Create(PurposeNumber.BIP49);
        public static Purpose BIP84 => Purpose.Create(PurposeNumber.BIP84);
    }

    public partial class Purpose
    {
        public CoinPath Ethereum => this.CreateCoinPath(CoinType.Ethereum);
    }
}
