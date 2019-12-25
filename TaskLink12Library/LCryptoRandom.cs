using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;

public partial class TLL
{
    public static int Random(int min, int max)
    {
    CryptoStart:
        RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();

        byte[] rand = new byte[250];
        random.GetNonZeroBytes(rand);

        int R = Convert.ToInt32(rand) / max + 1;
        if (R > min && R < max)
            return R;
        else goto CryptoStart;
    }
}