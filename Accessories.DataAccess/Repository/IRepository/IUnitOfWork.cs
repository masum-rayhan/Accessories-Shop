using Accessories.DataAccess.Repository.IRepository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessories.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    IBlobService BlobService { get; }
}
