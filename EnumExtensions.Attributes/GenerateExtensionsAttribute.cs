using System;

namespace EnumExtensions
{
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public sealed class GenerateExtensionsAttribute : Attribute
    {
        /// <summary>
        /// Name of the generated extension class.
        /// If not specified, the name of the enum with the "Extensions" suffix will be used.
        /// </summary>
        public string ClassName { get; set; }
        
        /// <summary>
        /// Namespace of the generated extension class.
        /// If not specified, the namespace of the enum will be used.
        /// </summary>
        public string Namespace { get; set; }
    }
}
