using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class FormContentElement
    {
        /// <summary>
        /// Represents controller actions that accept a form content type loading
        /// </summary>
        public FormContentElement()
        {
            ParameterName = "Test";
            Required = true;
            Description = "Test";
            Format = "string";
        }

        /// <summary>
        /// Gets or sets the payload format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets a required flag.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets value`s description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a parameter name.
        /// </summary>
        public string ParameterName { get; set; }
    }
}
