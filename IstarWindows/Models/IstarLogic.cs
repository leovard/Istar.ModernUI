using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace IstarWindows.Models
{
    public class IstarLogic : IDisposable
    {
        private bool _disposed;
        private readonly IstarContext _context;
        public IstarContext Context { get; set; }

        public IstarLogic()
        {
            _context = new IstarContext();
        }

        public ICollection<Job> GetJobs()
        {
            return _context.Jobs.ToList();
        }

        public void AddNewJob(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public void UpdateCurrentJob(Job job)
        {
            var entity = _context.Jobs.Find(job.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(job).CurrentValues.SetValues(job);
            _context.SaveChanges();
        }

        public void CancelUpdateCurrentJob(Job job)
        {
            var entity = _context.Jobs.Find(job.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(job).Reload();
        }

        public void DeleteCurrentJob(Job job)
        {
            var jobToUpdate = _context.Jobs.SingleOrDefault(e => e.Id == job.Id);
            if (jobToUpdate == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Jobs.Remove(jobToUpdate);
            _context.SaveChanges();
        }

        public ICollection<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }

        public void AddNewCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void UpdateCurrentCompany(Company company)
        {
            var entity = _context.Companies.Find(company.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(company).CurrentValues.SetValues(company);
            _context.SaveChanges();
        }

        public void CancelUpdateCurrentCompany(Company company)
        {
            var entity = _context.Companies.Find(company.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(company).Reload();
        }

        public void DeleteCurrentCompany(Company company)
        {
            var companyToUpdate = _context.Companies.SingleOrDefault(e => e.Id == company.Id);
            if (companyToUpdate == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Companies.Remove(companyToUpdate);
            _context.SaveChanges();
        }

        public ICollection<Building> GetBuildings()
        {
            return _context.Buildings.ToList();
        }

        public void AddNewBuilding(Building building)
        {
            _context.Buildings.Add(building);
            _context.SaveChanges();
        }

        public void UpdateCurrentBuilding(Building building)
        {
            var entity = _context.Buildings.Find(building.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(building).CurrentValues.SetValues(building);
            _context.SaveChanges();
        }

        public void CancelUpdateCurrentBuilding(Building building)
        {
            var entity = _context.Buildings.Find(building.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(building).Reload();
        }

        public void DeleteCurrentBuilding(Building building)
        {
            var buildingToUpdate = _context.Buildings.SingleOrDefault(e => e.Id == building.Id);
            if (buildingToUpdate == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Buildings.Remove(buildingToUpdate);
            _context.SaveChanges();
        }

        public ICollection<Office> GetOffices()
        {
            return _context.Offices.ToList();
        }

        public void AddNewOffice(Office office)
        {
            _context.Offices.Add(office);
            _context.SaveChanges();
        }

        public void UpdateCurrentOffice(Office office)
        {
            var entity = _context.Offices.Find(office.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(office).CurrentValues.SetValues(office);
            _context.SaveChanges();
        }

        public void CancelUpdateCurrentOffice(Office office)
        {
            var entity = _context.Offices.Find(office.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(office).Reload();
        }

        public void DeleteCurrentOffice(Office office)
        {
            var officeToUpdate = _context.Offices.SingleOrDefault(e => e.Id == office.Id);
            if (officeToUpdate == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Offices.Remove(officeToUpdate);
            _context.SaveChanges();
        }

        public ICollection<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public void AddNewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCurrentCustomer(Customer customer)
        {
            var entity = _context.Customers.Find(customer.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(customer).CurrentValues.SetValues(customer);
            _context.SaveChanges();
        }

        public void CancelUpdateCurrentCustomer(Customer customer)
        {
            var entity = _context.Customers.Find(customer.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(customer).Reload();
        }

        public void DeleteCurrentCustomer(Customer customer)
        {
            var customerToUpdate = _context.Customers.SingleOrDefault(e => e.Id == customer.Id);
            if (customerToUpdate == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Customers.Remove(customerToUpdate);
            _context.SaveChanges();
        }

        public ICollection<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        public void AddNewService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateCurrentService(Service service)
        {
            var entity = _context.Services.Find(service.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(service).CurrentValues.SetValues(service);
            _context.SaveChanges();
        }

        public void CancelUpdateCurrentService(Service service)
        {
            var entity = _context.Services.Find(service.Id);
            if (entity == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Entry(service).Reload();
        }

        public void DeleteCurrentService(Service service)
        {
            var serviceToUpdate = _context.Services.SingleOrDefault(e => e.Id == service.Id);
            if (serviceToUpdate == null)
            {
                MessageBox.Show("Данная сущность не найдена.", "Ошибка!", MessageBoxButton.OK);
                return;
            }
            _context.Services.Remove(serviceToUpdate);
            _context.SaveChanges();
        }

        #region Implementing IDispose

        private void Dispose(bool disposing)
        {
            if (_disposed || (!disposing))
            {
                return;
            }
            _context?.Dispose();
            _disposed = true;
        }

        void IDisposable.Dispose()
        {
            IDisposable_Dispose();
        }

        public void IDisposable_Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
