using Exiled.API.Features;
using MEC;
using Random = System.Random;
using System.Collections.Generic;
using UnityEngine;

namespace Ccolor.Services
{
    public class ColorService
    {
        private CoroutineHandle _coroutineHandle { get; set; } = new();

        public void Start(string[] red, string[] green, string[] blue, float time)
        {
            Stop();
            _coroutineHandle = Timing.RunCoroutine(Colors(red, green, blue, time));
        }

        public void Stop()
        {
            Timing.KillCoroutines(_coroutineHandle);
        }

        public CoroutineHandle GetCoroutine()
        {
            return _coroutineHandle;
        }

        public IEnumerator<float> Colors(string[] red, string[] green, string[] blue, float time)
        {
            while (true)
            {
                Random random = new();

                int randomRed = random.Next(int.Parse(red[0]), int.Parse(red[1]) + 1); 
                int randomGreen = random.Next(int.Parse(green[0]), int.Parse(green[1]) + 1);
                int randomBlue = random.Next(int.Parse(blue[0]), int.Parse(blue[1]) + 1);

                Color color = new(randomRed, randomGreen, randomBlue);

                Map.ChangeLightsColor(color);

                yield return Timing.WaitForSeconds(time);
            }
        }
    }
}
