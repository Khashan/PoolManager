using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public class InfiniteDigitalString
{
    public static long findPosition(string str)
    {
        long result = -1;

        for (int len = 1; len <= str.Length; ++len)
        {
            for (int end = 1; end <= len; ++end)
            {
                long num = guessNum(str, len, end);

                if (verifyNum(str, len, end, num))
                {
                    long newResult = findPositionWholeNum(num.ToString()) + (len - end);

                    if (result == -1 || newResult < result)
                        return result = newResult;
                }

            }
            if (result != -1)
            {
                return result;
            }
        }

		if(str[0] == '0')
		{
			result = findPositionWholeNum('1' + str) + 1;
		}

		return result;

    }

    private static long guessNum(string aKataInput, int aLen, int aEnd)
    {
        if (aLen == aEnd)
            return long.Parse(aKataInput.Substring(0, aLen));

        string known = aKataInput.Substring(0, aEnd);
        string next = aKataInput.Substring(aEnd, aLen - aEnd);

        if (isAll9(known))
        {
            if (isPow10(next))
            {
                next += '0';
            }
            next = (long.Parse(next) - 1).ToString();
        }

        return long.Parse(next + known);
    }

    private static bool IsAll9(string aKataInput)
    {
        foreach (char c in aKataInput)
        {
            if (c != '9')
                return false;
        }
        return true;
    }

    private static bool IsPow10(string aKataInput)
    {
        if (aKataInput[0] != '1')
            return false;

        for (int i = 1; i < aKataInput.Length; i++)
        {
            if (aKataInput[i] != '0')
            {
                return false;
            }
        }

        return true;
    }

	private static bool verifyNum(string aKataInput, int aLen, int aEnd, long aNum)
	{
		int i = - (aLen - aEnd);
		int j = 0;
		string numString = aNum.ToString();

		while(i < numString.Length)
		{
			if(i >= 0 && aKataInput[i] != numString[j])
				return false;
			
			i++;
			j++;

			if(j >= numString.Length)
			{
				j =0;
				aNum++;
				numString = aNum.ToString();
			}
		}

		return true;
	}

	private static long findPositionWholeNum(string str)
	{
		int len = str.Length;
		long num = long.Parse(str);

		if(num <= 10)
		{
			return num -1;
		}

		string suffixInput = str.Substring(1);
		long suffixLong = long.Parse(suffixInput);
		long result = 0;

		if(suffixLong == 0)
		{
			string less = (num - 1).ToString();
			result += findPositionWholeNum(less) + less.Length;
		}
		else
		{
			result = findPositionWholeNum((num - suffixLong).ToString()) + suffixLong * len;
		}

		return result;
	}
}