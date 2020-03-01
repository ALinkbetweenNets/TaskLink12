using System;
using System.Security.Cryptography;

public partial class TLL
{
    /// <summary>
    /// Generates a Cryptographically secure Random Number
    /// </summary>
    /// <param name="min">Minimum the random Number has to be above</param>
    /// <param name="max">Maximum the random Number has to be under</param>
    /// <returns>The generated random Number</returns>
    public static int Random(int min, int max)
    {
    CryptoStart:
        /*RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();

        byte[] rand = new byte[250];
        random.GetNonZeroBytes(rand);

        int R = BitConverter.ToInt32(rand) / max + 1;
        */
        //if (min > max) throw new ArgumentOutOfRangeException(nameof(min));
        //if (min == max) return min;

        using (var rng = new RNGCryptoServiceProvider())
        {

            var data = new byte[4];
            rng.GetBytes(data, 0, 2);

            int generatedValue = Math.Abs(BitConverter.ToInt32(
                data, 0));

            int diff = max - min;
            int mod = generatedValue;//% diff
            int R = mod;//min + 
            if (R > min && R < max)
                return R;
            else goto CryptoStart;

        }

    }
}