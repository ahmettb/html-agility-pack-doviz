


using HtmlAgilityPack;

namespace agilitypack_doviz
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        List<doviz> bilgiler = new List<doviz>();
     

        HtmlWeb web = new HtmlWeb();
        private void button1_Click(object sender, EventArgs e)
        {
            var doc = web.Load("https://www.doviz.com/");

            HtmlNodeCollection node = doc.DocumentNode.SelectNodes(xpath: "//table[@id='narrow-table-with-flag']/tbody/tr");
            try
            {
                foreach (var item in node)
                {
                    doviz d = new doviz();
                    d.paraBirim = item.SelectSingleNode("./td/a").InnerText.ToString();


                    d.paraDeger = item.SelectSingleNode("./td[@class='text-bold']").InnerText;
                    if (node.GetNodeIndex(item) == 0 || node.GetNodeIndex(item) == 3)
                    {
                        d.paraDegisim = item.SelectSingleNode("./td[@class='color-up text-bold']").InnerText;

                    }
                    else
                    {
                        d.paraDegisim = item.SelectSingleNode("./td[@class='color-down text-bold']").InnerText;

                    }
                    d.degisimSaat = item.SelectSingleNode("./td[@class='time']").InnerText;
                    bilgiler.Add(d);

                    listBox1.Items.Add(d.paraBirim.Trim());
                    listBox2.Items.Add(d.paraDeger);
                    listBox3.Items.Add(d.paraDegisim);
                    listBox4.Items.Add(d.degisimSaat);


                }


            }
            catch
            {

            }






            
        }
    }
    }