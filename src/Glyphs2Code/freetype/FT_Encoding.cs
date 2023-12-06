namespace Glyphs2Code.freetype;

/// <summary>
/// Represents FreeType encoding values for character mapping.
/// For more information, refer to the
/// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#ft_encoding">FT_Encoding</seealso> onFreeType documentation.
/// </summary>
public enum FT_Encoding
{
    /// <summary>
    /// Represents no encoding.
    /// </summary>
    NONE = 0,

    /// <summary>
    /// Represents the Microsoft Symbol encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_MS_SYMBOL">FT_ENCODING_MS_SYMBOL</seealso> FreeType documentation.
    /// </summary>
    MS_SYMBOL = 0x73796D62, // 'symb'

    /// <summary>
    /// Represents the Unicode encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_UNICODE">FT_ENCODING_UNICODE</seealso> FreeType documentation.
    /// </summary>
    UNICODE = 0x756E6963, // 'unic'

    /// <summary>
    /// Represents the Shift-JIS encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_SJIS">FT_ENCODING_SJIS</seealso> FreeType documentation.
    /// </summary>
    SJIS = 0x736A6973, // 'sjis'

    /// <summary>
    /// Represents the GB2312 (PRC) encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_PRC">FreeType documentation</seealso>.
    /// </summary>
    PRC = 0x67622020, // 'gb  '

    /// <summary>
    /// Represents the Big5 encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_BIG5">FreeType documentation</seealso>.
    /// </summary>
    BIG5 = 0x62696735, // 'big5'

    /// <summary>
    /// Represents the Wansung encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_WANSUNG">FreeType documentation</seealso>.
    /// </summary>
    WANSUNG = 0x77616E73, // 'wans'

    /// <summary>
    /// Represents the Johab encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_JOHAB">FreeType documentation</seealso>.
    /// </summary>
    JOHAB = 0x6A6F6861, // 'joha'

    // For backward compatibility

    /// <summary>
    /// Represents the GB2312 (PRC) encoding (backward compatibility).
    /// </summary>
    GB2312 = PRC,

    /// <summary>
    /// Represents the Microsoft Shift-JIS encoding (backward compatibility).
    /// </summary>
    MS_SJIS = SJIS,

    /// <summary>
    /// Represents the GB2312 (PRC) encoding (backward compatibility).
    /// </summary>
    MS_GB2312 = PRC,

    /// <summary>
    /// Represents the Microsoft Big5 encoding (backward compatibility).
    /// </summary>
    MS_BIG5 = BIG5,

    /// <summary>
    /// Represents the Microsoft Wansung encoding (backward compatibility).
    /// </summary>
    MS_WANSUNG = WANSUNG,

    /// <summary>
    /// Represents the Microsoft Johab encoding (backward compatibility).
    /// </summary>
    MS_JOHAB = JOHAB,

    /// <summary>
    /// Represents the Adobe Standard encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_ADOBE_STANDARD">FreeType documentation</seealso>.
    /// </summary>
    ADOBE_STANDARD = 0x41444F42, // 'ADOB'

    /// <summary>
    /// Represents the Adobe Expert encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_ADOBE_EXPERT">FreeType documentation</seealso>.
    /// </summary>
    ADOBE_EXPERT = 0x41444245, // 'ADBE'

    /// <summary>
    /// Represents the Adobe Custom encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_ADOBE_CUSTOM">FreeType documentation</seealso>.
    /// </summary>
    ADOBE_CUSTOM = 0x41444243, // 'ADBC'

    /// <summary>
    /// Represents the Adobe Latin-1 encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_ADOBE_LATIN_1">FreeType documentation</seealso>.
    /// </summary>
    ADOBE_LATIN_1 = 0x6C617431, // 'lat1'

    /// <summary>
    /// Represents the Old Latin-2 encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_OLD_LATIN_2">FreeType documentation</seealso>.
    /// </summary>
    OLD_LATIN_2 = 0x6C617432, // 'lat2'

    /// <summary>
    /// Represents the Apple Roman encoding.
    /// For more information, refer to the
    /// <seealso href="https://freetype.org/freetype2/docs/reference/ft2-character_mapping.html#FT_ENCODING_APPLE_ROMAN">FreeType documentation</seealso>.
    /// </summary>
    APPLE_ROMAN = 0x61726D6E // 'armn'
}
