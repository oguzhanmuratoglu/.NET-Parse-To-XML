using Ninject;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using TestSolution.Business.Abstract;
using TestSolution.Entities.Concrete;
using TestSolution.Business.Concrete;
using TestSolution.DataAccess.Abstract;
using TestSolution.DataAccess.Concrete.EntityFramework;
using static System.Net.Mime.MediaTypeNames;

namespace TestSolution.WindowsFormUI
{
    public partial class Form1 : Form
    {
        private IRepository<Process> _processRepository;
        private ITestManager _testManager;
        public Form1(IRepository<Process> productionRepository,ITestManager testManager)
        {
            _processRepository = productionRepository;
            _testManager = testManager;
            InitializeComponent();
        }
        int sayac = 0;
        string path = "../../../../TestSolution.Business/GivenData/test.xml";
        private void Form1_Load(object sender, EventArgs e)
        {
            XmlLoad();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            sayac++;
            if (sayac % 2 != 0)
            {
                dataGridView4.DataSource = _testManager.GetAll();
                label3.Text = "DATA IN DATABASE";
                button4.Text = "SHOW DATA IN XML";
                groupBox5.Text = "Add a Data To Database";
                groupBox4.Text = "Update a Data To Database";
            }
            else
            {
                XmlLoad();
                label3.Text = "DATA IN THE SUPPLIED XML FILE";
                button4.Text = "SHOW DATA IN DATABASE";
                groupBox5.Text = "Add a Data To XML";
                groupBox4.Text = "Update a Data To XML";
            }
        }
        private void XmlLoad()
        {
            XDocument doc = new XDocument();
            DataSet ds = new DataSet();
            XmlReader rdr;
            rdr = XmlReader.Create(path, new XmlReaderSettings());
            ds.ReadXml(rdr);
            dataGridView4.DataSource = ds.Tables[0];
            rdr.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sayac % 2 != 0)
            {
                _testManager.Add(new Test
                {
                    SGKKOD = int.Parse(txt_SGKKOD.Text),
                    TCKN = long.Parse(txt_TCKN.Text),
                    Soyad = txt_Soyad.Text,
                    Ad = txt_Ad.Text,
                    BabaAdi = txt_BabaAdi.Text,
                    Tutar = txt_Tutar.Text
                });
                dataGridView4.DataSource = _testManager.GetAll();
                MessageBox.Show("Added!");
            }
            else
            {
                XDocument doc = XDocument.Load(path);
                doc.Element("SGKIstekListe").Add(
                    new XElement("SGKIstek",
                    new XElement("SGKKOD", txt_SGKKOD.Text),
                    new XElement("TCKN", txt_TCKN.Text),
                    new XElement("Soyad", txt_Soyad.Text),
                    new XElement("Ad", txt_Ad.Text),
                    new XElement("BabaAdi", txt_BabaAdi.Text),
                    new XElement("Tutar", txt_Tutar.Text)
                    ));
                doc.Save(path);
                XmlLoad();
                MessageBox.Show("Added!");
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {

            if (sayac % 2 != 0)
            {
                int ID = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
                _testManager.Delete(ID);
                dataGridView4.DataSource = _testManager.GetAll();
                MessageBox.Show("Daleted!");
            }
            else
            {
                var ID = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                XDocument doc = XDocument.Load(path);
                doc.Root.Elements().Where(p => p.Element("SGKKOD").Value == ID).Remove();
                doc.Save(path);
                XmlLoad();
                MessageBox.Show("Daleted!");
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sayac % 2 != 0)
            {
                txtUp_SGKKOD.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                txtUp_TCKN.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                txtUp_Soyad.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
                txtUp_Ad.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
                txtUp_BabaAdi.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
                txtUp_Tutar.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                txtUp_SGKKOD.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                txtUp_TCKN.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                txtUp_Soyad.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                txtUp_Ad.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
                txtUp_BabaAdi.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
                txtUp_Tutar.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
            }
                
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (sayac % 2 != 0)
            {
                _testManager.Update(new Test
                {
                    Id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value),
                    SGKKOD = int.Parse(txtUp_SGKKOD.Text),
                    TCKN = long.Parse(txtUp_TCKN.Text),
                    Soyad = txtUp_Soyad.Text,
                    Ad = txtUp_Ad.Text,
                    BabaAdi = txtUp_BabaAdi.Text,
                    Tutar = txtUp_Tutar.Text
                });
                dataGridView4.DataSource = _testManager.GetAll();
                MessageBox.Show("Updated!");
            }
            else
            {
                var ID = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                XDocument doc = XDocument.Load(path);
                XElement node = doc.Element("SGKIstekListe").Elements("SGKIstek").FirstOrDefault(a => a.Element("SGKKOD").Value == ID);
                if (node != null)
                {
                    node.SetElementValue("SGKKOD", txtUp_SGKKOD.Text);
                    node.SetElementValue("TCKN", txtUp_TCKN.Text);
                    node.SetElementValue("Soyad", txtUp_Soyad.Text);
                    node.SetElementValue("Ad", txtUp_Ad.Text);
                    node.SetElementValue("BabaAdi", txtUp_BabaAdi.Text);
                    node.SetElementValue("Tutar", txtUp_Tutar.Text);
                    doc.Save(path);
                    XmlLoad();
                    MessageBox.Show("Updated!");
                }
               
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var entities = _testManager.GetAll();
            _testManager.DeleteAll(entities);
            var doc = new XmlDocument();
            doc.Load("../../../../TestSolution.Business/GivenData/test.xml");
            XmlNodeList nodes = doc.SelectNodes("//SGKIstekListe/SGKIstek");
            foreach (XmlNode node in nodes)
            {
                _testManager.Add(new Test
                {
                    SGKKOD = int.Parse(node.SelectSingleNode("SGKKOD").InnerText),
                    TCKN = long.Parse(node.SelectSingleNode("TCKN").InnerText),
                    Soyad = node.SelectSingleNode("Soyad").InnerText,
                    Ad = node.SelectSingleNode("Ad").InnerText,
                    BabaAdi = node.SelectSingleNode("BabaAdi").InnerText,
                    Tutar = node.SelectSingleNode("Tutar").InnerXml
                });

            }
            MessageBox.Show("Ýþlem Baþarýyla Gerçekleþti");
        }
    }
}