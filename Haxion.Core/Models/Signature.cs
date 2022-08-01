namespace Haxion.Core.Models
{
    public class Signature
    {
        public byte[] R;
        public byte[] S;
        public int RecId;

        public byte[] ToCompact()
        {
            var result = new byte[64];
            R.CopyTo(result, 32 - R.Length);
            S.CopyTo(result, 64 - S.Length);
            return result;
        }
    }
}
