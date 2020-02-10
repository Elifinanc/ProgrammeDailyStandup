using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Shuffle
{
    public interface IReadable
    {
        IEnumerable<String> ExtractFileLines();
    }
}
