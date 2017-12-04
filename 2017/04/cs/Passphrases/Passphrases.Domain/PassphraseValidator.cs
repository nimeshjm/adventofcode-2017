using System.Collections.Generic;
using System.Linq;

namespace Passphrases.Domain
{
    public class PassphraseValidator
    {
        public bool IsValid(List<string> passphrase)
        {
            passphrase.Sort();

            return !passphrase.Where((password, i) =>
                {
                    var passphraselist = passphrase.Skip(i + 1).ToArray();

                    return password[0] == passphraselist.FirstOrDefault()?[0] && passphraselist.Contains(password);
                }).Any();
        }
    }
}
