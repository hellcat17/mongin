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

    public class Field
    {
        public Weather Weather { get; set; } = Weather.Normal;
        public bool IsMagicRoom { get; set; } = false;
        public bool IsWonderRoom { get; set; } = false;
        public bool HasStrongGravity { get; set; } = false;
        public Side AttackerSide { get; set; } = new Side();
        public Side DefenderSide { get; set; } = new Side();
    }
}
