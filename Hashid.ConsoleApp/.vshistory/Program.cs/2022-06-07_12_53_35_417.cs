using HashidsNet;
using System.Text;

var point = new PointStruct() 
    { X = 1, Y = 2 };
IncreaseS(point);
Console.WriteLine(point.X);
Console.WriteLine(point.Y);

var pointC = new PointClass()
    { X = 1, Y = 2 };
IncreaseC(pointC);
Console.WriteLine(pointC.X);
Console.WriteLine(pointC.Y);


ClassC c1 = new ClassC();
ClassC c2 = new ClassC();
ClassC[] array = new ClassC[] { c1, c2 };

for (int i = 0; i < 2; i++)
    Console.WriteLine($@"{array[i].A} 
                        {array[i].B}");





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



PointStruct IncreaseS(PointStruct p)
{
    p.X++;p.Y++;
    return p;
}

PointClass IncreaseC(PointClass p)
{
    p.X++; p.Y++;
    return p;
}




int Method(int a)
{
    int b = a;
    return b;
}

Person MethodR(Person p)
{
    Person q = p;
    return q;
}

int ReturnValue()
{
    MyInt x;
    x.MyValue = 3;
    MyInt y;
    y = x;
    y.MyValue = 4;
    return x.MyValue;
}

internal class MyInt
{

    public int MyValue { get; set; }
}

public class Person
{
    public int Age { get; set; }
}

public class PointClass
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class PointStruct
{
    public int X { get; set; }
    public int Y { get; set; }
}


public class Point5D
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int V { get; set; }
    public int W { get; set; }
}


public class Human
{
    public Cat MyCat { get; set; }
    public int Age { get; set; }
    public int Number { get; set; }
}

public class Cat
{
    public string Name { get; set; }
}


class ClassC
{
    public int A { get; set; }
    public int B { get; set; }
}

struct StructC
{
    public int A { get; set; }
    public int B { get; set; }
}







