using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace MRSTW.BusinessLogic.Service
{
    public class Service : IDisposable
	{
		protected T Success<T>() where T : ServiceResponse, new()
		{
            return new T { Success = true };
		}
		protected ServiceResponse Success()	=> Success<ServiceResponse>();

		protected ServiceResponse Failure(string message) => Failure<ServiceResponse>(message);
		protected T Failure<T>(string message) where T : ServiceResponse, new()
		{
			return new T { Success = false, Message = message };
		}

		protected EntriesServiceResponse<T> Entries<T>(IEnumerable<T> entries)
		{
			var r = Success<EntriesServiceResponse<T>>();
			r.Entries = entries;
			return r;
		}

		protected EntryServiceResponse<T> Entry<T>(T entry)
		{
			var r = Success<EntryServiceResponse<T>>();
			r.Entry = entry;
			return r;
		}

		public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

	public class ServiceResponse
	{
		public bool Success { get; set; }
		public string Message { get; set; }
	}

	public class EntryServiceResponse<T> : ServiceResponse
	{
		public T Entry { get; set; }
	}

	public class EntriesServiceResponse<T> : ServiceResponse
	{
		public IEnumerable<T> Entries { get; set; }
	}
}