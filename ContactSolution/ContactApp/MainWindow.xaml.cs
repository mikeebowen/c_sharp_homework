using ContactApp.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ContactApp
{
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private ContactModel selectedContact;
        public MainWindow()
        {
            InitializeComponent();

            LoadContacts();
        }

        private void LoadContacts()
        {
            var contacts = App.ContactRepository.GetAll();

            uxContactList.ItemsSource = contacts
                .Select(t => ContactModel.ToModel(t))
                .ToList();

            // OR
            //var uiContactModelList = new List<ContactModel>();
            //foreach (var repositoryContactModel in contacts)
            //{
            //    This is the .Select(t => ... )
            //    var uiContactModel = ContactModel.ToModel(repositoryContactModel);
            //
            //    uiContactModelList.Add(uiContactModel);
            //}

            //uxContactList.ItemsSource = uiContactModelList;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.ContactRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());

                LoadContacts();
            }
        }
        private void editContact()
        {
            var window = new ContactWindow();
            window.Contact = selectedContact;

            if (window.ShowDialog() == true)
            {
                App.ContactRepository.Update(window.Contact.ToRepositoryModel());
                LoadContacts();
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            editContact();
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedContact != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ContactRepository.Remove(selectedContact.Id);
            selectedContact = null;
            LoadContacts();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedContact != null);
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }

        private void lvUsersColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = (sender as GridViewColumnHeader);
            string sortBy = header.Tag.ToString();
            ListSortDirection newDir = listViewSortCol == header && uxContactList.Items.SortDescriptions.LastOrDefault().Direction == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            listViewSortCol = header;
            uxContactList.Items.SortDescriptions.Clear();
            uxContactList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }
        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (ContactModel)uxContactList.SelectedValue;
        }

        private void uxContactList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            editContact();
        }
    }
}