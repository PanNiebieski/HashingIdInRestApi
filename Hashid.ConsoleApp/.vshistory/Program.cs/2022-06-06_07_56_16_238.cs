using HashidsNet;
using System.Text;

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
    value = value.Replace("-", "");

    byte[] bytes = Encoding.UTF8.GetBytes(value);

    string hexString = Convert.ToHexString(bytes);

    return hexString;
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



