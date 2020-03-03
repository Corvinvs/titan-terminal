using System;
using TitanTerminal.Models;

namespace TitanTerminal.Contracts
{
    public interface ITitan
    {
        TitanType Type { get; }

        int Scale { get; }

        string ScaleDescription { get; }

        int Cost { get; }
    }
}
