using System;
using Microsoft.CodeAnalysis;

namespace EnumExtensions.Generator
{
    internal static class SymbolExtensions
    {
        public static bool Is(this ITypeSymbol symbol, string fullyQualifiedTypeName)
        {
            fullyQualifiedTypeName = PrependGlobalIfRequired(fullyQualifiedTypeName);
            return symbol.ToFullyQualifiedDisplayString() == fullyQualifiedTypeName;
        }

        public static string ToFullyQualifiedDisplayString(this ITypeSymbol symbol) => symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        public static string ToFullyQualifiedDisplayString(this INamespaceSymbol symbol) => symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

        private static string PrependGlobalIfRequired(string name)
        {
            return name.StartsWith("global::", StringComparison.Ordinal) ? name : $"global::{name}";
        }
    }
}