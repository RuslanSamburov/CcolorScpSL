using Ccolor.Configs;
using Ccolor.Services;
using Exiled.API.Features;
using System;

namespace Ccolor
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "Руслан038c";
        public override string Name => "Ccolor";
        public override Version Version => new(1, 0, 0);
        public override Version RequiredExiledVersion => new(8, 14, 0);

        public static Plugin Singleton;

        public ColorService _colorService;

        public override void OnEnabled()
        {
            Singleton = this;

            _colorService = new();

            base.OnEnabled();
        }

        public override void OnDisabled()
        { 
            Singleton = null;

            _colorService = null;

            base.OnDisabled();
        }
    }
}
