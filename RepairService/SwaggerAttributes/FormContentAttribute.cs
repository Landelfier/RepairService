using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class FormContentAttribute:Attribute
    {
        public FormContentAttribute(params string[] namedesc)
        {
            elements = new List<FormContentElement>();
            for (int i = 0; i <= namedesc.Length-2; i += 2)
            {
                elements.Add(new FormContentElement { ParameterName = namedesc[i], Description = namedesc[i+1]});
            }
        }
        public readonly List<FormContentElement> elements;
    }
}
