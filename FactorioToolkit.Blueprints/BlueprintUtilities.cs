using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using FactorioToolkit.Blueprints.Model;

using Ionic.Zlib;

using Newtonsoft.Json;

namespace FactorioToolkit.Blueprints
{
    public class BlueprintUtilities
    {
        public async Task<string> DecodeAsync(string blueprintString)
        {
            var blueprintBytes = Encoding.UTF8.GetBytes(blueprintString);
            var cleanBase64String = Encoding.UTF8.GetString(blueprintBytes[1..]);
            var decodedByteArray = Convert.FromBase64String(cleanBase64String);

            await using var memoryStream = new MemoryStream(decodedByteArray, false);
            await using var deflateStream = new ZlibStream(memoryStream, CompressionMode.Decompress);
            using var streamReader = new StreamReader(deflateStream, Encoding.UTF8);

            return await streamReader.ReadToEndAsync().ConfigureAwait(false);
        }

        public async Task<Blueprint> GetBlueprint(string blueprintString)
        {
            var json = await DecodeAsync(blueprintString);

            var blueprintContainer = JsonConvert.DeserializeObject<BlueprintContainer>(json);

            return blueprintContainer.Blueprint;
        }

        private class BlueprintContainer
        {
            public Blueprint Blueprint { get; set; }
        }
    }
}
