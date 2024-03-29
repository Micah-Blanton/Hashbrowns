﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SharpHash.Base;
using SharpHash.Interfaces;

// Hashing code from "https://www.youtube.com/watch?v=tRaFiPRlphs"

namespace MarioHash
{
    class MarioHash
    {
        //Done
        public static string Hash_SHA1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var marioHash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(marioHash.Length * 2);

                foreach (byte b in marioHash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        //Modifying Mario's code to use other algorithms.
        //Done
        public static string Hash_SHA2(string input)
        {
            using (SHA512Managed sha2 = new SHA512Managed())
            {
                var marioHash = sha2.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(marioHash.Length * 2);

                foreach (byte b in marioHash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
        //Done thanks to "https://github.com/ron4fun/SharpHash"
        public static string Hash_SHA3(string input)
        {
            string result = HashFactory.Crypto.CreateSHA3_256()
                        .ComputeString(input, Encoding.UTF8).ToString();
            return result; 
        }
        //Done
        public static string Hash_SHA256(string input)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                var marioHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(marioHash.Length * 2);

                foreach (byte b in marioHash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
        //Done
        public static string Hash_MD4(string input)
        {
            string result = HashFactory.Crypto.CreateMD4()
                        .ComputeString(input, Encoding.UTF8).ToString();
            return result;
        }
        //Done thanks to "https://stackoverflow.com/questions/1200602/why-is-there-no-managed-md5-implementation-in-the-net-framework"
        public static string Hash_MD5(string input)
        {
                byte[] marioHash = new MD5CryptoServiceProvider().
                    ComputeHash(Encoding.ASCII.GetBytes(input));

                var sb = new StringBuilder(marioHash.Length * 2);

                foreach (byte b in marioHash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
        }
        //BCRYPT is missing from the library.
        public static string Hash_BCRYPT(string input)
        {
            string result = HashFactory.Crypto.CreateMD5()
                        .ComputeString(input, Encoding.UTF8).ToString();
            return result;
        }
        //Done
        public static string Hash_Whirlpool(string input)
        {
            string result = HashFactory.Crypto.CreateWhirlPool()
                        .ComputeString(input, Encoding.UTF8).ToString();
            return result;
        }
        //PBK is broken.
        public static string Hash_PBKDF2(string input)
        {
            string result = HashFactory.Crypto.CreateMD5()
                        .ComputeString(input, Encoding.UTF8).ToString();
            return result;
        }
    }
}