// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BetterDecont
{
    using System.ComponentModel;
    using BetterDecont.Models;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the amount of generators that should be activated for decontamination to be deactivated.
        /// </summary>
        [Description("The amount of generators that should be activated for decontamination to be deactivated.")]
        public int RequiredActivations { get; set; } = 2;

        /// <summary>
        /// Gets or sets the hint to display to all players at the start of the round.
        /// </summary>
        [Description("The hint to display to all players at the start of the round.")]
        public Hint RoundStartHint { get; set; } = new("Decontamination will stop if {0} generators are activated!", 5);
    }
}