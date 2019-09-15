using System.Collections.Generic;

namespace Smart.Core.DataSource
{
    public abstract class DataSources
    {
        public string Code { get; set; }
        public string TypeSource { get; set; }
        public string Source { get; set; }
        public string Title { get; set; }
        public string QueryParams { get; set; }
        public string Order { get; set; }
        public List<DataSourceFields> Fields { get; set; }
    }
}
