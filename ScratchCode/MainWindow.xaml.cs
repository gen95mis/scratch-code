using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ScratchCode.Models;

namespace ScratchCode
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> arrayCode;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void ButtonGenCodes_Click(object sender, RoutedEventArgs e)
        {
            string pass = "ADDA";

            int sizeCode = Convert.ToInt32(TBSizeCode.Text);
            int countCode = Convert.ToInt32(TBCountCode.Text);
            int sizeSHA = Convert.ToInt32(TBSizeSHA.Text);

            arrayCode = CreatingCode.RandomCode.GenerationScratchCodes(countCode, pass, sizeCode, sizeSHA);

            LBCode.Items.Clear();
            foreach(var code in arrayCode)
                LBCode.Items.Add(code);
        }


        private void ButtonHackingPass_Click(object sender, RoutedEventArgs e)
        {
            int sizeSHA = Convert.ToInt32(TBSizeSHA.Text);
            int sizeCode = Convert.ToInt32(TBSizeCode.Text);


            LBPass.Items.Clear();
            SelectingPasswords hackingPass = new SelectingPasswords(arrayCode);
            //SelectingPasswords hackingPass = new SelectingPasswords(arrayCode, 20000, 5);
            List<string> lPass = hackingPass.BruteForcePass(sizeCode, sizeSHA);
            lPass = new List<string>(lPass.Distinct()); // убирает повторяющиеся строки
            foreach (var p in lPass)
                LBPass.Items.Add(p);

            if (lPass.Count == 0)
                MessageBox.Show("Пароль не найден");

            TBCountPass.Text = "Кол-во паролей " + lPass.Count.ToString();
        }
    }
}