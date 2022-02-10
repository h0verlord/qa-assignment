namespace TestHelpers
{
    class Generators
    {
        public static Random Rng { get; set; }

        public static void CreateGenerators()
        {
            Rng = new Random();
        }

        /// <summary>
        /// Generates email address either valid or invalid. Example: "username68@test.test"
        /// </summary>
        /// <param name="valid">If False, returns nonsense instead of email.</param>
        /// <returns>string</returns>
        public static string GenerateEmailAddress(bool valid)
        {
            var randomInt = Rng.Next(1000);
            if (valid)
            {
                return string.Format("{0}{1}@test.test", "username", randomInt);
            }
            else
            {
                return "dfvbjkdf1234!@#$sadf!$#@ ";
            }
        }
    }
}