using Microsoft.CodeAnalysis;
using System;

namespace Glyphs2Code;

// When update these enum values, don't forget to update Avalonia.Generators.props.
internal enum BuildProperties
{
    Glyphs2CodeIsEnabled = 0,
    Glyphs2CodeFilterByPath = 1,
    Glyphs2CodeClassAccessModifier = 2,
    Glyphs2CodeFiledAccessModifier = 3,
    RootNamespace = 4,
}

internal class GeneratorOptions
{
    private readonly GeneratorExecutionContext _context;

    public GeneratorOptions(GeneratorExecutionContext context) => _context = context;

    public bool IsEnabled =>
        GetBoolProperty(BuildProperties.Glyphs2CodeIsEnabled,
        true);

    public string[] FilterByPath =>
        GetStringArrayProperty(BuildProperties.Glyphs2CodeFilterByPath
            , "*");

    public MemberAccessModifiers ClassAccessModifier =>
        GetEnumProperty(BuildProperties.Glyphs2CodeClassAccessModifier,
            MemberAccessModifiers.Internal);

    public MemberAccessModifiers FieldAccessModifier =>
        GetEnumProperty(BuildProperties.Glyphs2CodeFiledAccessModifier,
             MemberAccessModifiers.Public);

    public string? RootNamespace =>
        GetStringProperty(BuildProperties.RootNamespace);

    private string[] GetStringArrayProperty(BuildProperties name, string defaultValue)
    {
        var key = name.ToString();
        var value = _context.GetMsBuildProperty(key, defaultValue);
        return value!.Contains(";") ? value.Split(';') : new[] { value };
    }

    private TEnum GetEnumProperty<TEnum>(BuildProperties name, TEnum defaultValue) where TEnum : struct
    {
        var key = name.ToString();
        var value = _context.GetMsBuildProperty(key, defaultValue.ToString());
        return Enum.TryParse(value, true, out TEnum behavior) ? behavior : defaultValue;
    }

    private bool GetBoolProperty(BuildProperties name, bool defaultValue)
    {
        var key = name.ToString();
        var value = _context.GetMsBuildProperty(key, defaultValue.ToString());
        return bool.TryParse(value, out var result) ? result : defaultValue;
    }

    private string? GetStringProperty(BuildProperties name, string? defaultValue = default)
    {
        var key = name.ToString();
        return _context.GetMsBuildProperty(key, defaultValue);
    }
}
