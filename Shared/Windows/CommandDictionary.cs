﻿using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Istar.ModernUI.Windows
{
    /// <summary>
    /// Represents a collection of commands keyed by a uri.
    /// </summary>
    public class CommandDictionary
        : Dictionary<Uri, ICommand>
    {
    }
}
