string message26 = @"Fgct Ejtkuvocu Eqfg Etcemgt,";
string message24 = @"Rngcug cnnqy og vq dg vjg hktuv vq eqpitcvwncvg aqw qp aqwt eqfg etcemkpi cdknkva!";
string message22 = @"Lstijyppc csy ampp srpc ywi csy gshi gvegomrk womppw jsv kssh, sxlivamwi fi aevrih - csy qmklx irh yt sr xli reyklxc pmwx!";
string message20 = @"Eua cuarjt'z cgtz zngz tuc, cuarj eua?";
string message18 = @"Q rcab eivbml bw bism i uqvcbm bw eqap gwc i zmtifqvo pwtqlig bw pmtx gwc xzmxizm nwz bpm vmfb amumabmz.";
string message16 = @"Rkfo pex, kxn nyx'd okd dyy wkxi wsxmo zsoc."; 
string message14 = @"U mfq m palqz azxk ftue yadzuzs."; 
string message12 = @"Wh'zz ps o kcbrsf wt hvs gzswuv ushg ctt hvs ufcibr oh ozz hvwg msof!";
string message10 = @"Xe Xe Xe!"; 
string message8 = @"Ewjjq Uzjaklesk!";
string message6 = @"Zlig Muhnu.";

Decode(message26, 24);
Decode(message24, 24);
Decode(message22, 22);
Decode(message20, 20);
Decode(message18, 18);
Decode(message16, 16);
Decode(message14, 14);
Decode(message12, 12);
Decode(message10, 10);
Decode(message8,8);
Decode(message6, 6);
char[] MessageToArray(string message)
{
    char[] charArray = message.ToCharArray();
    return charArray;
}
void Decode(string line, int deviation)
{
    Console.WriteLine();
    char[] message = MessageToArray(line);

    for (int i = 0; i < message.Length; i++)
    {
        int temp = Convert.ToInt32(message[i]);
        if (temp >= 97 && temp <= 122)
        {
            temp += deviation;
            if (temp <= 122)
            {
                char tempChar = Convert.ToChar(temp);
                message[i] = tempChar;
            }
            else
            {
                temp -= 26;
                char tempChar = Convert.ToChar(temp);
                message[i] = tempChar;
            }

        }
        else if (temp >= 65 && temp <= 90)
        {
            temp += deviation;
            if (temp <= 90)
            {
                char tempChar = Convert.ToChar(temp);
                message[i] = tempChar;
            }
            else
            {
                temp -= 26;
                char tempChar = Convert.ToChar(temp);
                message[i] = tempChar;
            }
        }
        else
        {
            char tempChar = Convert.ToChar(temp);
            message[i] = tempChar;
        }

    }
    foreach (char c in message)
    {
        Console.Write(c);
    }
    
}

