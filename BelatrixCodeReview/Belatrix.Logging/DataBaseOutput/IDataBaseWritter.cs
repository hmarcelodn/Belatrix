
namespace Belatrix.Logging.DataBaseOutput
{
    using Belatrix.Logging.Common;

    public interface IDataBaseWritter
    {
        void Save(Message s);
    }
}
