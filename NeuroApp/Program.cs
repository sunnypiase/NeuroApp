using NeuroApp;

var topology = new Topology()
{
    InputCount = 4,
    OutnputCount = 1,
    HiddenLayersSizes = { 2 }
};
var network = new NeuralNetwork(topology);

network.Layers[1].Neurons[0].SetWeihts(0.5, -0.1, 0.3, -0.1);
network.Layers[1].Neurons[1].SetWeihts(0.1, -0.3, 0.7, -0.3);
network.Layers[2].Neurons[0].SetWeihts(1.2, 0.8);

var result = network.FeedForward(new List<double>() { 1, 1, 2, 3 });
Console.WriteLine(result);