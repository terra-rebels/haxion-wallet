namespace Haxion.Core.Interfaces
{
    public interface IAddressGenerator
    {
        public string GenerateAddress(byte[] pubKeyBytes);
    }
}