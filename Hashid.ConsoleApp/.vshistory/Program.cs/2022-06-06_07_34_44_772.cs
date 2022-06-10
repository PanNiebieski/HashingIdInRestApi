﻿using HashidsNet;

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
valuesHex.Add(hashIds.EncodeHex("A,1"));
valuesHex.Add(hashIds.EncodeHex("B,1"));

foreach (var item in valuesInt)
{
    Console.WriteLine("************");
    Console.WriteLine(item);
    Console.WriteLine(hashIds.);
    Console.WriteLine("************");
}


