using System.Collections.Generic;
using System.Linq;

namespace Passphrases.Domain
{
    public class PassphraseValidator
    {
        public bool IsValidPart1(List<string> passphrase)
        {
            passphrase.Sort();

            return !passphrase.OrderBy(s=>s).Where((password, i) =>
                {
                    var passphraselist = passphrase.Skip(i + 1).ToArray();

                    return password[0] == passphraselist.FirstOrDefault()?[0] && passphraselist.Contains(password);
                }).Any();
        }

        public bool IsValidPart2(List<string> originalPassphrase)
        {
            var passphrase = originalPassphrase.Select(p => new string(p.OrderBy(c => c).ToArray())).OrderBy(s => s).ToList();

            return !passphrase.Where((password, i) => passphrase.Skip(i + 1).Contains(password)).Any();
        }

        public bool IsValidPart2Faster(List<string> originalPassphrase)
        {
            var passphrase = originalPassphrase.Select(p => new string(p.OrderBy(c => c).ToArray())).OrderBy(s => s).ToList();

            return !passphrase.Where((password, i) =>
                {
                    var passphraselist = passphrase.Skip(i + 1).ToArray();

                    return password[0] == passphraselist.FirstOrDefault()?[0] && passphraselist.Contains(password);
                }).Any();
        }

    }
}
