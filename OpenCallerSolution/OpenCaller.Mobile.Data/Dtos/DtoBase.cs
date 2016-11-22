using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCaller.Mobile.Data.Dtos
{
    public abstract class DtoBase<TDto> where TDto : DtoBase<TDto>
    {
    }
}
