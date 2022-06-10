using HashidsNet;
using System.Text;

var hashIds = new Hashids("Sól");

List<string> valuesInt = new List<string>();
List<string> valuesHex = new List<string>();

valuesInt.Add(hashIds.Encode(1));
valuesInt.Add(hashIds.Encode(2));
valuesInt.Add(hashIds.Encode(3));
valuesInt.Add(hashIds.Encode(4));
valuesInt.Add(hashIds.Encode(1, 2, 3));


valuesHex.Add(hashIds.EncodeHex("8611a2bb-2fdf-4102-8a33-09c2ddd9718d"));
valuesHex.Add(hashIds.EncodeHex("cf7ad0ca-b7cf-4f3f-9942-ceaa69194c76"));
valuesHex.Add(hashIds.EncodeHex("b3ee95a4-bfd8-4ac9-bffb-261775f7d448"));
valuesHex.Add(hashIds.EncodeHex("3a715c4e-c31e-436d-ad69-5ddad0bc4dc9"));
valuesHex.Add(hashIds.EncodeHex("A1"));
valuesHex.Add(hashIds.EncodeHex("B1"));
valuesHex.Add(hashIds.EncodeHex("A,1"));
valuesHex.Add(hashIds.EncodeHex("B,1"));
valuesHex.Add(hashIds.EncodeHex("DEADBEEF"));

List<string> valuesrealHex = new List<string>();

foreach (var item in valuesHex)
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
    byte[] bytes = Encoding.UTF8.GetBytes(value);

    string hexString = Convert.ToHexString(bytes);

    return hexString;
}

string UnConvertToHexString(string value)
{
    byte[] bb = Enumerable.Range(0, value.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte
                     (value.Substring(x, 2), 16))
                     .ToArray();

    return System.Text.Encoding.UTF8.GetString(bb);
}



