using System;

namespace BinaryFormatterExample
{
    [Serializable]
    public class SampleData
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public Guid CreatedAt { get; set; }
        public DateTime Modified { get; set; }
        public Guid ModifiedAt { get; set; }
    }
}
