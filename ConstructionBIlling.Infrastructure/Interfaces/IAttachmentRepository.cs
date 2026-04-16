using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on attachments.
    /// </summary>
    public interface IAttachmentRepository
    {
        Task<string> UpdateFilepathdata(string target, int id, string filesList, string TypeofFile);

    }
}
