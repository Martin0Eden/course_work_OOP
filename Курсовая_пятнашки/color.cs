﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;


namespace Курсовая_пятнашки
{
    internal class сolor : sql
    {
        public string type;

        public сolor(string table) : base(table) { }

        public DataTable fill()
        {
            string zap = $"SELECT * FROM {this.table}";
            SqlCommand cmd = new SqlCommand(zap, this.db.getConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(this.dt);
            return dt;

        }

        public static void cmena(string s, params Button[] buttons)
        {
            for(int i=0; i<buttons.Length; i++)
                buttons[i].Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(
                                s));
        }


       
    }
}
