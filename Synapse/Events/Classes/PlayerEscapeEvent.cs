﻿using System.Diagnostics.CodeAnalysis;

namespace Synapse.Events.Classes
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class PlayerEscapeEvent
    {
        public ReferenceHub Player { get; internal set; }

        public RoleType SpawnRole { get; set; }

        public bool Allow { get; set; }

        public RoleType CufferRole { get; internal set; }

        public bool IsCuffed { get; internal set; }
    }
}