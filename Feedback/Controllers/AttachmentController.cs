using System.Net.Mail;
namespace Feedback.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using M = Feedback.Models;
using Feedback.Repositories;

// [ApiControler]
// [Route("attachment")]
// public class AttachmentController : Controller
// {
//     IEntityRepository<M.Attachment> _repo;
//     public AttachmentController(IEntityRepository<Attachment> repo) 
//         { _repo = repo; }
//     public async Task<Guid> Create([FromBody] M.Attachment attach) {
//         Guid newGuid = new();
//         attach.Id = newGuid;
//         _repo.Insert(attach);

//         return newGuid;
//     }
// }