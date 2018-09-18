
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.DataModels.Entities.Token
{
    public class JwtAuthOptionsModel
    {
        /// <summary>
        /// token publisher
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// token user
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// secret key for encoding
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// token lifetime
        /// </summary>
        public int Lifetime { get; set; }

        /// <summary>
        /// security key
        /// </summary>
        /// <returns></returns>
        //public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        //{
        //    return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        //}

        //public SymmetricSecurityKey GetSymmetricSecurityKey()
        //{
        //    return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        //}
    }
}
