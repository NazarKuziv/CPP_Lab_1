using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace CPP_Lab_1
{
   

    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        List<Toys> toys = new List<Toys>();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string filePfth = "D:\\ddpu\\ККП\\Лаб\\toys.txt";
                List<string> lines = File.ReadAllLines(filePfth).ToList();
               
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    Toys newToy = new Toys();
                    newToy.Name = entries[0];
                    newToy.Price = entries[1];
                    newToy.Age_From = entries[2];
                    newToy.Age_To = entries[3];
                    newToy.Characteristic = entries[4];
                    toys.Add(newToy);
                }
                
                Update_ListView(toys);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var price = numericUpDown1.Value;
            List<Toys> Sort_toys = new List<Toys>();
            foreach (var toy in toys)
            {
                if (toy.Name != "М'яч" && ToInt(toy.Age_From) <= 3 && ToInt(toy.Age_To) >= 3 && ToInt(toy.Price) < price)
                {
                    Toys Toy = new Toys();
                    Toy.Name = toy.Name;
                    Toy.Price = toy.Price;
                    Toy.Age_From = toy.Age_From;
                    Toy.Age_To = toy.Age_To;
                    Toy.Characteristic = toy.Characteristic;
                    Sort_toys.Add(Toy);
                }
            }
            Sort_toys.Sort((x, y) => y.Price.CompareTo(x.Price));
            Update_ListView(Sort_toys);

        }

        public void Update_ListView(List<Toys> toys)
        {
            listView1.Items.Clear();
            foreach(var toy in toys)
            {
                ListViewItem item = new ListViewItem(toy.Name);
                item.SubItems.Add(toy.Price);
                item.SubItems.Add("від " + toy.Age_From + " до " + toy.Age_To);
                item.SubItems.Add(toy.Characteristic);
                listView1.Items.Add(item);
            }
           
        }

        public int ToInt(string str)
        {
            return Convert.ToInt32(str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_ListView(toys);
        }
    }
}
