using System;
using System.Collections.Generic;
using System.Text;

namespace OrgaSANItion_v2.Classes
{
    public static class Variables
    {
        private static string Username;

        public static void SetUsername(string newUsername)
        {
            Username = newUsername;
        }

        public static string GetUsername()
        {
            return Username;
        }
    }
}
