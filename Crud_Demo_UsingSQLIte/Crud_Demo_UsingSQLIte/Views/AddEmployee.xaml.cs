using Crud_Demo_UsingSQLIte.Models;
using Crud_Demo_UsingSQLIte.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crud_Demo_UsingSQLIte.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmployee : ContentPage
    {
        EmployeeService _services;
        bool _isUpdate;
        int employeeID;
        public AddEmployee()
        {
            InitializeComponent();
            _services = new EmployeeService();
            _isUpdate = false;
        }
        public AddEmployee(EmployeeModel obj)
        {
            InitializeComponent();
            _services = new EmployeeService();
            if (obj != null)
            {
                employeeID = obj.Id;
                txtName.Text = obj.Name;
                txtEmail.Text = obj.Email;
                txtAddress.Text = obj.Address;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            EmployeeModel obj = new EmployeeModel();
            obj.Name = txtName.Text;
            obj.Email = txtEmail.Text;
            obj.Address = txtAddress.Text;
            if (_isUpdate)
            {
                obj.Id = employeeID;
                await _services.UpdateEmployee(obj);
            }
            else
            {
                _services.InsertEmployee(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}