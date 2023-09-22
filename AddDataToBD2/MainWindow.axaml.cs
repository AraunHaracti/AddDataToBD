using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MySql.Data.MySqlClient;

namespace AddDataToBD2;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        ShowTable();
    }

    private void ShowTable()
    {
        string sql = "select * from status;";

        List<Status> _statuses = new List<Status>();
        
        DBConnection.Open();

        MySqlDataReader reader = DBConnection.GetData(sql);

        while (reader.Read() && reader.HasRows)
        {
            var currentTrainer = new Status()
            {
                StatusId = reader.GetInt32("StatusID"),
                Name = reader.GetString("Name"),
            };
            
            _statuses.Add(currentTrainer);
        }
        DBConnection.Exit();
        StatusGrid.ItemsSource = _statuses;
    }
}