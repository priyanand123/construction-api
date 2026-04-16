using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on attachments.
    /// </summary>
    public interface IAttachmentService
    {
        Task<string> UpdateFilepathdata(string target, int id, string files, string TypeofUser);
    }
}
