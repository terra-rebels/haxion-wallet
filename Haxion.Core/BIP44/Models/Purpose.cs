namespace Haxion.Core.BIP44.Models
{
    public partial class Purpose
    {
        PurposeNumber _purposeNumber;
        Purpose(PurposeNumber purposeNumber)
        {
            _purposeNumber = purposeNumber;
        }

        public static Purpose Create(PurposeNumber purposeNumber)
        {
            return new Purpose(purposeNumber);
        }

        public CoinPath CreateCoinPath(CoinType coinType)
        {
            return new CoinPath(_purposeNumber, coinType);
        }
    }
}
