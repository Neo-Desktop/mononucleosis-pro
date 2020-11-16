using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace mononucleosis_pro
{
    class Keygen
    {
        public const int SUBLIME_TEXT = 0;
        public const int VISUAL_STUDIO_CODE = 1;
        private static readonly byte[] VSCGUIDBytes = new byte[] { 111, 15, 51, 253, 65, 63, 29, 66, 159, 229, 222, 116, 45, 12, 84, 192 };
        private static readonly MD5 MD5 = MD5.Create();
        private static readonly Guid VSCGUID = new Guid(VSCGUIDBytes);

        public string Generate(int type, string email)
        {
            switch (type)
            {
                case SUBLIME_TEXT:
                    return generateSublime(email);

                case VISUAL_STUDIO_CODE:
                    return generateVSCode(email);

                default:
                    return "";
            }
        }

        private string generateSublime(string input)
        {
            string output = BitConverter.ToString(MD5.ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("-", "").Substring(0, 25).ToLower();

            return licenseFormat(output);
        }

        private string generateVSCode(string input)
        {
            input = VSCGUID.ToString() + input;

            string output = BitConverter.ToString(MD5.ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("-", "").Substring(0, 25).ToLower();

            return licenseFormat(output);
        }

        private string licenseFormat(string input)
        {
            string output = "";

            for (int i = 0; i <= input.Length + 1; i++)
            {
                if (i % 5 == 0)
                {
                    if (i + 5 < input.Length)
                    {
                        output += input.Substring(i, 5) + "-";
                    }
                    else
                    {
                        output += input.Substring(i);
                    }
                }
            }

            return output;
        }
    }
}
