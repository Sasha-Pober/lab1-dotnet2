using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IMessageHandler
    {
        void OnAdding(object sender, EventArgs e);
        void OnRemoving(object sender, EventArgs e);
        void OnCleared(object sender, EventArgs e);
        void OnCopied(object sender, EventArgs e);
        void OnEndPlaced(object sender, EventArgs e);
        void OnBeginPlaced(object sender, EventArgs e);
    }
}
