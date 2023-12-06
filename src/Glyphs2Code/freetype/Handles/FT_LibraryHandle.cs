using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;

namespace Glyphs2Code.freetype.Handles;

internal class FT_LibraryHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    public FT_LibraryHandle() :
        base(true)
    {

    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    protected override bool ReleaseHandle()
    {
        var result = NattiveLibrary.FT_Done_FreeType(handle);
        return result == FT_Error.Ok;
    }
}
