namespace NeuroApp
{
    public class Neuron
    {
        public List<double> Weights { get; set; } = new List<double>();
        public double Output { get; private set; }
        public Func<double, double> ActivationFunc { get; set; } = ActivationFunctions.Sigmoid;
        public Neuron(uint inputCount, Func<double, double> activationFunc) : this(inputCount)
        {
            ActivationFunc = activationFunc;
        }
        public Neuron(uint inputCount)
        {
            for (int i = 0; i < inputCount; i++)
            {
                Weights.Add(1);
            }
        }

        public double FeedForward(List<double> inputs)
        {
            var sum = default(double);
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }
            Output = ActivationFunc(sum);
            return Output;
        }
        public void SetWeihts(params double[] weights) => Weights = new List<double>(weights);

        public override string? ToString() => Output.ToString();
    }
}
