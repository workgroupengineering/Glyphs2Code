using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;

namespace Glyphs2Code.freetype.Handles;

internal class FT_FaceHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    public FT_FaceHandle():
        base(false)
    {
        
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    protected override bool ReleaseHandle()
    {
        var result = NattiveLibrary.FT_Done_Face(handle);
        return result == FT_Error.Ok;
    }
}
