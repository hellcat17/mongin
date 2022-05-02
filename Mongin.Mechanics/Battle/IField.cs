namespace Mongin.Mechanics.Battle
{
    public class Side
    {
        private int _spikes = 0;
        private int _toxicSpikes = 0;
        private int _stealthRocks = 0;

        public int Spikes
        {
            get { return _spikes; }
            set { _spikes = Math.Max(0, Math.Min(3, value)); }
        }

        public int ToxicSpikes
        {
            get { return _toxicSpikes; }
            set { _toxicSpikes = Math.Max(0, Math.Min(2, value)); }
        }

        public int StealthRocks
        {
            get { return _stealthRocks; }
            set { _stealthRocks = Math.Max(0, Math.Min(1, value)); }
        }

        public bool HasReflect { get; set; } = false;
        public bool HasLightScreen { get; set; } = false;
    }

    public interface IField
    {
        Weather Weather { get; set; }
        bool IsMagicRoom { get; set; }
        bool IsWonderRoom { get; set; }
        bool HasStrongGravity { get; set; }
        Side AttackerSide { get; }
        Side DefenderSide { get; }
    }
}
