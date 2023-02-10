namespace NeuroApp
{
    public record Topology
    {
        public uint InputCount { get; init; } = 0;
        public uint OutnputCount { get; init; } = 0;
        public List<uint> HiddenLayersSizes { get; init; } = new();

        public Topology() { }

        public Topology(uint inputCount, uint outnputCount, params uint[] hiddenLayers)
        {
            InputCount = inputCount;
            OutnputCount = outnputCount;
            HiddenLayersSizes = hiddenLayers.ToList();
        }
    }
}
