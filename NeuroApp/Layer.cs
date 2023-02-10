namespace NeuroApp
{
    public class Layer
    {
        public List<Neuron> Neurons { get; init; } = new List<Neuron>();
        public LayerTypeEnum LayerType { get; init; } = LayerTypeEnum.Normal;

        public int Count => Neurons?.Count ?? 0;
        public Layer() { }
        public Layer(List<Neuron> neurons, LayerTypeEnum layerType)
        {
            LayerType = layerType;
            Neurons = new(neurons);
        }
        public List<double> GetSignals() => Neurons.Select(neuron => neuron.Output).ToList();
    }
}
