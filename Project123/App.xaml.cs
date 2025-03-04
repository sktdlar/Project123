﻿using Project123.Components.DataBase;
using Project123.Components.Pages;
using Project123.Components.UserControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Project123
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static ProductManagementEntities db = new ProductManagementEntities();
        public static MainWindow mainWindow;
        public static ProductListPage productListPage;
        public static ProductUC productUC;

    }
}
