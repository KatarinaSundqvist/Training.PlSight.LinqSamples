using System.Collections.Generic;

namespace Features.Linq {
    public static class MyLinq {
        // Making our own methods without using Linq, to better understand what they do

        public static int Count<T>(this IEnumerable<T> sequence) {
            var count = 0;
            foreach (var item in sequence) {
                count += 1;
            }
            return count;
        }
    }
}
