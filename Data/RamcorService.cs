using Ramcor.Data.Models;
using Ramcor.Data.TransCoders;

namespace Ramcor.Data
{
    public class RamcorService
    {
        public RamcorCode Code { get; set; }

        public Task<string> Encode(string text) => Code.Encode(text);

        public Task<string> Decode(string text) => Code.Decode(text);

        public RamcorService()
        {
            Code = new RamcorCode();
        }
    }
}
