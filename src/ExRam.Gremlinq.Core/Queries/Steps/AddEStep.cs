﻿namespace ExRam.Gremlinq.Core
{
    public sealed class AddEStep : Step
    {
        public sealed class FromLabelStep : Step
        {
            public FromLabelStep(StepLabel stepLabel)
            {
                StepLabel = stepLabel;
            }

            public StepLabel StepLabel { get; }
        }

        public sealed class FromTraversalStep : Step
        {
            public FromTraversalStep(Traversal traversal)
            {
                Traversal = traversal;
            }

            public Traversal Traversal { get; }
        }

        public sealed class ToLabelStep : Step
        {
            public ToLabelStep(StepLabel stepLabel)
            {
                StepLabel = stepLabel;
            }

            public StepLabel StepLabel { get; }
        }

        public sealed class ToTraversalStep : Step
        {
            public ToTraversalStep(Traversal traversal)
            {
                Traversal = traversal;
            }

            public Traversal Traversal { get; }
        }

        public AddEStep(string label)
        {
            Label = label;
        }

        public string Label { get; }
    }
}
