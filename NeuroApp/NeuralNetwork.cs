namespace NeuroApp
{
    public class NeuralNetwork
    {
        public Topology Topology { get; set; }
        public List<Layer> Layers { get; } = new List<Layer>();
        public NeuralNetwork(Topology topology)
        {
            Topology = topology;

            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayers();
        }
        public Neuron FeedForward(List<double> inputSignals)
        {
            if (inputSignals.Count != Layers.First().Neurons.Count)
                throw new Exception("Inputs must be the Same amount as first layer yeah thats stupid will be fixed in futer...maybe..");

            SendInputSignals(inputSignals);
            SpreadSignalsThrougHiddenLayers();

            return Topology.OutnputCount == 1
                ? Layers.Last().Neurons.Single()
                : Layers.Last().Neurons.OrderByDescending(n => n.Output).First();
        }

        private void SpreadSignalsThrougHiddenLayers()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                foreach (var neuron in Layers[i].Neurons)
                {
                    neuron.FeedForward(Layers[i - 1].GetSignals());
                }
            }
        }

        private void SendInputSignals(List<double> inputSignals)
        {
            for (int i = 0; i < inputSignals.Count; i++)
            {
                Layers.First().Neurons[i].FeedForward(new List<double>() { inputSignals[i] });
            }
        }

        private void CreateOutputLayers() => AddNeuronLayer((uint)Layers.Last().Count, Topology.OutnputCount, ActivationFunctions.Sigmoid, LayerTypeEnum.Output);

        private void CreateHiddenLayers()
        {
            foreach (var hidenLayerSize in Topology.HiddenLayersSizes)
            {
                AddNeuronLayer((uint)Layers.Last().Count, hidenLayerSize, ActivationFunctions.Sigmoid, LayerTypeEnum.Normal);
            }
        }

        private void CreateInputLayer() => AddNeuronLayer(1, Topology.InputCount, ActivationFunctions.InputFunc, LayerTypeEnum.Input);

        private void AddNeuronLayer(uint inputsCount, uint neuronsCount, Func<double, double> activationFunc, LayerTypeEnum layerType = LayerTypeEnum.Normal)
        {
            var neurons = new List<Neuron>();
            for (int i = 0; i < neuronsCount; i++)
            {
                neurons.Add(new Neuron(inputsCount, activationFunc));
            }
            Layers.Add(new Layer
            {
                Neurons = neurons,
                LayerType = layerType
            });
        }
    }
}
