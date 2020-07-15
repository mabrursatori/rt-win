using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rtwin.dataQuery;
using rtwin.lib;

using MaterialDesignExtensions.Model;

namespace rtwin.ViewModel
{
    public class TextBoxSuggestionsViewModel : ViewModel
    {
        private ITextBoxSuggestionsSource m_textBoxSuggestionsSource;

        private string m_text;

        public override string DocumentationUrl
        {
            get
            {
                return "https://spiegelp.github.io/MaterialDesignExtensions/#documentation/textboxsuggestions";
            }
        }

        public string Text
        {
            get
            {
                return m_text;
            }

            set
            {
                m_text = value;

                OnPropertyChanged(nameof(Text));
            }
        }

        public ITextBoxSuggestionsSource TextBoxSuggestionsSource
        {
            get
            {
                return m_textBoxSuggestionsSource;
            }
        }

        public TextBoxSuggestionsViewModel(bool isSqlServer,string username,string gradeID)
            : base()
        {
            m_textBoxSuggestionsSource = new OperatingSystemTextBoxSuggestionsSource(isSqlServer,username,gradeID);

            m_text = null;
        }
    }

    public class OperatingSystemTextBoxSuggestionsSource : TextBoxSuggestionsSource
    {
        private List<string> m_operatingSystemItems;

        public OperatingSystemTextBoxSuggestionsSource(bool isSqlServer,string username,string gradeID)
        {
            koneksi con = new koneksi(isSqlServer);
            this.m_operatingSystemItems = con.getDataFromDatabase(queryKaryawan.getAutoCompletekaryawan+queryKaryawan.filterAutoComplete(username,gradeID));
        }

        public override IEnumerable<string> Search(string searchTerm)
        {
            searchTerm = searchTerm ?? string.Empty;
            searchTerm = searchTerm.ToLower();
            return m_operatingSystemItems.Where(item => item.ToLower().Contains(searchTerm));
            //return query;
        }
    }
}
