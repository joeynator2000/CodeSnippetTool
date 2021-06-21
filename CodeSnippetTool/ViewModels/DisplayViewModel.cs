﻿using CodeSnippetTool.classes;
using CodeSnippetTool.Commands;
using CodeSnippetTool.Db;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CodeSnippetTool.ViewModels
{
    public class DisplayViewModel : ViewModelBase
    {
        public ICommand NavigateAddingCommand { get; set; }

        public DisplayCommand DisplayCommand { get; set; }
        public DisplayParamCommand DisplayParamCommand { get; set; }

        private Grid _snippetContainer;

        public Grid SnippetContainer
        {
            get
            {
                return _snippetContainer;
            }
            set
            {
                _snippetContainer = value;
                OnPropertyChanged(nameof(SnippetContainer));
            }
        }

        private DataTable snippetsTable;

        public DataTable SnippetsTable
        {
            get
            {
                return snippetsTable;
            }
            set
            {
                snippetsTable = value;
                OnPropertyChanged(nameof(SnippetsTable));
                //NotifyPropertyChanged("SizeQuantityTable");
            }
        }




        public DisplayViewModel(NavigationStore navigationStore)
        {
            NavigateAddingCommand = new NavigateCommand<AddingViewModel>(new NavigationService<AddingViewModel>(navigationStore, () => new AddingViewModel(navigationStore)));
            this.DisplayCommand = new DisplayCommand(this);
            this.DisplayParamCommand = new DisplayParamCommand(this);
            //------------------------------------------------
                        
            
            this.SnippetsTable = new DataTable();

            DbConnect conn = new DbConnect();
            DbSelect dbSelect = new DbSelect(conn.databaseConnection);
            List<Snippet> snippets = dbSelect.selectAll();

            DataColumn keyWordColumn = new DataColumn();
            keyWordColumn.ColumnName = "Key Word";
            this.SnippetsTable.Columns.Add(keyWordColumn);

            DataColumn descriptionColumn = new DataColumn();
            descriptionColumn.ColumnName = "Descrption";
            this.SnippetsTable.Columns.Add(descriptionColumn);

            DataColumn lastUsedColumn = new DataColumn();
            lastUsedColumn.ColumnName = "Last used date";
            this.SnippetsTable.Columns.Add(lastUsedColumn);


            for (int i = 0; i < snippets.Count; i++)
            {
                Snippet snp = snippets[i];


                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = snp.lang;
                txtBlock.FontSize = 20;
                txtBlock.VerticalAlignment = VerticalAlignment.Center;
                txtBlock.HorizontalAlignment = HorizontalAlignment.Center;


                DataRow row = this.SnippetsTable.NewRow();
                row[keyWordColumn] = snp.lang;
                row[descriptionColumn] = snp.description;
                row[lastUsedColumn] = snp.last_copied;
                this.SnippetsTable.Rows.Add(row);
                //TextBlock snippetDescr = new TextBlock();
                //snippetDescr.Text = snp.snippet_text;
                //snippetDescr.FontSize = 20;
                //snippetDescr.VerticalAlignment = VerticalAlignment.Center;
                //snippetDescr.HorizontalAlignment = HorizontalAlignment.Center;
                //SnippetContainer.Children.Add(snippetDescr);
                //Grid.SetColumn(snippetDescr, 1);
                //Grid.SetRow(snippetDescr, i);

            }

            //for(int j = 0; j < 20; j++)
            //{
            //    DataRow row = this.SnippetsTable.NewRow();
            //    row[keyWordColumn] = "cs";
            //    row[descriptionColumn] = "ss";
            //    row[lastUsedColumn] = "snp";
            //    this.SnippetsTable.Rows.Add(row);
            //}
        }

        public void getDataFromDb()
        {
            //Grid.RowSpan = "{Binding SnippetContainer, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
            DbConnect conn = new DbConnect();
            DbSelect dbSelect = new DbSelect(conn.databaseConnection);
            //dbSelect.selectSnippet(1);
            List<Snippet> snippets = dbSelect.selectAll();

            //RowDefinition row = new RowDefinition();
            //row.Height = new GridLength(50);

            //ColumnDefinition col = new ColumnDefinition();
            //col.Name = "cos";
            SnippetContainer= new Grid();
            


            for (int i = 0; i < snippets.Count; i++)
            {
                Snippet snp = snippets[i];

                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(50);
                this.SnippetContainer.RowDefinitions.Add(row);

                //ColumnDefinition col = new ColumnDefinition();
                //col.Name = "cos";

                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = snp.lang;
                txtBlock.FontSize = 20;
                txtBlock.VerticalAlignment = VerticalAlignment.Center;
                txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
                SnippetContainer.Children.Add(txtBlock);
                Grid.SetColumn(txtBlock, 0);
                Grid.SetRow(txtBlock, i);


                TextBlock snippetDescr = new TextBlock();
                snippetDescr.Text = snp.snippet_text;
                snippetDescr.FontSize = 20;
                snippetDescr.VerticalAlignment = VerticalAlignment.Center;
                snippetDescr.HorizontalAlignment = HorizontalAlignment.Center;
                SnippetContainer.Children.Add(snippetDescr);
                Grid.SetColumn(snippetDescr, 1);
                Grid.SetRow(snippetDescr, i);

            }

        }

        public void ParameterMethod(string person)
        {
            MessageBox.Show($"Snippet: {person} Description: ");
        }

        public void simpleMethod()
        {
            //Debug.WriteLine("cos");
            MessageBox.Show($"Snippet: Description: ");
        }
    }
}
