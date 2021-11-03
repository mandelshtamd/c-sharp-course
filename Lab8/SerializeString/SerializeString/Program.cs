using System;
using System.Text;


namespace SerializeString
{
    class Program
    {
        static void CheckSerialization(string s, Encoding enc)
        {
            Byte[] encodedBytes = enc.GetBytes(s);
            Console.WriteLine("Encoded bytes: " + BitConverter.ToString(encodedBytes));
            string decodedString = enc.GetString(encodedBytes);
            Console.OutputEncoding = enc;
            Console.WriteLine("Decoded string: " + decodedString);
            Console.WriteLine("");
            Console.OutputEncoding = Encoding.UTF8;
        }

        static void Main()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // Russian
            CheckSerialization("пример", Encoding.UTF8);
            // Deutsch
            CheckSerialization("Straße", Encoding.UTF8);
            // Japaneese. You also need to change encoding in your console to see it correctly.
            // Another option is to see it in debug mode.
            CheckSerialization("例", Encoding.GetEncoding(932));
        }
    }
}
