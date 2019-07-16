using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class mBoardFrm
    {
        public FrmType FrmType { get; set; }
        public string ErrorMessage { get; set; }
        public mBoard mBoard { get; set; }
        public string ReturnUrl { get; set; }

    }
}
