using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace TCC
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 100;

            //quando executar fara o codigo seguinte

            //exemplo do path
            string path = "D:";

            MysqlBackup_Restore(path, "backup");

            //corre uma thread com o processo que faz o backup ou restore
            Thread t = new Thread(delegate() { MySqlProcess(path); });
            t.Start();

            progressBar1.Visible = false;
        }

        private void Backup_Load(object sender, EventArgs e)
        {

            progressBar1.Visible = false;
        }


        //Metodo que cria o batch file com os comandos de backup ou restore
        private static void MysqlBackup_Restore(string path, string type)
        {
            //Caminho onde o mysql esta instalado
            string cmd = "\"C:/Arquivos de programas/MySQL/MySQL Server 5.5/bin/";

            //create a bath file to run the script database.
            StreamWriter sw = File.CreateText(path + "\\MySqlbackup.cmd");
            //sw.WriteLine("c:");
            sw.WriteLine("c:");
            sw.WriteLine("cd\\");
            sw.WriteLine("cd " + cmd);

            if (type == "backup")
            {
                //se for backup
                sw.WriteLine("mysqldump.exe -uroot -pALUNOS --databases satcar > " + path + "\\MySqlbackup.sql\"");
            }
            else
            {
                //se for restore
                sw.WriteLine("mysql.exe -uroot -pALUNOS < \"" + path + "\\MySqlbackup.sql\"");
            }

            sw.Close();
        }

        private static void MySqlProcess(string Path)
        {
            //cria o processo a correr o MySqlbackup.cmd
            Process.Start(Path + "\\MySqlbackup.cmd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 100;

            //quando executar fara o codigo seguinte

            //exemplo do path
            string path = "D:";

            MysqlBackup_Restore(path, "restore");

            //corre uma thread com o processo que faz o backup ou restore
            Thread t = new Thread(delegate() { MySqlProcess(path); });
            t.Start();

            progressBar1.Visible = false;
        }


    }
}
