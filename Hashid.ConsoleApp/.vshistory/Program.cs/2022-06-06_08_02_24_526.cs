using HashidsNet;
using System.Text;
using System.Text.RegularExpressions;

var hashIds = new Hashids("Sól");

List<string> valuesInt = new List<string>();


valuesInt.Add(hashIds.Encode(1));
valuesInt.Add(hashIds.Encode(2));
valuesInt.Add(hashIds.Encode(3));
valuesInt.Add(hashIds.Encode(4));
valuesInt.Add(hashIds.Encode(1, 2, 3));





List<string> strings = new List<string>();
strings.Add("8611a2bb-2fdf-4102-8a33-09c2ddd9718d");
strings.Add("cf7ad0ca-b7cf-4f3f-9942-ceaa69194c76");
strings.Add("b3ee95a4-bfd8-4ac9-bffb-261775f7d448");
strings.Add("3a715c4e-c31e-436d-ad69-5ddad0bc4dc9");
strings.Add("A1");
strings.Add("B1");
strings.Add("A,1");
strings.Add("B,1");
strings.Add("DEADBEEF");


List<string> valuesHex = new List<string>();
foreach (var item in strings)
{
    valuesHex.Add(hashIds.EncodeHex(item));
}

List<string> valuesrealHex = new List<string>();
foreach (var item in strings)
{
    valuesrealHex.Add(ConvertToHexString(item));
}



foreach (var item in valuesInt)
{
    Console.Write("*********\n");
    Console.WriteLine(item);
    Console.Write("\n");
    foreach (var id in hashIds.Decode(item))
    {
        Console.Write($"{id}");
    }
    Console.Write("\n");
}

foreach (var item in valuesHex)
{
    Console.WriteLine(item);
    Console.WriteLine(hashIds.DecodeHex(item));
    Console.WriteLine("###############");
}


foreach (var item in valuesrealHex)
{
    Console.Write("*********\n");
    Console.WriteLine(item);
    Console.WriteLine
        (UnConvertToHexString(hashIds.DecodeHex(item)));

}

string ConvertToHexString(string value)
{
    byte[] bytes = Encoding.Default.GetBytes(value);
    string hexString = BitConverter.ToString(bytes);
    hexString = hexString.Replace("-", "");
    return hexString;
}

string UnConvertToHexString(string value)
{
    byte[] dBytes = StringToByteArray(value);

    string utf8result = System.Text.Encoding.UTF8.GetString(dBytes);
    return utf8result;
}

byte[] StringToByteArray(String hex)
{
    int NumberChars = hex.Length / 2;
    byte[] bytes = new byte[NumberChars];
    using (var sr = new StringReader(hex))
    {
        for (int i = 0; i < NumberChars; i++)
            bytes[i] =
              Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
    }
    return bytes;
}



