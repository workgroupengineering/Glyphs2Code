using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Glyphs2Code;

[Generator]
internal class GlyphsSourceGenerator : ISourceGenerator
{
    private const string SourceItemGroupMetadata = "build_metadata.AdditionalFiles.SourceItemGroup";

    public void Initialize(GeneratorInitializationContext context) { }

    public void Execute(GeneratorExecutionContext context)
    {
        try
        {
            var generator = new(context);
            if (generator is null)
            {
                return;
            }

            var partials = generator.Build(ResolveAdditionalFiles(context), context.CancellationToken);
            foreach (var (fileName, content) in partials)
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    break;
                }

                context.AddSource(fileName, content);
            }
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception exception)
        {
            context.ReportUnhandledError(exception);
        }

    }

    private static IEnumerable<AdditionalText> ResolveAdditionalFiles(GeneratorExecutionContext context)
    {
        return context
            .AdditionalFiles
            .Where(f => context.AnalyzerConfigOptions
                .GetOptions(f)
                .TryGetValue(SourceItemGroupMetadata, out var sourceItemGroup)
                && sourceItemGroup == "Glyphs2CodeGroup");
    }
}
