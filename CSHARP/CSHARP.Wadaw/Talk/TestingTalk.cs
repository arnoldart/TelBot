using System.Threading.Tasks;

namespace CSHARP.Wadaw.Talk
{
    public class TestingTalk
    {
        public async Task<(string Text, string Url)> HadehSekali()
        {
            var hadeh = "asdasd";
            var Urlss = "adads";

            return (
                Text: hadeh,
                Url: Urlss
            );
        }
    }
}