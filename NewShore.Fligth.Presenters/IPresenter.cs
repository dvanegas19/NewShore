
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Fligth.Presenters
{
    public interface IPresenter<FormatDataType>
    {
        public FormatDataType content { get; }

    }
}
