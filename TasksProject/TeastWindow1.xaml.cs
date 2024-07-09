using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TasksProject
{
    /// <summary>
    /// Interaction logic for TeastWindow1.xaml
    /// </summary>
    public partial class TeastWindow1 : Window
    {
        public ObservableCollection<UserHelper> AddUser { get; set; } = new ObservableCollection<UserHelper>();
        public ObservableCollection<UserHelper> Users { get; set; } = new ObservableCollection<UserHelper>();
        public TeastWindow1()
        {
            InitializeComponent();
            DataContext = this;
            UserDataContext dt = new UserDataContext();
            try
            {
                foreach (var add in dt.AddUsers.ToList())
                {
                    AddUser.Add(new UserHelper
                    {
                        Id = add.Id,
                        Name = add.Name.ToString(),
                    });
                }


                foreach (User user in dt.Users.ToList())
                {
                    Users.Add(new UserHelper
                    {
                        Id = user.Id,
                        Fulname = user.Fulname.ToString(),
                        Email = user.Email,
                        Userid = user.Userid,
                        Authan = user.Authan,
                        Phone = user.Phone,
                        Price = user.Price,
                        PriceRate = user.PriceRate,
                        Adds = AddUser.ToList(),
                    });

                }
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Fulname = txtNambook.Text,
                Userid = int.Parse(cobUserid.SelectedValue.ToString()),
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Authan = txtAuthan.Text,
                Price = double.Parse(txtPrice.Text),
                PriceRate = double.Parse(txtPriceRate.Text)

            };

            using (var db = new UserDataContext())
            {
                db.Users.Add(user);
                db.SaveChanges();

                var userhepler = new UserHelper
                {
                    Fulname = txtNambook.Text,
                    //Userid = int.Parse(cobUserid.SelectedValue.ToString()),
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Authan = txtAuthan.Text,
                    Price = double.Parse(txtPrice.Text),
                    PriceRate = double.Parse(txtPriceRate.Text)

                };

                Users.Add(userhepler);
            }
        }

        private void btnSavAll_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new UserDataContext())
            {
                System.Windows.MessageBox.Show(Users.Count.ToString());
                var allData = dataGraid.ItemsSource.Cast<UserHelper>().ToList();
                foreach (var item in dataGraid.ItemsSource)
                {
                    string fullname = (item as UserHelper)?.Fulname;
                    string Phone = (item as UserHelper)?.Phone;
                    string PriceRate = (item as UserHelper)?.PriceRate.ToString();
                    string Price = (item as UserHelper)?.Price.ToString();
                    string Email = (item as UserHelper)?.Email;
                    // قم بتنفيذ الإجراء المطلوب على كل صف هنا
                    // يمكنك الوصول إلى بيانات الصف الحالي عن طريق استخدام item
                }

                foreach (var item in Users)
                {
                    int selectedUserId = (int)item.Userid;
                    var user = new User
                    {
                        Id = item.Id,
                        Fulname = item.Fulname,
                        Userid = selectedUserId,
                        Phone = item.Phone,
                        Price = item.Price,
                        Authan = item.Authan,
                        Email = item.Email,
                        PriceRate = item.PriceRate
                    };
                    db.Users.Update(user);
                }
                db.SaveChanges();
                System.Windows.MessageBox.Show("تمت عمليه الحفظ بنجاح");
            }

        }


        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {

            var selecedUser = dataGraid.SelectedItem as UserHelper;
            if (selecedUser != null)
            {
                var context = new UserDataContext();
                var deleteuser = new User { Id = selecedUser.Id };
                context.Users.Remove(deleteuser);
                context.SaveChanges();

                Users.Remove(selecedUser);
            }
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = dataGraid.SelectedItem as UserHelper;
            int selectedUserId = (int)cobUserid.SelectedValue;
            //var user = new User
            //{
            //Id = selectedUser.Id,
            //    Userid = selectedUserId,
            //    Fulname = txtNambook.Text,
            //    Phone = txtPhone.Text,
            //    Email = txtEmail.Text,
            //    Authan = txtAuthan.Text,
            //    Price = double.Parse(txtPrice.Text),
            //    PriceRate = double.Parse(txtPriceRate.Text)
            //};


            try
            {

                using (var db = new UserDataContext())
                {
                    var checkUser = db.Users.FirstOrDefault(x => x.Id == selectedUser.Id);
                    if (checkUser != null)
                    {
                        checkUser.Id = selectedUser.Id;
                        checkUser.Userid = selectedUserId;
                        checkUser.Fulname = txtNambook.Text;
                        checkUser.Phone = txtPhone.Text;
                        checkUser.Email = txtEmail.Text;
                        checkUser.Authan = txtAuthan.Text;
                        checkUser.Price = double.Parse(txtPrice.Text);
                        checkUser.PriceRate = double.Parse(txtPriceRate.Text);
                    }


                    selectedUser.Fulname = txtNambook.Text;
                    selectedUser.Phone = txtPhone.Text;
                    selectedUser.Email = txtEmail.Text;
                    selectedUser.Authan = txtAuthan.Text;
                    selectedUser.Userid = selectedUserId;
                    selectedUser.Price = double.Parse(txtPrice.Text);
                    selectedUser.PriceRate = double.Parse(txtPriceRate.Text);
                    System.Windows.MessageBox.Show(txtAuthan.Text);
                    System.Windows.MessageBox.Show(selectedUser.Authan.ToString());

                    //db.Users.Update(selectedUser);
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("تمت عمليه التعديل بنجاح");

                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error updating user: {ex.Message}");
            }
        }

      
 

        private void btnedd_Click(object sender, RoutedEventArgs e)
        {

        }
        private int _selectedId;
        public int SelectedId
        {
            get { return _selectedId; }
            set
            {
                _selectedId = value;
                OnPropertyChanged(nameof(SelectedId));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string selectedId)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(selectedId));
        }
        private void dataGraid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = dataGraid.SelectedItem as UserHelper;
            if (selectedItem != null)
            {
                UserDataContext dt = new UserDataContext();
                var dtu=dt.AddUsers.FirstOrDefault(x=>x.Id==selectedItem.Userid);
                if (dtu != null)
                {
                    txtName.Text = dtu.Name;
                    txtuserName.Text = dtu.Username;
                    txtpass.Text=dtu.Pasword;
                }
                if (selectedItem != null && selectedItem.Fulname != null)
                {
                    txtNambook.Text = selectedItem.Fulname.ToString();
                    txtAuthan.Text = selectedItem.Authan.ToString();
                    txtEmail.Text = selectedItem.Email.ToString();
                    txtPhone.Text = selectedItem.Phone.ToString();
                    txtPrice.Text = selectedItem.Price.ToString();
                    txtPriceRate.Text = selectedItem.Price.ToString();
                    txtselectUserid.Text = selectedItem.Userid.ToString();
                    //txtselectUserid.Text = dataGraid.ComboBoxAddUser.SelectedValue.ToString();
                    if (selectedItem.Userid != null)
                    {
                        SelectedId = int.Parse(selectedItem.Userid.ToString());
                        txtselectUserid.Text = selectedItem.Userid.ToString();  // Assuming Userid is the property you want to display
                        cobUserid.SelectedValue = selectedItem.Userid.ToString();
                    }
                }

            }
        }
    }
}
