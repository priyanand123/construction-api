using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionBilling.Application.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="attachmentService"/> class.
        /// </summary>
        /// <param name="attachmentRepository">The repository for accessing attachmentDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public AttachmentService(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }


        public virtual async Task<string> UpdateFilepathdata(string target, int id, string files, string TypeofUser)
        {
            try
            {
                return await _attachmentRepository.UpdateFilepathdata(target, id, files, TypeofUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
