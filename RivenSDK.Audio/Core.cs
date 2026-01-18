
namespace RivenSDK.Audio
{
    public interface ICommonRivenAudio
    {
        public void PlaySound(string source);
        public void LoadSound(string name, string path);

        // Needed for FMOD but nothing else really, just pass false or null to this
        public void UpdateSystem();
        public void Stop();
    }

    public class RivenAudio<T>
    {
        public int Volume { get; set; } = 100;
        public readonly Dictionary<string, T> sounds = [];
    }
}
