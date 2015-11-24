
using Belatrix.Logging.Common;
namespace Belatrix.Logging.FileOutput
{
    public interface IFileWritter
    {
        void WriteFile(Message message);
    }
}
