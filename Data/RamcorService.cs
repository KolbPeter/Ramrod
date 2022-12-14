using Ramrod.Data.Models;
using Ramrod.Data.TransCoders;

namespace Ramrod.Data;

public class RamrodService
{
    public RamrodService()
    {
        Code = new RamrodCode();
    }

    public RamrodCode Code { get; set; }

    public Task<string> Encode(string text)
    {
        return Code.Encode(text);
    }

    public Task<string> Decode(string text)
    {
        return Code.Decode(text);
    }
}