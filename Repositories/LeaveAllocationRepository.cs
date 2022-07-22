using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public LeaveAllocationRepository(ApplicationDbContext context, 
            UserManager<Employee> userManager,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper) 
            : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }

        public async Task AllocateLeaveAsync(int leaveTypeId)
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await leaveTypeRepository.GetByIdAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>(); 
            foreach(var employee in employees)
            {
                if(! await AllocationExistsAsync(employee.Id, leaveTypeId, period))
                {
                    allocations.Add(new LeaveAllocation
                    {
                        EmployeeId = employee.Id,
                        Period = period,
                        LeaveTypeId = leaveTypeId,
                        NumberOfDays = leaveType.DefaultDays
                    });
                }
            }

            await AddRangeAsync(allocations);
        }

        public async Task<bool> AllocationExistsAsync(string employeeId, int leaveTypeId, int period)
        {
            return await context.LeaveAllocation.AnyAsync(x =>
                x.EmployeeId == employeeId &&
                x.LeaveTypeId == leaveTypeId &&
                x.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocationsAsync(string employeeId)
        {
            var allocations = await context.LeaveAllocation
                .Include(a => a.LeaveType)
                .Where(x =>
                x.EmployeeId == employeeId).ToListAsync();
            var employee = await userManager.FindByIdAsync(employeeId);
            var employeeAllocationModel = mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.LeaveAllocations = mapper.Map<List<LeaveAllocationVM>>(allocations);
            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocationAsync(int id)
        {
            var leaveAllocation = await GetByIdAsync(id);
            if (leaveAllocation == null)
            {
                return null;
            }
            var leaveAllocationVM = mapper.Map<LeaveAllocationEditVM>(leaveAllocation);
            leaveAllocationVM.Employee = mapper.Map<EmployeeListVM>(await 
                userManager.FindByIdAsync(leaveAllocation.EmployeeId));
            leaveAllocationVM.LeaveType = mapper.Map<LeaveTypeVM>( await 
                leaveTypeRepository.GetByIdAsync(leaveAllocation.LeaveTypeId));
            return leaveAllocationVM;
        }

        public async Task UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetByIdAsync(model.Id);
            if (leaveAllocation == null)
            {
                throw new ApplicationException("leave allocation not found");
            }
            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(leaveAllocation);
        }
    }
}
