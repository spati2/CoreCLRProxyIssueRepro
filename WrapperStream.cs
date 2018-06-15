using System;
using System.IO;

namespace HttpIssueRepro
{
    /// <summary>
    /// A wrapper stream.
    /// </summary>
    public class WrapperStream : MemoryStream
    {
        public WrapperStream(byte[] buffer):base(buffer)
        {

        }
        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }
    }

}
