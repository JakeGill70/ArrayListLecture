using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListLecture
{
    internal interface IArrayList : IList<string>
    {
        void Resize(int newSize);
    }
}
