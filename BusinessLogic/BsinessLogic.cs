using APIModels;
using EntityFrameWork;
using System.Net.Http.Headers;

namespace BusinessLogic
{
    public class BsinessLogic : IBusinessLogic
    {
        private readonly DBLayer _dbLayer; 
        public BsinessLogic(DBLayer dBLayer) //constructor 
        {
            _dbLayer = dBLayer;
        }
        public async Task<CategoryModel?> GetCategories(CancellationToken cancelationToken)
        {
           return await _dbLayer.GetCategories(cancelationToken);
        }
        public async Task<IEnumerable<CustomersModel?>> GetCustomers(CancellationToken cancelationToken)
        {
            return await _dbLayer.GetCustomers(cancelationToken);
        }

        public async Task <EmployeesModel?> GetEmployees(CancellationToken cancelationToken)
        {
            return await _dbLayer.GetEmployees(cancelationToken);
        }

        public async Task<OrderDetailModel?> GetOrderDetails(CancellationToken cancelationToken)
        {
            return await _dbLayer.GetOrderDetails(cancelationToken);
        }

        public async Task<OrdersModel?> GetOrders(CancellationToken cancelationToken)
        {
            return await _dbLayer.GetOrder(cancelationToken);
        }

        public async Task<ProductsModel?> GetProducts(CancellationToken cancelationToken)
        {
            return await _dbLayer.GetProducts(cancelationToken);
        }

        public async Task<ShippersModel?> GetShippers(CancellationToken cancelationToken)
        {
            return await _dbLayer.GetShippers(cancelationToken);
        }

        public async Task<SuppliersModel?> GetSuppliers(CancellationToken cancelationToken)
        {
            return await _dbLayer.GetSuppliers(cancelationToken);

        }

        public async Task<bool?> SaveCategories(string categoryName, string categoryDescription, CancellationToken cancellationToken)
        {
           return await _dbLayer.SaveCategories(categoryName, categoryDescription, cancellationToken);
        }

        public async  Task<bool?> SaveShippers(string shipperName, string shipperPhone, CancellationToken cancellationToken)
        {
            return await _dbLayer.SaveShippers(shipperName, shipperPhone, cancellationToken);
        }

        public async Task<int> SaveEmployee(string FirstName, string LastName, string Notes,string Photo, CancellationToken cancellationToken)
        {
            return await _dbLayer.SaveEmployee(FirstName,LastName, Notes, Photo, cancellationToken);
        }

        public async Task<bool> SaveCustomers(string CustomerName, string ContactName, string CoustmerAddress, string City, string PostalCode, string Country, string States, CancellationToken cancellationToken)
        {
            return await _dbLayer.SaveCustomers(CustomerName, ContactName, CoustmerAddress, City, PostalCode, Country, States, cancellationToken);
        }

        public async Task<IEnumerable<CustomersModel?>> GetCustomers(string customerName, CancellationToken cancelationToken)
        {
            return await _dbLayer.GetCustomers(cancelationToken);
        }

        public async Task<int> SaveSuppliers(string SupplierName, string ContactName, string Address, string City, string PostalCode, string Country, string Phone)
        {
            return await _dbLayer.SaveSuppliers(SupplierName, ContactName, Address, City, PostalCode,Country, Phone);
        }
        //searching by Ids
        public async Task<CategoryModel?> GetCategories(int iCategoryID, CancellationToken cancelationToken)
        {
            return await _dbLayer.GetCategories(iCategoryID, cancelationToken);
        }

        public async Task<CustomersModel?> GetCustomers(int iCustomerID, CancellationToken cancelationToken)
        {
            return await _dbLayer.GetCustomers(iCustomerID, cancelationToken);
        }

        public async Task<OrderDetailModel?> GetOrderdetailsbyOrderIdandproductID(int iOrderDetailId, CancellationToken cancellationToken)
        {
            return await _dbLayer.GetOrderdetailsbyOrderIdandproductID(iOrderDetailId,  cancellationToken);
        }

        public async Task<UsersModel?> GetUsersbyidandpsw(string iUserName, string iPassword, CancellationToken cancelationToken)
        {
            return await _dbLayer.GetUsersbyidandpsw(iUserName, iPassword, cancelationToken);
        }
        // for Newregistartion SAVE METHOD  change chesi
       
        public async Task<int> SaveNewregistartion(string Name, string Email, string MobileNumber, string Password, CancellationToken cancelationToken)
        {
            return await _dbLayer.SaveNewregistartion(Name,Email, MobileNumber, Password, cancelationToken);
        }
         
      

        //verifying the userName
        public async Task<bool?> GetUserExist(string UserName, CancellationToken cancelationToken)
        {
            return await _dbLayer.GetUserExist(UserName, cancelationToken);
        }  
    }
}
