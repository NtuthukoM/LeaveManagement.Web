using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>,
        ILeaveRequestRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;

        public LeaveRequestRepository(ApplicationDbContext context,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            UserManager<Employee> userManager,
            ILeaveAllocationRepository leaveAllocationRepository) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContext = httpContext;
            this.userManager = userManager;
            this.leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task CancelRequest(int id)
        {
            var request = await GetByIdAsync(id);
            if(request != null)
            {
                request.Canceled = true;
                await UpdateAsync(request);
            }
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetByIdAsync(leaveRequestId);
            if(leaveRequest != null)
            {
                leaveRequest.Approved = approved;
                if (approved)
                {
                    var allocation = await leaveAllocationRepository.GetEmployeeAllocationAsync(leaveRequest.RequestingEmployeeId,
                        leaveRequest.LeaveTypeId);
                    int daysReqquested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                    if(allocation != null)
                    {
                        allocation.NumberOfDays -= daysReqquested;
                        await leaveAllocationRepository.UpdateAsync(allocation);
                    }
                }
                await UpdateAsync(leaveRequest);
            }

        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await userManager.GetUserAsync(httpContext.HttpContext?.User);            
            var leaveRequest = mapper.Map<LeaveRequest>(model);
            var leaveAllocation = await leaveAllocationRepository.GetEmployeeAllocationAsync(leaveRequest.RequestingEmployeeId,
                leaveRequest.LeaveTypeId);
            if(leaveAllocation == null)
            {
                throw new ApplicationException("No leave allocated to this employee.");
            }
            int days = (int)((model.EndDate - model.StartDate)?.TotalDays ?? 0);
            if(days > leaveAllocation.NumberOfDays)
            {
                throw new ApplicationException("Not enough leave allocated to this employee.");
            }
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;
            await AddAsync(leaveRequest);
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await context.LeaveRequests.Include(x =>
                x.LeaveType).ToListAsync();

            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                PendingRequests = leaveRequests.Count(x => x.Approved == null),
                ApprovedRequests = leaveRequests.Count(x => x.Approved == true),
                RejectedRequests = leaveRequests.Count(x => x.Approved == false),
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };
            foreach(var request in model.LeaveRequests)
            {
                var emp = await userManager.FindByIdAsync(request.RequestingEmployeeId);
                request.Employee = mapper.Map<EmployeeListVM>(emp);
            }
            return model;
        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await context.LeaveRequests.Where(x => 
                x.RequestingEmployeeId == employeeId)
                .ToListAsync();
                
        }

        public async Task<LeaveRequestVM> GetLeaveRequestAsync(int id)
        {
            var model = await context.LeaveRequests.Include(x => x.LeaveType)
                .FirstAsync(x => x.Id == id);
            if(model == null)
            {
                throw new ApplicationException("Leave request not found");
            }
            var request = mapper.Map<LeaveRequestVM>(model);
            var user = await userManager.FindByIdAsync(model.RequestingEmployeeId);
            request.Employee = mapper.Map<EmployeeListVM>(user);
            return request;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await userManager.GetUserAsync(httpContext.HttpContext?.User);
            var allocations = (await leaveAllocationRepository
                .GetEmployeeAllocationsAsync(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);
            var model = new EmployeeLeaveRequestViewVM
            {
                LeaveAllocations = allocations,
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(requests)
            };

            return model;
        }
    }
}
