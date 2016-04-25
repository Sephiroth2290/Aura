using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Aura.ProcessRelated
{
    internal sealed class SafeProcessHandle : SafeHandle
    {
        public override bool IsInvalid
        {
            get
            {
                return this.handle == IntPtr.Zero;
            }
        }

        public SafeProcessHandle()
          : base(IntPtr.Zero, true)
        {
        }

        protected override bool ReleaseHandle()
        {
            return SafeNativeMethods.CloseHandle(this.handle);
        }
    }
}
