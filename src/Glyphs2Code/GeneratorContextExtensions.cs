using Microsoft.CodeAnalysis;
using System;

namespace Glyphs2Code;

internal static class GeneratorContextExtensions
{
    private const string UnhandledErrorDescriptorId = "G2C0000";


    public static string? GetMsBuildProperty(
        this GeneratorExecutionContext context,
        string name,
        string? defaultValue = default)
    {
        context.AnalyzerConfigOptions.GlobalOptions.TryGetValue($"build_property.{name}", out var value);
        return value ?? defaultValue;
    }

    public static void ReportUnhandledError(this GeneratorExecutionContext context, Exception error) =>
        context.Report(UnhandledErrorDescriptorId,
            "Unhandled exception occured while generating typed Name references. " +
            "Please file an issue: https://github.com/workgroupengineering/Glyphs2Code",
            error.Message,
            error.ToString());

    private static void Report(this GeneratorExecutionContext context, string id, string title, string? message = null, string? description = null) =>
        context.ReportDiagnostic(
            Diagnostic.Create(
                new DiagnosticDescriptor(
                    id: id,
                    title: title,
                    messageFormat: message ?? title,
                    category: "Usage",
                    defaultSeverity: DiagnosticSeverity.Error,
                    isEnabledByDefault: true,
                    description),
                Location.None));
}
