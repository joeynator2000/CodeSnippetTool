using CodeSnippetTool.classes;
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

        private DataTable sizeQuantityTable;

        public DataTable SizeQuantityTable
        {
            get
            {
                return sizeQuantityTable;
            }
            set
            {
                sizeQuantityTable = value;
                OnPropertyChanged(nameof(SizeQuantityTable));
                //NotifyPropertyChanged("SizeQuantityTable");
            }
        }




        public DisplayViewModel(NavigationStore navigationStore)
        {
            NavigateAddingCommand = new NavigateCommand<AddingViewModel>(new NavigationService<AddingViewModel>(navigationStore, () => new AddingViewModel(navigationStore)));
            this.DisplayCommand = new DisplayCommand(this);
            this.DisplayParamCommand = new DisplayParamCommand(this);
            //------------------------------------------------
                        
            
            this.SizeQuantityTable = new DataTable();

            DbConnect conn = new DbConnect();
            DbSelect dbSelect = new DbSelect(conn.databaseConnection);
            List<Snippet> snippets = dbSelect.selectAll();

            DataColumn keyWordColumn = new DataColumn();
            keyWordColumn.ColumnName = "Key Word";
            this.SizeQuantityTable.Columns.Add(keyWordColumn);

            DataColumn descriptionColumn = new DataColumn();
            descriptionColumn.ColumnName = "Descrption";
            this.SizeQuantityTable.Columns.Add(descriptionColumn);

            DataColumn lastUsedColumn = new DataColumn();
            lastUsedColumn.ColumnName = "Last used date";
            this.SizeQuantityTable.Columns.Add(lastUsedColumn);


            for (int i = 0; i < snippets.Count; i++)
            {
                Snippet snp = snippets[i];


                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = snp.lang;
                txtBlock.FontSize = 20;
                txtBlock.VerticalAlignment = VerticalAlignment.Center;
                txtBlock.HorizontalAlignment = HorizontalAlignment.Center;


                DataRow row = this.SizeQuantityTable.NewRow();
                row[keyWordColumn] = snp.lang;
                row[descriptionColumn] = snp.description;
                row[lastUsedColumn] = snp.last_copied;
                this.SizeQuantityTable.Rows.Add(row);



                //TextBlock snippetDescr = new TextBlock();
                //snippetDescr.Text = snp.snippet_text;
                //snippetDescr.FontSize = 20;
                //snippetDescr.VerticalAlignment = VerticalAlignment.Center;
                //snippetDescr.HorizontalAlignment = HorizontalAlignment.Center;
                //SnippetContainer.Children.Add(snippetDescr);
                //Grid.SetColumn(snippetDescr, 1);
                //Grid.SetRow(snippetDescr, i);

            }

            //DataColumn sizeQuantityColumn = new DataColumn();
            //sizeQuantityColumn.ColumnName = "Size Quantity";
            //this.SizeQuantityTable.Columns.Add(sizeQuantityColumn);

            //DataColumn sColumn = new DataColumn();
            //sColumn.ColumnName = "S";
            //this.SizeQuantityTable.Columns.Add(sColumn);

            //DataColumn mColumn = new DataColumn();
            //mColumn.ColumnName = "M";
            //this.SizeQuantityTable.Columns.Add(mColumn);

            //DataRow row1 = this.SizeQuantityTable.NewRow();
            //row1[sizeQuantityColumn] = "Blue";
            //row1[sColumn] = "12";
            //row1[mColumn] = "15";
            //this.SizeQuantityTable.Rows.Add(row1);

            //DataRow row2 = this.SizeQuantityTable.NewRow();
            //row2[sizeQuantityColumn] = "Red";
            //row2[sColumn] = "18";
            //row2[mColumn] = "21";
            //this.SizeQuantityTable.Rows.Add(row2);

            //DataRow row3 = this.SizeQuantityTable.NewRow();
            //row3[sizeQuantityColumn] = "Green";
            //row3[sColumn] = "24";
            //row3[mColumn] = "27";
            //this.SizeQuantityTable.Rows.Add(row3);

            //DataRow row4 = this.SizeQuantityTable.NewRow();
            //row4[sizeQuantityColumn] = "Yellow";
            //row4[sColumn] = "30";
            //row4[mColumn] = "33";
            //this.SizeQuantityTable.Rows.Add(row4);
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
