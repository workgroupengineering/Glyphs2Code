using System;
using System.Runtime.InteropServices;

namespace Glyphs2Code.freetype;

internal class NattiveLibrary
{
    /// <summary>
    /// Defines the location of the FreeType DLL. Update SharpFont.dll.config if you change this!
    /// </summary>
    /// TODO: Use the same name for all platforms.
    private const string FreeTypeLibrary = "freetype";

    /// <summary>
    /// Defines the calling convention for P/Invoking the native freetype methods.
    /// </summary>
    private const CallingConvention CallConvention = CallingConvention.Cdecl;


    /// <summary>
    /// Initialize a new FreeType library object. The set of modules that are registered by this function is determined at build time.
    /// </summary>
    /// <param name="library"></param>
    /// <returns>FreeType error code. 0 means success.</returns>
    [DllImport(FreeTypeLibrary, CallingConvention = CallConvention)]
    internal static extern FT_Error FT_Init_FreeType(out Handles.FT_LibraryHandle library);

    /// <summary>
    /// Destroy a given FreeType library object and all of its children, including resources, drivers, faces, sizes, etc.
    /// </summary>
    /// <param name="library"></param>
    /// <returns></returns>
    [DllImport(FreeTypeLibrary, CallingConvention = CallConvention)]
    internal static extern FT_Error FT_Done_FreeType(IntPtr library);

    /// <summary>
    /// Return the version of the FreeType library being used. This is useful when dynamically linking to the library, since one cannot use the macros FREETYPE_MAJOR, FREETYPE_MINOR, and FREETYPE_PATCH.
    /// </summary>
    /// <param name="library">A source library handle.</param>
    /// <param name="amajor">The major version number.</param>
    /// <param name="aminor">The major version number.</param>
    /// <param name="apatch">The major version number.</param>
    [DllImport(FreeTypeLibrary, CallingConvention = CallConvention)]
    internal static extern void FT_Library_Version(Handles.FT_LibraryHandle library, out int amajor, out int aminor, out int apatch);

    /// <summary>
    /// Call <seealso href="https://freetype.org/freetype2/docs/reference/ft2-face_creation.html#ft_open_face"> FT_Open_Face</seealso> to open a font by its pathname.
    /// </summary>
    /// <param name="library">A handle to the library resource.</param>
    /// <param name="filepathname">A path to the font file.</param>
    /// <param name="face_index">See <seealso href="https://freetype.org/freetype2/docs/reference/ft2-face_creation.html#ft_open_face"> FT_Open_Face</seealso> for a detailed description of this parameter.</param>
    /// <param name="aface">A handle to a new face object. If <paramref name="face_index"/> is greater than or equal to zero, it must be non-NULL.</param>
    /// <returns>FreeType error code. <see cref="FT_Error.Ok"/> means success.</returns>
    /// <remarks>
    /// The pathname string should be recognizable as such by a standard fopen call on your system; in particular, this means that pathname must not contain null bytes. If that is not sufficient to address all file name possibilities (for example, to handle wide character file names on Windows in UTF-16 encoding) you might use FT_Open_Face to pass a memory array or a stream object instead.
    /// Use FT_Done_Face to destroy the created FT_Face object (along with its slot and sizes).
    /// </remarks>
    [DllImport(FreeTypeLibrary, CallingConvention = CallConvention, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    internal static extern FT_Error FT_New_Face(IntPtr library, string filepathname, int face_index, out Handles.FT_FaceHandle aface);

    /// <summary>
    /// Discard a given face object, as well as all of its child slots and sizes.
    /// </summary>
    /// <param name="face">A handle to a target face object.</param>
    /// <returns>FreeType error code. 0 means success.</returns>
    /// See the discussion of reference counters in the description of FT_Reference_Face.
    [DllImport(FreeTypeLibrary, CallingConvention = CallConvention)]
    internal static extern FT_Error FT_Done_Face(IntPtr face);

    /// <summary>
    /// Select a given charmap by its encoding tag
    /// </summary>
    /// <param name="face">A handle to the source face object.</param>
    /// <param name="encoding">A handle to the selected encoding. <see cref="FT_Encoding"/></param>
    /// <returns>FreeType error code. 0 means success.</returns>
    /// <remarks>
    /// This function returns an error if no charmap in the face corresponds to the encoding queried here.
    /// Because many fonts contain more than a single cmap for Unicode encoding, this function has some special code to select the one that covers Unicode best (‘best’ in the sense that a UCS-4 cmap is preferred to a UCS-2 cmap). It is thus preferable to FT_Set_Charmap in this case.
    /// </remarks>
    [DllImport(FreeTypeLibrary, CallingConvention = CallConvention)]
    internal static extern FT_Error FT_Select_Charmap(Handles.FT_FaceHandle face, FT_Encoding encoding);

    /// <summary>
    /// Return the first character code in the current charmap of a given face, together with its corresponding glyph index.
    /// </summary>
    /// <param name="face">A handle to the source face object.</param>
    /// <param name="agindex">Glyph index of first character code. 0 if charmap is empty.</param>
    /// <returns>The charmap's first character code.</returns>
    /// <remarks>
    /// You should use this function together with <see cref="FT_Get_Next_Char"/>  to parse all character codes available in a given charmap. 
    /// Be aware that character codes can have values up to 0xFFFFFFFF; this might happen for non-Unicode or malformed cmaps. However, even with regular Unicode encoding, so-called ‘last resort fonts’ (using SFNT cmap format 13, see function FT_Get_CMap_Format) normally have entries for all Unicode characters up to 0x1FFFFF, which can cause a lot of iterations.
    /// Note that <paramref name="agindex"/> is set to 0 if the charmap is empty.The result itself can be 0 in two cases: if the charmap is empty or if the value 0 is the first valid character code.
    /// </remarks>
    [DllImport(FreeTypeLibrary, CallingConvention = CallConvention)]
    internal static extern uint FT_Get_First_Char(Handles.FT_FaceHandle face, out uint agindex);


    /// <summary>
    /// Return the next character code in the current charmap of a given face following the value char_code, as well as the corresponding glyph index.
    /// </summary>
    /// <param name="face">A handle to the source face object.</param>
    /// <param name="char_code">The starting character code.</param>
    /// <param name="agindex">Glyph index of next character code. 0 if charmap is empty.</param>
    /// <returns>The charmap's next character code.</returns>
    /// <remarks>You should use this function with FT_Get_First_Char to walk over all character codes available in a given charmap. See the note for that function for a simple code example.
    /// Note that <paramref name="agindex"/> is set to 0 when there are no more codes in the charmap.
    /// </remarks>
    [DllImport(FreeTypeLibrary, CallingConvention = CallConvention)]
    internal static extern uint FT_Get_Next_Char(Handles.FT_FaceHandle face, uint char_code, out uint agindex);

    /// <summary>
    /// Retrieve the ASCII name of a given glyph in a face. This only works for those faces where FT_HAS_GLYPH_NAMES returns true.
    /// </summary>
    /// <param name="face">A handle to a source face object.</param>
    /// <param name="glyphIndex">The glyph index.</param>
    /// <param name="buffer">A pointer to a target buffer where the name is copied to.</param>
    /// <param name="bufferMaxLength">The maximum number of bytes available in the buffer.</param>
    /// <returns></returns>
    [DllImport(FreeTypeLibrary, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    private static extern int FT_Get_Glyph_Name(Handles.FT_FaceHandle face, uint glyphIndex, Span<byte> buffer, uint bufferMaxLength);
}
