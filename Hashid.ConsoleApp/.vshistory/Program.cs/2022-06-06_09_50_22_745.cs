using HashidsNet;
using System.Text;


var hashIds = new Hashids("Sól",11);

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
    valuesrealHex.Add
        (hashIds.EncodeHex(ConvertToHexString(item)));
}



foreach (var item in valuesInt)
{
    Console.Write("\n\n");
    Console.WriteLine($"Encoded :{item}");
    Console.Write("\nDecoded:");
    foreach (var id in hashIds.Decode(item))
    {
        Console.Write($"{id}");
    }
    Console.Write("\n\n");
}
Console.Write("\n\n");

//foreach (var item in valuesHex)
//{
//    Console.Write("\n\n");
//    Console.WriteLine($"Encoded :{item}");
//    Console.WriteLine($"Try Decoded:{hashIds.DecodeHex(item)}");
//    Console.Write("\n\n");
//}
//Console.Write("\n\n");

foreach (var item in valuesrealHex)
{
    Console.Write("\n\n");
    Console.WriteLine($"Encoded :{item}");
    Console.WriteLine($"Decoded Hex:{hashIds.DecodeHex(item)}");
    Console.WriteLine
        ($"From Hex to String:{UnConvertToHexString(hashIds.DecodeHex(item))}");
    Console.Write("\n\n");
}

string ConvertToHexString(string value)
{
    Byte[] stringBytes = Encoding.UTF8.GetBytes(value);
    StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
    foreach (byte b in stringBytes)
    {
        sbBytes.AppendFormat("{0:X2}", b);
    }
    return sbBytes.ToString();
}

string UnConvertToHexString(string value)
{
    int numberChars = value.Length;
    byte[] bytes = new byte[numberChars / 2];
    for (int i = 0; i < numberChars; i += 2)
    {
        bytes[i / 2] = Convert.ToByte(value.Substring(i, 2), 16);
    }
    return Encoding.UTF8.GetString(bytes);
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



