using APIModels;

namespace BusinessLogic
{
    public interface IBusinessLogic
    {
        Task<CategoryModel?> GetCategories(CancellationToken cancelationToken);

        Task<IEnumerable< CustomersModel?>> GetCustomers(string customerName, CancellationToken cancelationToken);

        Task<EmployeesModel?> GetEmployees(CancellationToken cancelationToken);

        Task<OrdersModel?> GetOrders(CancellationToken cancelationToken);

        Task<OrderDetailModel?>GetOrderDetails(CancellationToken cancelationToken);

        Task<ProductsModel?> GetProducts(CancellationToken cancelationToken);

        Task<ShippersModel?> GetShippers(CancellationToken cancelationToken);


        Task<SuppliersModel?> GetSuppliers(CancellationToken cancelationToken);
        Task<bool?> SaveCategories(string categoryName, string categoryDescription, CancellationToken cancellationToken);

      
        Task<bool?> SaveShippers(string shipperName, string shipperPhone, CancellationToken cancellationToken);
        // employees save
        Task<int> SaveEmployee(string FirstName,string LastName,string Notes,string Photo, CancellationToken cancellationToken);

        Task<bool> SaveCustomers(string CustomerName, string ContactName, string CoustmerAddress, string City, string PostalCode, string Country, string States , CancellationToken cancellationToken);
        Task<IEnumerable<CustomersModel?>> GetCustomers(CancellationToken cancelationToken);

        Task<int> SaveSuppliers(string SupplierName, string ContactName, string Address, string City, string PostalCode, string Country, string Phone);

        // Searching by CategoryID
        Task<CategoryModel?> GetCategories(int iCategoryID, CancellationToken cancelationToken);

        Task<CustomersModel?> GetCustomers(int iCustomerID,CancellationToken cancelationToken);

        Task<OrderDetailModel?> GetOrderdetailsbyOrderIdandproductID(int iOrderDetailId, CancellationToken cancellationToken);


        // for users

        Task<UsersModel?> GetUsersbyidandpsw(string iUserName,string iPassword ,CancellationToken cancelationToken);

        //for new regristartion

        Task<int> SaveNewregistartion(string Name, string Email, string MobileNumber,string Password, CancellationToken cancelationToken);


        //verifying the UserName
        Task<bool?>GetUserExist(string UserName, CancellationToken cancelationToken);



    }

}
