using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MojaOstroleka
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pageHtml = "";
            List<string> dd = new List<string>();
            WebClient client = new WebClient();
            Byte[] pageData = client.DownloadData("https://ogloszenia.moja-ostroleka.pl/maszyny-rolnicze,30,2.html");
            pageHtml = Encoding.UTF8.GetString(pageData);
            string[] tab = pageHtml.Split('\n');
            for(int i = 0; i< tab.Length; i++)
            {
                if(tab[i].Contains("<h4>") && tab[i+11].Contains("Dzisiaj"))
                {
                    string qq = tab[i].Replace("<h4>", "");
                    string qq1 = tab[i + 1].Replace("<p class=\"\">", "");
                    qq1 = qq1.Replace("</p>", "");
                    qq = qq.Replace("</h4>", "");
                    dd.Add(qq + "  " + qq1);
                    //MessageBox.Show(qq1, qq);
                }
            }
            DumpHRefs(pageHtml);
        }

        private void DumpHRefs(string inputString)
        {
        //    Match m;
        //    List<string> ss = new List<string>();
        //    string HRefPattern = @"<h4>(.*)";

        //    try
        //    {
        //        m = Regex.Match(inputString, HRefPattern,
        //                        RegexOptions.IgnoreCase | RegexOptions.Compiled,
        //                        TimeSpan.FromSeconds(1));
        //        while (m.Success)
        //        {

        //            ss.Add(m.Groups[1].ToString());
        //            m = m.NextMatch();
        //        }
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {
        //        Console.WriteLine("The matching operation timed out.");
        //    }
        //    for(int i = 0; i< ss.Count;i++)
        //    {
        //        if(ss[i].Contains("c360"))
        //            MessageBox.Show(ss[i]);
        //    }
        }

    }
}
