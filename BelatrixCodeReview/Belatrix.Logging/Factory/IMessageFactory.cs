using System;
namespace Belatrix.Logging.Factory
{
    using Belatrix.Logging.Common;

    public interface IMessageFactory
    {
        Message Create(string s, Belatrix.Logging.Enum.EnumMessageType type);
    }
}
