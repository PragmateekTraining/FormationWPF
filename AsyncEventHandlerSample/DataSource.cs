using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncEventHandlerSample
{
    public class DataSource
    {
        public static async Task<string> GetNextDataAsync()
        {
            await Task.Delay(1000);

            return Guid.NewGuid().ToString();
        }
    }
}
