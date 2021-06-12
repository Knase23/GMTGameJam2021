/*[Note]:
The service locator should maybe not initialize services by looking at GameManager. GameManager should probably tell the Locator
What to initialize

The service locator should initialize everything as a Null provider

Where's the SetService Function(s)?
*/

using Global.ServiceLocators.AudioServices;
using Services.AudioServices.Wwise;

namespace Services
{
    public static class ServiceLocator
    {

        public enum AudioOptions
        {
            Null,
            Debug,
            Wwise
        }

        private static IAudioService audioService;
        public static void Initialize()
        {
            //audioService = new NullAudioService();
            audioService = new WwiseAudioService();
        }

        /// <summary>
        /// Only works with INetworkServie, IAudioServie & IAnalyticsService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>()
        {

            if (typeof(T) == typeof(IAudioService))
            {
                return (T)audioService;
            }
            return default;
        }
    }
}
