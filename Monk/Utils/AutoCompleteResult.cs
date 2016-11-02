using System.Collections.Generic;

namespace Monk.Utils
{
    public class AutoCompleteResult
    {
        public string query { get; set; }
        public List<Suggestion> suggestions { get; set; }
    }

    public class Suggestion
    {
        public object value { get; set; }
        public object data { get; set; }
    }
}