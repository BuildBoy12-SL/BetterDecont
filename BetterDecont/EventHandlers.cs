// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BetterDecont
{
    using System.Linq;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using LightContainmentZoneDecontamination;

    /// <summary>
    /// General event handlers.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">The <see cref="Plugin{TConfig}"/> class reference.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Map.OnGeneratorActivated(GeneratorActivatedEventArgs)"/>
        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            if (!ev.IsAllowed)
                return;

            int activated = Generator.Get(GeneratorState.Engaged).Count() + 1;
            if (activated >= plugin.Config.RequiredActivations)
                DecontaminationController.Singleton.NetworkRoundStartTime = -1.0;
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted"/>
        public void OnRoundStarted()
        {
            foreach (Player player in Player.List)
                plugin.Config.RoundStartHint.Display(player, plugin.Config.RequiredActivations);
        }
    }
}