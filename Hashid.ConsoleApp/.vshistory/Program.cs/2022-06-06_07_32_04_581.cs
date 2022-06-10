using HashidsNet;

var hashIds = new Hashids("Sól");

List<string> hashedValues = new List<string>();

hashedValues.Add(hashIds.Encode(1));
hashedValues.Add(hashIds.Encode(2));
hashedValues.Add(hashIds.Encode(3));
hashedValues.Add(hashIds.Encode(4));

hashedValues.Add(hashIds.EncodeHex("8611a2bb-2fdf-4102-8a33-09c2ddd9718d"));
hashedValues.Add(hashIds.EncodeHex("cf7ad0ca-b7cf-4f3f-9942-ceaa69194c76"));
hashedValues.Add(hashIds.EncodeHex("8611a2bb-2fdf-4102-8a33-09c2ddd9718d"));
hashedValues.Add(hashIds.EncodeHex("8611a2bb-2fdf-4102-8a33-09c2ddd9718d"));

hashedValues.Add(hashIds.Encode(1,2,3));

hashedValues.Add(hashIds.EncodeHex("A,1"));
hashedValues.Add(hashIds.EncodeHex("B,1"));


