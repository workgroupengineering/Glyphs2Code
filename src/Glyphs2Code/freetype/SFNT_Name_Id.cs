namespace Glyphs2Code.freetype;


// A NameID identifies a name table entry.
//
// See https://developer.apple.com/fonts/TrueType-Reference-Manual/RM06/Chap6name.html
/// <summary>
/// The name identifier (nameID) codes provide a single word or number description relating to the name character string. Codes 0 through 25 are predefined. Codes 26 through 255 are reserved. Codes 256 through 32767 are reserved for font-specific names for variation axes and instances, layout features and settings, etc..
/// </summary>
/// <remarks>
/// See <see href="https://developer.apple.com/fonts/TrueType-Reference-Manual/RM06/Chap6name.html"/>
/// See <see href="https://learn.microsoft.com/en-us/typography/opentype/spec/name"/>
/// </remarks>
internal enum SFNT_Name_Id : uint
{
    /// <summary>
    /// Copyright notice
    /// </summary>
    Copyright = 0,
    /// <summary>
    /// Font Family
    /// </summary>
    FontFamily = 1,
    /// <summary>
    /// Font Subfamily
    /// </summary>
    FontSubfamily = 2,
    /// <summary>
    /// Unique subfamily identification
    /// </summary>
    UniqueSubfamilyID = 3,
    /// <summary>
    /// Full name of the font.
    /// </summary>
    FontFullName = 4,
    /// <summary>
    /// Version of the name table
    /// </summary>
    NameTableVersion = 5,
    /// <summary>
    /// PostScript name of the font. All PostScript names in a font must be identical. They may not be longer than 63 characters and the characters used are restricted to the set of printable ASCII characters (U+0021 through U+007E), less the ten characters '[', ']', '(', ')', '{', '}', '&lt;', '&gt;', '/', and '%'
    /// </summary>
    PostscriptName = 6,
    /// <summary>
    /// Trademark notice.
    /// </summary>
    TrademarkNotice = 7,
    /// <summary>
    /// Manufacturer name
    /// </summary>
    ManufacturerName = 8,
    /// <summary>
    /// Designer; name of the designer of the typeface.
    /// </summary>
    DesignerName = 9,
    /// <summary>
    /// Description; description of the typeface. Can contain revision information, usage recommendations, history, features, and so on.
    /// </summary>
    FontDescription = 10,
    /// <summary>
    /// URL of the font vendor (with procotol, e.g., http://, ftp://). If a unique serial number is embedded in the URL, it can be used to register the font.
    /// </summary>
    FontVendorURL = 11,
    /// <summary>
    /// URL of the font designer (with protocol, e.g., http://, ftp://)
    /// </summary>
    FontDesignerURL = 12,
    /// <summary>
    /// License description; description of how the font may be legally used, or different example scenarios for licensed use. This field should be written in plain language, not legalese.
    /// </summary>
    FontLicense = 13,
    /// <summary>
    /// License information URL, where additional licensing information can be found.
    /// </summary>
    FontLicenseURL = 14,
    /// <summary>
    /// Reserved
    /// </summary>
    Reserved1 = 15,
    /// <summary>
    /// Preferred Family. In Windows, the Family name is displayed in the font menu, and the Subfamily name is presented as the Style name. For historical reasons, font families have contained a maximum of four styles, but font designers may group more than four fonts to a single family. The Preferred Family and Preferred Subfamily IDs allow font designers to include the preferred family/subfamily groupings. These IDs are only present if they are different from IDs 1 and 2.
    /// </summary>
    PreferredFamily = 16,
    /// <summary>
    /// Preferred Subfamily. In Windows, the Family name is displayed in the font menu, and the Subfamily name is presented as the Style name. For historical reasons, font families have contained a maximum of four styles, but font designers may group more than four fonts to a single family. The Preferred Family and Preferred Subfamily IDs allow font designers to include the preferred family/subfamily groupings. These IDs are only present if they are different from IDs 1 and 2.
    /// </summary>
    PreferredSubfamily = 17,
    /// <summary>
    /// Compatible Full (macOS only). In QuickDraw, the menu name for a font is constructed using the FOND resource. This usually matches the Full Name. If you want the name of the font to appear differently than the Full Name, you can insert the Compatible Full Name in ID 18. This name is not used by macOS itself, but may be used by application developers (e.g., Adobe).
    /// </summary>
    CompatibleName = 18,
    /// <summary>
    /// Sample text. This can be the font name, or any other text that the designer thinks is the best sample text to show what the font looks like.
    /// </summary>
    SampleText = 19,
    /// <summary>
    /// PostScript CID findfont name; Its presence in a font means that the nameID 6 holds a PostScript font name that is meant to be used with the “composefont” invocation in order to invoke the font in a PostScript interpreter. See the definition of name ID 6.
    /// The value held in the name ID 20 string is interpreted as a PostScript font name that is meant to be used with the “findfont” invocation, in order to invoke the font in a PostScript interpreter.
    /// When translated to ASCII, this name string must be restricted to the printable ASCII subset, codes 33 through 126, except for the 10 characters: '[', ']', '(', ')', '{', '}', '&lt;', '&gt;', '/', '%'.
    /// </summary>
    /// <remarks>
    /// See <seealso href="https://learn.microsoft.com/en-us/typography/opentype/spec/recom">“Recommendations for OTF fonts”</seealso> for additional information
    /// </remarks>
    PostScriptCID = 20,
    /// <summary>
    /// WWS Family Name. Used to provide a WWS-conformant family name in case the entries for IDs 16 and 17 do not conform to the WWS model. (That is, in case the entry for ID 17 includes qualifiers for some attribute other than weight, width or slope.) If bit 8 of the fsSelection field is set, a WWS Family Name entry should not be needed and should not be included. Conversely, if an entry for this ID is included, bit 8 should not be set. (See <see href="https://learn.microsoft.com/en-us/typography/opentype/spec/os2#fsselection"> OS/2.fsSelection</see> field for details.) Examples of name ID 21: “Minion Pro Caption” and “Minion Pro Display”. (Name ID 16 would be “Minion Pro” for these examples.)
    /// </summary>
    WWSFamilyName = 21,
    /// <summary>
    /// WWS Subfamily Name. Used in conjunction with ID 21, this ID provides a WWS-conformant subfamily name (reflecting only weight, width and slope attributes) in case the entries for IDs 16 and 17 do not conform to the WWS model. As in the case of ID 21, use of this ID should correlate inversely with bit 8 of the fsSelection field being set. Examples of name ID 22: “Semibold Italic”, “Bold Condensed”. (Name ID 17 could be “Semibold Italic Caption”, or “Bold Condensed Display”, for example.)
    /// </summary>
    WWSSubfamilyName = 22,
    /// <summary>
    /// Light Background Palette. This ID, if used in the CPAL table’s Palette Labels Array, specifies that the corresponding color palette in the CPAL table is appropriate to use with the font when displaying it on a light background such as white. Strings for this ID are for use as user interface strings associated with this palette.
    /// </summary>
    LightBackgroundPalette = 23,
    /// <summary>
    /// Dark Background Palette. This ID, if used in the CPAL table’s Palette Labels Array, specifies that the corresponding color palette in the CPAL table is appropriate to use with the font when displaying it on a dark background such as black. Strings for this ID are for use as user interface strings associated with this palette
    /// </summary>
    DarkBackgroundPalette = 24,
    /// <summary>
    /// Variations PostScript Name Prefix. If present in a variable font, it may be used as the family prefix in the algorithm to generate PostScript names for variation fonts. See Adobe Technical Note #5902: “PostScript Name Generation for Variation Fonts” for details.
    /// </summary>
    PostScriptVariona = 25,
}
