using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using rtwin.Model;
using rtwin.View.customDialog;

namespace rtwin.lib
{
    class AriLib
    {
        public static string rowNumberQuery(string orderBy,string ascdesc)
        {
            //ROW_NUMBER() OVER(ORDER BY NIP desc)   AS ROWID
            return "ROW_NUMBER() OVER(ORDER BY " + orderBy + " " + ascdesc + ") AS ROWID";
        }
        public static void numBersOnly(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public static string orderBy(bool asc)
        {
            string temp = "DESC";
            if (asc)
            {
                temp = "ASC";
            }
            return temp;
        }
        public static void showDialog(string message,Frame dialogContent,DialogHost dialogHost)
        {
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
        }
        public static string createPaging(string query, int page, int rangePage, int jumRows,bool isSqlServer)
        {
            string query_page = String.Empty;
            if (isSqlServer)
            {
                query_page = "WITH query AS(" + query + ")Select TOP " + jumRows + " * from query where ROWID BETWEEN " + page + " AND " + rangePage;
            }
            else
            {
                query_page = query + " LIMIT "+jumRows+" OFFSET "+page;
            }
            
            return query_page;
        }
        public static string CekEmptyComboBox(ComboBox cmb, List<comboBoxTemplate> json)
        {
            string temp = "";
            if (cmb.SelectedIndex > 0)
            {
                temp = json[cmb.SelectedIndex].name;
            }
            return temp;
        }
        public static string generateComboBox(string queryJson, bool isDefaultSelected, List<ComboBox> combo,bool isSqlServer,bool isEMptyIndex0)
        {
            generateJson gj = new generateJson(isSqlServer);
            string json = gj.generateDataJson(queryJson);
            List<comboBoxTemplate> data = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(json);
            bool isSelected = false;
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine(data[i].content);
                if (isDefaultSelected)
                {
                    if (i == 0)
                    {
                        isSelected = true;
                    }
                    else
                    {
                        isSelected = false;
                    }
                }
                for (int a = 0; a < combo.Count; a++)
                {
                    if (isEMptyIndex0 && i==0)
                    {
                        combo[a].Items.Add(new ComboBoxItem { Content = "", IsSelected = isSelected });
                        combo[a].Items.Add(new ComboBoxItem { Content = data[i].content, IsSelected = isSelected });
                    }
                    else
                    {
                        //MessageBox.Show(data[i].content);
                        combo[a].Items.Add(new ComboBoxItem { Content = data[i].content,IsSelected=isSelected});
                    }
                    
                }


            }
            Console.WriteLine(combo.Count);
            return json;


        }
    }
}
