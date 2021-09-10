using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class clsAlert
    {
        public clsAlert(string ErrMsg, Page pagina)
        {
            Format Format = new Format();
            pagina.Response.Write("<script language='javascript' type='text/javascript'>");
            pagina.Response.Write("	alert('" + FuncoesString.LimpaString(Format.toExprTraduzida(ErrMsg)) + "');");
            pagina.Response.Write("	history.back();");
            pagina.Response.Write("</script>");
            pagina.Response.End();
        }
    }
}
