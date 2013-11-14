using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class PrimesAutocompleteController : Controller
    {
        private static readonly string[] Primes = GeneratePrimes(100000).Select(o => o.ToString(CultureInfo.InvariantCulture)).ToArray();

        public ActionResult GetItems(string v)
        {
            return Json(Primes.Where(o => o.Contains(v)).Take(10).Select(o => new KeyContent(o, o)));
        }

        private static IEnumerable<int> GeneratePrimes(int topCandidate)
        {
            var sieve = new BitArray(topCandidate + 1);

            /* Set all but 0 and 1 to prime status */
            sieve.SetAll(true);
            sieve[0] = sieve[1] = false;

            /* Mark all the non-primes */
            var thisFactor = 2;

            while (thisFactor * thisFactor <= topCandidate)
            {
                /* Mark the multiples of this factor */
                int mark = thisFactor + thisFactor;
                while (mark <= topCandidate)
                {
                    sieve[mark] = false;
                    mark += thisFactor;
                }
               
                /* Set thisfactor to next prime */
                thisFactor++;
                while (!sieve[thisFactor]) { thisFactor++; }
            }

            for (int i = 0; i < sieve.Length; i++)
            {
                if (sieve[i]) yield return i;
            }
        }
    }
}