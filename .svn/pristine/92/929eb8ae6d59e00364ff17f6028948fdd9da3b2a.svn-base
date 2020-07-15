using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.lib
{
    public class statusForm
    {
        public string formTitel { set; get; }
        public string formValue { set; get; }
    }
    class formValidate
    {
        
        public string validate(List<statusForm> statusForms)
        {
            List<statusForm> data = statusForms;
            var tem = String.Empty;
            try
            {
                if (data.Count > 0)
                {
                    int z = 0;
                    for(int a = 0; a < data.Count; a++)
                    {
                        if (data[a].formValue=="")
                        {
                            if (tem == "")
                            {
                                tem += data[a].formTitel+",";
                            } else if (tem != "" && a < data.Count-1) {
                                tem += data[a].formTitel + ",";
                            } else if(tem != "" && a == data.Count-1) {
                                tem += data[a].formTitel;
                            }
                            z++;
                        }
                    }
                    if (z == 1)
                    {
                        tem = tem.Replace(",", "");
                    }
                }
                if (tem !="")
                {
                    tem +=  " Wajib Di Isi";
                }
            }catch(Exception m)
            {
                tem = m.Message.ToString();
            }
            return tem;
        }

    }
}
