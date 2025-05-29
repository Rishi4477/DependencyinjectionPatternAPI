using APIModels;
using EntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityFrameWork
{
    public class DBLayer
    {
        private readonly RamayaMedicalCartContext _context;
        public DBLayer(RamayaMedicalCartContext ramayaMedicalCartContext)
        {
            _context = ramayaMedicalCartContext;
        }
        //Category
        public async Task<CategoryModel?> GetCategories(CancellationToken cancelationToken)
        {
            var result = await _context.Categories.Select(c => new CategoryModel
            {

                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Descriptions = c.Descriptions,
            }).FirstOrDefaultAsync(cancelationToken);

            return result;
        }
        // Method to get a single customer
        //Customers
        public async Task<IEnumerable<CustomersModel?>> GetCustomers(CancellationToken cancellationToken)
        {
            var i = await _context.Customers
                .Select(c => new CustomersModel
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    ContactName = c.ContactName,
                    CoustmerAddress = c.CoustmerAddress,
                    City = c.City,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    States = c.States
                    // Add any other customer properties here as needed
                })
                .ToListAsync(cancellationToken);

            return i;
        }
        //Employees
        public async Task<EmployeesModel?> GetEmployees(CancellationToken cancelationToken)
        {
            var h = await _context.Employees
                .Select(e => new EmployeesModel
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Notes = e.Notes,
                }).FirstOrDefaultAsync(cancelationToken);
            return h;
        }
        //orders
        public async Task<OrdersModel?> GetOrder(CancellationToken cancelationToken)
        {
            var g = await _context.Orders
                .Select(h => new OrdersModel
                {
                    OrderId = h.OrderId,
                    CustomerId = h.CustomerId,
                    EmployeeId = h.EmployeeId,
                    OrderDate = h.OrderDate,
                    ShipperId = h.ShipperId,
                }).FirstOrDefaultAsync(cancelationToken);
            return g;
        }
        //OrderDetails
        public  Task<OrderDetailModel?> GetOrderDetails(CancellationToken cancellation)
        {
            //var l = await _context.OrderDetails
            //    .Select(s => new OrderDetailModel
            //    { 
            //        OrderDetailId = s.OrderDetailId,
            //        OrderId = s.OrderId,
            //        ProductId = s.ProductId,
            //        Quantity = s.Quantity,
            //    }).FirstOrDefaultAsync(cancellation);
            //return l;

            //by performing jooiins -------------------------------------------------------------------------------------------------------------
            var l=  (from ordDet in _context.OrderDetails
                   join prod in _context.Products on ordDet.ProductId equals prod.ProductId
                   select new OrderDetailModel
                   {
                       OrderDetailId = ordDet.OrderDetailId,
                       OrderId = ordDet.OrderId,
                       ProductId = prod.ProductId,
                       Quantity = ordDet.Quantity,
                       productName = prod.ProductName,
                   }).FirstOrDefaultAsync(cancellation);

            return l;
        }
        //products

        public async Task<ProductsModel?> GetProducts(CancellationToken cancellation)
        {
            var k = await _context.Products
                .Select(p => new ProductsModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    SupplierId = p.SupplierId,
                    CategoryId = p.CategoryId,
                    Price = p.Price,
                }).FirstOrDefaultAsync(cancellation);
            return k;
        }
        //shippers

        public async Task<ShippersModel?> GetShippers(CancellationToken cancellation)
        {
            var j = await _context.Shippers
                .Select(s => new ShippersModel
                {
                    ShipperId = s.ShipperId,
                    ShipperName = s.ShipperName,
                    Phone = s.Phone,

                }).FirstOrDefaultAsync(cancellation);
            return j;
        }

        public async Task<SuppliersModel?> GetSuppliers(CancellationToken cancellation)
        {
            var w = await _context.Suppliers
                .Select(d => new SuppliersModel
                {
                    SupplierId = d.SupplierId,
                    SupplierName = d.SupplierName,
                    ContactName = d.ContactName,
                    Addres = d.Addres,
                    City = d.City,
                    PostalCode = d.PostalCode,
                    Country = d.Country,
                    Phone = d.Phone,


                }).FirstOrDefaultAsync(cancellation);
            return w;
        }

        public async Task<bool> SaveCategories(string categoryName, string categoryDescription, CancellationToken cancellationToken)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = categoryName,
                Descriptions = categoryDescription,
            });
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> SaveShippers(string shipperName, string shipperPhone, CancellationToken cancellationToken)
        {
            var imaxShipperId = await _context.Shippers.MaxAsync(c => c.ShipperId);


            _context.Shippers.Add(new Shipper     //rishi edhi apudu use chesukovali antey it will automatically increarease the id value
            {
                ShipperId = imaxShipperId + 1,
                ShipperName = shipperName,
                Phone = shipperPhone,
            });
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<int> SaveEmployee(string firstName, string lastName, string notes,string Photo, CancellationToken cancellationToken)
        {
            var imaxEmployeeId = await _context.Employees.MaxAsync(d => d.EmployeeId);

            _context.Employees.Add(new Employee
            {
                EmployeeId = imaxEmployeeId + 1,
                FirstName = firstName,
                LastName = lastName,
                Photo=Photo,
                Notes = notes,
            });
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<bool> SaveCustomers(string CustomerName, string ContactName, string CoustmerAddress, string City, string PostalCode, string Country, string States, CancellationToken cancellationToken)
        {
            try
            {
                var imaxCustomers = await _context.Customers.MaxAsync(c => c.CustomerId);

                _context.Customers.Add(new Customer
                {
                    CustomerId = imaxCustomers + 1,
                    CustomerName = CustomerName,
                    ContactName = ContactName,
                    CoustmerAddress = CoustmerAddress,
                    City = City,
                    PostalCode = PostalCode,
                    Country = Country,
                    States = States
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to post the data:", ex.Message);
                return false;
            }
            finally
            {
                Console.WriteLine();

            }
        }

        public async Task<int> SaveSuppliers(string SupplierName, string ContactName, string Address, string City, string PostalCode, string Country, string Phone)
        {
            var imaxsuppliers = await _context.Suppliers.MaxAsync(a => a.SupplierId);

            _context.Suppliers.Add(new Supplier
             {
                SupplierId = imaxsuppliers + 1,
                SupplierName = SupplierName,
                ContactName = ContactName,
                Addres = Address,
                City = City,
                PostalCode = PostalCode,
                Country = Country,
                Phone = Phone
            });
            await _context.SaveChangesAsync();
            return 1;
        }
        //searching by id (after save details tharwatha rasinam rishi)
        public async Task<CategoryModel?> GetCategories(int iCategoryID, CancellationToken cancelationToken)
        {

            var result = await _context.Categories
                .Where(c => c.CategoryId == iCategoryID)
                .Select(c => new CategoryModel
                {

                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Descriptions = c.Descriptions,
                }).FirstOrDefaultAsync(cancelationToken);
            return result;
        }
        //searching by CusstomerId
        public async Task<CustomersModel?> GetCustomers(int iCustomerID, CancellationToken cancellationToken)
        {

            var l = await _context.Customers
                .Where(c => c.CustomerId == iCustomerID)
                .Select(c => new CustomersModel
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    ContactName = c.ContactName,
                    City = c.City,
                    Country = c.Country,
                    States = c.States,
                    PostalCode = c.PostalCode


                }).FirstOrDefaultAsync(cancellationToken);
            return l;
        }
        public async Task<OrderDetailModel?> GetOrderdetailsbyOrderIdandproductID(int iOrderDetailId, CancellationToken cancellationToken)
        {
            var s = await _context.OrderDetails
                .Where(b => b.OrderDetailId == iOrderDetailId)
                .Select(b => new OrderDetailModel
                {
                    OrderDetailId = b.OrderDetailId,
                    OrderId = b.OrderId,
                    ProductId = b.ProductId,
                    Quantity = b.Quantity,

                }).FirstOrDefaultAsync(cancellationToken);
            return s;
        }

        //for users
        public async Task<UsersModel?> GetUsersbyidandpsw(string iUserName, string iPassword, CancellationToken cancellationToken)
        {
            var result = await _context.Users
                .Where(b => b.UserName == iUserName && b.Password == iPassword)
                .Select(b => new UsersModel
                {
                    UserId = b.UserId,
                    UserName = b.UserName,
                    Password = b.Password,
                    LoginTimeDate = b.LoginTimeDate,
                    IsAdmin = b.IsAdmin,
                    IsEmployee = b.IsEmployee,
                }).FirstOrDefaultAsync(cancellationToken);
            return result;
        }


        //to validate the user in database  
        public async Task<bool?> GetUserExist(string userName ,CancellationToken cancellation)
        {
            bool isValidUser = false;
            var result = await _context.Users
                .Where(d => d.UserName == userName)
                .Select(c => new UsersModel
                {
                    UserName = c.UserName

                }).FirstOrDefaultAsync(cancellation);
            return isValidUser = string.IsNullOrEmpty(result?.UserName) ? false : true; // t or f will check it where the user exists or not

        }


        //for newUser Regristartion save in database

        public async Task<int> SaveNewregistartion(string Name, string Email, string MobileNumber, string Password, CancellationToken cancellationToken)
         {
            try
            {
                ///rishi this method will trigger the data from newreg - users when someone rigister and its will also save in users data
                _context.Newregistrations.Add(new Newregistration
                {
                    Name = Name,
                    Email = Email,
                    MobileNumber = MobileNumber,
                    Password = Password,
                });
              

                _context.Users.Add(new User
                {
                    UserName = Name,
                    Password = Password,
                    IsAdmin=false,
                    IsEmployee=false,
                });
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Post the Data", ex.Message);
                return 0;
            }
            finally
            {
                Console.WriteLine();
            }

        }
    }
}
