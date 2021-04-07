using System.Collections.Generic;

namespace FatSecretDotNet.RequestObjects
{
    public interface IFatSecretRequest
    {
        List<(string, string)> GetParameters(bool isPremier);
    }
}